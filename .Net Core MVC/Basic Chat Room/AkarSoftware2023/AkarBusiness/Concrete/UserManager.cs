using AkarBusiness.Abstract;
using AkarDataAccess.Abstract;
using AkarEntities.Entities;
using AutoMapper;

namespace AkarBusiness.Concrete
{
    public class UserManager : GenericManager<User>, IUserService
    {
        public UserManager(IGenericRepository<User> genericService, IUnitOfWork unitOfWork, IMapper mapper) : base(genericService, unitOfWork, mapper)
        {

        }
    }
}
