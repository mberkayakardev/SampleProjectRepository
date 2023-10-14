using Entities;

namespace DataAccess
{
    public interface IUOW
    {
        void SaveChanges();
        IGenericRepository<T> GetGenericRepository<T>() where T : class, IEntity, new ();
        TRepository GetRepository<T, TRepository>() where T : IEntity where TRepository : IGenericRepository<T> ;




    }
}
