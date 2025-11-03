using HGN_Task3.Data;
using HGN_Task3.DTOs;
using System.Text.RegularExpressions;

namespace HGN_Task3.Repositories
{
    public class UserRepository
    {
        private AppDbContext _appDbContext;
        // More comprehensive RFC 5322 compliant pattern
        private static readonly string ComprehensiveEmailPattern =
            @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$";
        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ResponseDto> CreateOrUpdateUser(string email, string? displayName = null)
        {
            if (String.IsNullOrEmpty(email))
            {
                return new ResponseDto
                {
                    Status = 400,
                    Message = "Email should not be empty"
                };
            }
            else if (!Regex.IsMatch(email, ComprehensiveEmailPattern))
            {
                return new ResponseDto
                {
                    Status = 400,
                    Message = "Email format is invalid"
                };
            }
            else
            {
                var user = _appDbContext.Users.FirstOrDefault(u => u.Email == email);
                if (user != null)
                {
                    // Update existing user
                    if (!String.IsNullOrEmpty(displayName))
                    {
                        user.DisplayName = displayName;
                    }
                }
                else
                {
                    // Create new user
                    user = new Models.User
                    {
                        Email = email,
                        DisplayName = displayName
                    };
                    await _appDbContext.Users.AddAsync(user);
                }
                await _appDbContext.SaveChangesAsync();
                return new ResponseDto
                {
                    Status = 200,
                    Message = "User created/updated successfully",
                    Data = user
                };
            }
        }
           
          
    }
}
