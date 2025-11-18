using CondoLounge.Data.Entities;

namespace CondoLounge.Data.Interfaces
{
    public class ICondoRepository: ICondoLoungeGenericRepository<Condo>
    {
        public void GetAll() { }
        public void GetById(object id) { }
        public void Add(Condo entity) { }
        public void Update(Condo entity) { }
        public void Delete(Condo entity) { }
        public void SaveAll() { }

        IEnumerable<Condo> ICondoLoungeGenericRepository<Condo>.GetAll()
        {
            throw new NotImplementedException();
        }

        Condo ICondoLoungeGenericRepository<Condo>.GetById(object id)
        {
            throw new NotImplementedException();
        }
    }
}
