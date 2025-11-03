using HGN_Task3.Data;
using HGN_Task3.DTOs;
using HGN_Task3.Filters;
using HGN_Task3.Models;
using HGN_Task3.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HGN_Task3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlashcardsController : ControllerBase
    {
        private FlashcardRepository _flashcardRepository;
        private FlashcardGenerator _flashcardGenerator;
        private UserRepository _userRepository;
        private AppDbContext _appDbContext;
    
        public FlashcardsController(FlashcardRepository flashcardRepository,
            FlashcardGenerator flashcardGenerator,
            UserRepository userRepository, AppDbContext appDbContext)
        {
            _flashcardRepository = flashcardRepository;
            _userRepository = userRepository;
            _flashcardGenerator = flashcardGenerator;
            _appDbContext = appDbContext;
        }

        
        [HttpPost]
        public async Task<IActionResult> CreateFlashcards(
            string flashCardsListTitle,
              string email,
            string? topic = null,
            string? difficulty = null,
            int? cardsNumber = null, string? displayName = null)
        {
            
            var response = await _userRepository.CreateOrUpdateUser(email, displayName);
            if (response.Status != 200)
            {
                return StatusCode(response.Status, response.Message);
            }
            else
            {
                var flashcardRequest = new FlashcardRequest
                {
                    NumberOfCards = cardsNumber,
                    Difficulty = difficulty,
                    Topic = topic
                };
                var responseFlashcardValidation = _flashcardRepository.ValidationFlashcard(flashcardRequest);
                if (response.Status != 200)
                {
                    return StatusCode(responseFlashcardValidation.Status, responseFlashcardValidation.Message);
                }
                else
                {
                   var responseFlashCard = await _flashcardGenerator.GenerateFlashcardsAsync(flashcardRequest);
                    if(responseFlashCard.Status != 200)
                    {
                        return StatusCode(responseFlashCard.Status, responseFlashCard.Message);
                    }
                    else
                    {
                        var flashcardsList = (FlashcardsListModel?)responseFlashCard.Data;
                        flashcardsList.Title = flashCardsListTitle;
                        flashcardsList.User = await _appDbContext.Users.FirstOrDefaultAsync(p => p.Email == email);
                        await _appDbContext.FlashcardsListModels.AddAsync(flashcardsList);
                        await _appDbContext.SaveChangesAsync();
                        return Ok(flashcardsList);

                    }
                }

                
            }
            return Ok();
        }

        [HttpGet("ListModels/{userEmail}")]
        public async Task<IActionResult> GetFlashcardsListModels(string userEmail)
        {
            try
            {
                var list = await _flashcardRepository.GetFlashcardsListModel(userEmail);
                return Ok(list);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Internal server error" });
            }
        }

        [HttpGet("Items/{listModelId}")]
        public async Task<IActionResult> GetFlashcardsFromListModel(int listModelId)
        {
            try
            {
                var flashcards = await _flashcardRepository.GetFlashcardsOfListModel(listModelId);
                return Ok(flashcards);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Internal server error" });
            }
           
        }

        [HttpPost("SendResponses")]
       public async Task<IActionResult> SendResponsesOfFlashcards([FromBody]UserFullResponseDto userFullResponseDto)
        {
            var userFullResponse = new UserFullResponse();
            var user = await _appDbContext.Users.FirstOrDefaultAsync(p => p.Email == userFullResponseDto.Email);
            var userItemResponses = new List<UserItemResponse>();
            foreach (var userItemResponseDto in userFullResponseDto.UserItemResponses)
            {
                var newUserItemResponse = new UserItemResponse();   
                newUserItemResponse.IsAnswerKnown = userItemResponseDto.IsAnswerKnown;
                newUserItemResponse.Flashcard = await _appDbContext.Flashcards.FirstOrDefaultAsync(p => p.Id == userItemResponseDto.FlashcardId);
                userItemResponses.Add(newUserItemResponse);
            }
            userFullResponse .UserItemResponses = userItemResponses;
            userFullResponse.User = user;
            await _appDbContext.UserFullResponses.AddAsync(userFullResponse);
            return Ok();
            
        }
        
        
    }
}
