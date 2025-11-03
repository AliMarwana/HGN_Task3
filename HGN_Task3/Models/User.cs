namespace HGN_Task3.Models
{
    public class User: BaseModel
    {

        public string? Email { get; set; }
        //public FormerResponse? FormerResponse { get; set; }
        public List<UserFullResponse>? UserFullResponses { get; set; }
        public List<FlashcardsListModel>? FlashcardsListModels { get; set; }

    }
}
