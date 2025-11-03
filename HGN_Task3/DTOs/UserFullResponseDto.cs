using HGN_Task3.Models;

namespace HGN_Task3.DTOs
{
    public class UserFullResponseDto
    {
        public string? Email{ get; set; }
        public List<UserItemResponseDto>? UserItemResponses { get; set; }
    }
}
