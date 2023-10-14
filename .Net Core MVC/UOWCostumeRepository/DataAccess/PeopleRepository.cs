using Entities;

namespace DataAccess
{
    public class PeopleRepository : GenericReposiory<People> , IPeopleRepository
    {
        public PeopleRepository(MyDbContext context) : base (context)
        {
            
        }
    }
}
