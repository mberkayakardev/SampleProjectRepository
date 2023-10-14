using Entities;

namespace DataAccess
{
    public class CategoryReposiyory : GenericReposiory<Category> , ICategoryReposiyory 
    {
        public CategoryReposiyory(MyDbContext context) : base(context)
        {

        }
    }

}
