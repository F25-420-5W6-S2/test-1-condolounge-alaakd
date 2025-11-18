using CondoLounge.Data.Entities;
using CondoLounge.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CondoLounge.Data.Repositories
{
    public class UserRepository: CondoLoungeGenericGenericRepository<ApplicationUser>
        //, IUserRepository
    {
        private readonly ApplicationDbContext _context;

        

        public UserRepository(ApplicationDbContext db, ILogger<UserRepository> logger) : base(db, logger)
        {
            _context = db;
        }

        public async Task<IEnumerable<ApplicationUser>> GetUsersForBuildingAsync(int buildingId)
        {
            return await _context.Users
                .Where(u => u.BuildingId == buildingId)
                .ToListAsync();
        }
    }
}
