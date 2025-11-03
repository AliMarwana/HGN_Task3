namespace HGN_Task3.Models
{
    public class UserItemResponse: BaseModel
    {
        public Flashcard? Flashcard { get; set; }
        public string? UserAnswer { get; set; }
        public bool Success { get; set; }
    }
}
