using HGN_Task3.Data;

namespace HGN_Task3.Repositories
{
    public class FlashcardRepository
    {
        private AppDbContext _appDbContext;
        public FlashcardRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}
