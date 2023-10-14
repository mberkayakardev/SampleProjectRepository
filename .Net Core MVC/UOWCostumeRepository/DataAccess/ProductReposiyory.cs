using Entities;

namespace DataAccess
{
    public class ProductReposiyory : GenericReposiory<Product>, IProductRepository
    {
        public ProductReposiyory(MyDbContext context) : base(context)
        {

        }
        public void AddBerkayinMethodu()
        {
        }
    }
}
