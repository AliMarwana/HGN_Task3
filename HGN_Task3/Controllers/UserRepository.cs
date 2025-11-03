using HGN_Task3.Data;

namespace HGN_Task3.Controllers
{
    public class UserRepository
    {
        private AppDbContext _appDbContext;
        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        
       
    }
}
