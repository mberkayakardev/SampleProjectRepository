using AkarBusiness.Abstract;
using AkarDataAccess.Abstract;
using AkarEntities.Entities;
using AutoMapper;

namespace AkarBusiness.Concrete
{
    public class TokenManager : GenericManager<Token>, ITokenService
    {
        public TokenManager(IGenericRepository<Token> genericService, IUnitOfWork unitOfWork, IMapper mapper) : base(genericService, unitOfWork, mapper)
        {

        }
    }
}
