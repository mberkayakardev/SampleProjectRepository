using Entities;

namespace DataAccess
{
    public interface IGenericRepository<T>
    {
        void Add(T entity);
        void List(T entity);
        void Delete(T entity);


    }
}
