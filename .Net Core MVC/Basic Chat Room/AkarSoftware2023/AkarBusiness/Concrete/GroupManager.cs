using AkarBusiness.Abstract;
using AkarDataAccess.Abstract;
using AkarEntities.Dtos;
using AkarEntities.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http;

namespace AkarBusiness.Concrete
{
    public class GroupManager : GenericManager<Group>, IGroupService
    {
        public GroupManager(IGenericRepository<Group> genericService, IUnitOfWork unitOfWork, IMapper mapper) : base(genericService, unitOfWork, mapper)
        {
        }


        public List<ListGroupDto> GroupList(Expression<Func<Group, bool>> where = null, Expression<Func<Group, object>>[] include = null)
        {
            var model = GetEnum(where, include);
            var model2 = new List<ListGroupDto >();
            foreach (var item in model)
            {
                var sonuc = new ListGroupDto { CreateDate = item.CreateDate, 
                                               CreateUser = item.CreateUser,
                                                GecerliFlg = item.GecerliFlg,
                                               GroupName = item.GroupName,  
                                               MembersList = item.MembersList,
                                               Id = item.Id,
                                               IsPublicOrPrivate = item.IsPublicOrPrivate
                };
                model2.Add(sonuc);
            }

            return model2;
        }
    }
}
