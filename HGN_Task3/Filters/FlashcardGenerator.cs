using HGN_Task3.DTOs;
using HGN_Task3.Models;
using Microsoft.SemanticKernel;
using Newtonsoft.Json;

namespace HGN_Task3.Filters
{
    public class FlashcardGenerator
    {
        private readonly Kernel _kernel;
        public FlashcardGenerator(Kernel kernel)
        {
            _kernel = kernel;
        }

        private string CreatePrompt(FlashcardRequest request)
        {
            return $"""
        Create {request.NumberOfCards} educational flashcards about "{request.Topic}" at {request.Difficulty} level.
        
        Requirements:
        - Each flashcard should have a clear question and a detailed answer
        - Include explanations where helpful
        - Make them educational and accurate
        - Format the response as a JSON array
        The word in Arabic is the question, the answer is the meaning in English, and the explanation is an optional detailed explanation of the word.

        
        JSON Format:
        [
            "question": "Question text here",
            "answer": "Answer text here",
            "explanation": "Optional explanation",
            "order:"order of the card in the list"
        ]
        
        Topic: {request.Topic}
        Difficulty: {request.Difficulty}
        Number of cards: {request.NumberOfCards}
     
        """;
        }
        public async Task<ResponseDto> GenerateFlashcardsAsync(FlashcardRequest request)
        {
            try
            {
                var prompt = CreatePrompt(request);

                var result = await _kernel.InvokePromptAsync(prompt);
                var jsonResult = result.ToString().Trim();
                return ParseFlashcardsResponse(jsonResult, request.Topic, request.Difficulty);
            }
            catch (Exception ex)
            {

                return new ResponseDto
                {
                    Status = 400, 
                    Message = "There is a problem in processing"
                };
                //_logger.LogError(ex, "Error generating flashcards for topic: {Topic}", request.Topic);
                //return new FlashcardResponse
                //{
                //    Success = false,
                //    ErrorMessage = $"Failed to generate flashcards: {ex.Message}"
                //};
            }
        }

        private ResponseDto ParseFlashcardsResponse(string response, string topic, string difficulty)
        {
            //try
            //{
                // Extract JSON from response (in case there's additional text)
                var jsonStart = response.IndexOf('[');
                var jsonEnd = response.LastIndexOf(']') + 1;

                if (jsonStart >= 0 && jsonEnd > jsonStart)
                {
                    var jsonContent = response.Substring(jsonStart, jsonEnd - jsonStart);
                    var rawFlashcards = JsonConvert.DeserializeObject<List<Flashcard>>(jsonContent);

                    var flashcards = rawFlashcards.Select(f => new Flashcard
                    {
                        Question = f.Question,
                        Answer = f.Answer,
                        Explanation = f.Explanation,
                        Order = f.Order
                    }).ToList();

                return new ResponseDto
                {
                    Data = new FlashcardsListModel { Flashcards = flashcards},
                    Message = "Good",
                    Status = 200
                };
                  
                }

            return new ResponseDto
            {
                Status = 500,
                Message = "Could not parse flashcards from AI response"
            };
            //return new FlashcardResponse
            //{
            //    Success = false,
            //    ErrorMessage = "Could not parse flashcards from AI response"
            //};
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError(ex, "Error parsing flashcards response");
            //    return new FlashcardResponse
            //    {
            //        Success = false,
            //        ErrorMessage = "Failed to parse flashcards response"
            //    };
            //}
        }
    }
}
