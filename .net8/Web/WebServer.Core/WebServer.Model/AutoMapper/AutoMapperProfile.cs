using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.Model.Dtos.Auth;
using WebServer.Model.Entities.Auth;

namespace WebServer.Model.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserEntity, UserDto>().ForMember(x => x.Id, a => a.MapFrom(entity => entity.Id));
            CreateMap<UserRegisterDto, UserEntity>();
        }
    }
}
