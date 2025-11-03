using HGN_Task3.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HGN_Task3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlashcardsController : ControllerBase
    {
        private FlashcardRepository _flashcardRepository;
        public FlashcardsController(FlashcardRepository flashcardRepository)
        {
            _flashcardRepository = flashcardRepository;
        }


        [HttpPost]
        public async Task<IActionResult> CreateFlashcards(string topic,
            string email,
            int? cardsNumber = null, string? displayName = null)
        {
            

            return Ok();
        }
    }
}
