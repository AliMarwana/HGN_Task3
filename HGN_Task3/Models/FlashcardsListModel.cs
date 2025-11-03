namespace HGN_Task3.Models
{
    public class FlashcardsListModel: BaseModel
    {
        public string? Title { get; set; }
        public List<Flashcard>? Flashcards { get; set; }
        public User? User { get; set; }
    }
}
