using CondoLounge.Data.Entities;
using CondoLounge.Data.Interfaces;

namespace CondoLounge.Data.Repositories
{
    public class BuildingRepository: CondoLoungeGenericGenericRepository<Building>
    {
        public BuildingRepository(ApplicationDbContext db, ILogger<BuildingRepository> logger) : base(db, logger)
        {
        }
    }
}
