using AkarDataAccess.Abstract;
using AkarEntities.Entities;
using Microsoft.EntityFrameworkCore;

namespace AkarDataAccess.Concrete.Repository
{
    public class TokenRepository : GenericRepository<Token> , ITokenRepository
    {
        public TokenRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
