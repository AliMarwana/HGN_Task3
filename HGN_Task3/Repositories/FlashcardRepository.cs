using HGN_Task3.Data;
using HGN_Task3.DTOs;
using HGN_Task3.Models;
using Microsoft.EntityFrameworkCore;

namespace HGN_Task3.Repositories
{
    public class FlashcardRepository
    {
        private AppDbContext _appDbContext;
        public FlashcardRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        
        public ResponseDto ValidationFlashcard(FlashcardRequest request)
        {
            if(String.IsNullOrEmpty(request.Topic))
            {
                return new ResponseDto
                {
                    Status = 400,
                    Message = "Topic should not be empty"
                };
            }
            else if (String.IsNullOrEmpty(request.Difficulty))
            {
                return new ResponseDto
                {
                    Status = 400,
                    Message = "Difficulty should not be empty"
                };
            }
            else if (request.NumberOfCards.HasValue && (request.NumberOfCards < 1 || request.NumberOfCards > 20))
            {
                return new ResponseDto
                {
                    Status = 400,
                    Message = "Number of cards must be between 1 and 20"
                };
            }
            else
            {
                return new ResponseDto
                {
                    Status = 200,
                    Message = "Validation successful"
                };
            }
        }
        public async Task<List<FlashcardsListModel>> GetFlashcardsListModel(string email)
        {
            var flashcardsListModels = await _appDbContext.FlashcardsListModels
                .Where(flm => flm.User != null && flm.User.Email == email)
                .ToListAsync();
            return flashcardsListModels;
        }

        public async Task<List<Flashcard>> GetFlashcardsOfListModel(int listModelId)
        {
            var flashcards = await _appDbContext.Flashcards
                .Include(p => p.FlashcardsListModel)
                .Where(p => p.FlashcardsListModel.Id == listModelId)
                .ToListAsync();
            return flashcards;
        }
    }
}
