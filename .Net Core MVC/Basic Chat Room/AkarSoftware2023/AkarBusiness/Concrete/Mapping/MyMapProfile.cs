using AkarEntities.Dtos;
using AutoMapper;
using System.Text.RegularExpressions;

namespace AkarBusiness.Concrete.Mapping
{
    public class MyMapProfile : Profile
    {
        public MyMapProfile()
        {
            CreateMap<Group, ListGroupDto>();

        }
    }
}
