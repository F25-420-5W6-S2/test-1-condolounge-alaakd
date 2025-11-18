using CondoLounge.Data.Entities;
using CondoLounge.Data.Interfaces;

namespace CondoLounge.Data.Repositories
{
    public class UserRepository: CondoLoungeGenericGenericRepository<ApplicationUser>
    {
        public UserRepository(ApplicationDbContext db, ILogger<UserRepository> logger) : base(db, logger)
        {
        }
    }
}
