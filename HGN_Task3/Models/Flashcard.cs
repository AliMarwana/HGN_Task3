namespace HGN_Task3.Models
{
    public class Flashcard: BaseModel
    {
        public string? Question { get; set; }
        public string? Answer { get; set; }
        public string? Explanation { get; set; }
        public int Order { get; set; }
        public FlashcardsListModel? FlashcardsListModel{ get; set; }
    }
}
