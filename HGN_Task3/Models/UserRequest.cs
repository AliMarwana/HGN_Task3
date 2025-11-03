namespace HGN_Task3.Models
{
    public class UserRequest: BaseModel
    {
        public User? User { get; set; }
        public string? Prompt { get; set; }
       

    }
}
