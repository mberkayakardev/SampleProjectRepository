using AkarDataAccess.Abstract;
using AkarEntities.Entities;
using Microsoft.EntityFrameworkCore;

namespace AkarDataAccess.Concrete.Repository
{
    public class GroupRepository : GenericRepository<Group>, IGroupRepository
    {
        public GroupRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
