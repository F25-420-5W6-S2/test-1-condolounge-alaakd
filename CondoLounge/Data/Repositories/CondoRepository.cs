using CondoLounge.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CondoLounge.Data.Repositories
{
    public class CondoRepository : CondoLoungeGenericGenericRepository<Condo>
    {
        private readonly ApplicationDbContext _context;
        public CondoRepository(ApplicationDbContext db, ILogger<CondoRepository> logger) : base(db, logger)
        {
            _context = db;
        }

        public async Task<IEnumerable<Condo>> GetCondosForBuildingAsync(int buildingId)
        {
            return await _context.Condos
                .Where(u => u.BuildingId == buildingId)
                .ToListAsync();
        }
    }
}
