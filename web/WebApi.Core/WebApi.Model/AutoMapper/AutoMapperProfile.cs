using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Model.Dtos.Sys;
using WebApi.Model.Entities.Sys;

namespace WebApi.Model.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserEntity, UserDto>().ForMember(x => x.UserId, a => a.MapFrom(entity => entity.Id));
        }

    }
}
