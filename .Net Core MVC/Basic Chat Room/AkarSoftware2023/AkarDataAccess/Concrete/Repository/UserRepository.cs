using AkarDataAccess.Abstract;
using AkarEntities.Entities;
using Microsoft.EntityFrameworkCore;

namespace AkarDataAccess.Concrete.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
