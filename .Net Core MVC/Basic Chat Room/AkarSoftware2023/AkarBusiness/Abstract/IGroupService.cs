using AkarEntities.Dtos;
using AkarEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AkarBusiness.Abstract
{
    public interface IGroupService: IGenericService<Group>
    {
        List<ListGroupDto> GroupList(Expression<Func<Group, bool>> where = null, Expression<Func<Group, object>>[] include = null);
    }
}
