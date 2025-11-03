namespace HGN_Task3.Models
{
    public class UserItemResponse: BaseModel
    {
        public Flashcard? Flashcard { get; set; }
        public bool IsAnswerKnown { get; set; } // 
        public bool Success { get; set; }
    }
}
