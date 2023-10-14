using Entities;

namespace DataAccess
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        void AddBerkayinMethodu();
    }
}
