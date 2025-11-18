using CondoLounge.Data.Entities;

namespace CondoLounge.Data.Interfaces
{
    public class IUserRepository : ICondoLoungeGenericRepository<ApplicationUser>
    {
        //Task<IEnumerable<ApplicationUser>> GetUsersForBuildingAsync(int BuildingId);

        void ICondoLoungeGenericRepository<ApplicationUser>.Add(ApplicationUser entity)
        {
            throw new NotImplementedException();
        }

        void ICondoLoungeGenericRepository<ApplicationUser>.Delete(ApplicationUser entity)
        {
            throw new NotImplementedException();
        }

        IEnumerable<ApplicationUser> ICondoLoungeGenericRepository<ApplicationUser>.GetAll()
        {
            throw new NotImplementedException();
        }

        ApplicationUser ICondoLoungeGenericRepository<ApplicationUser>.GetById(object id)
        {
            throw new NotImplementedException();
        }

        void ICondoLoungeGenericRepository<ApplicationUser>.SaveAll()
        {
            throw new NotImplementedException();
        }

        void ICondoLoungeGenericRepository<ApplicationUser>.Update(ApplicationUser entity)
        {
            throw new NotImplementedException();
        }
    }
}
