namespace HGN_Task3.Models
{
    public class Flashcard: BaseModel
    {
        public string? Question { get; set; }
        public string? Answer { get; set; }
        FlashcardsListModel? FlashcardsListModel { get; set; }
    }
}
