namespace HGN_Task3.Models
{
    public class UserFullResponse: BaseModel
    {
        public User? User { get; set; }
        public List<UserItemResponse>? UserItemResponses { get; set; }
    }
}
