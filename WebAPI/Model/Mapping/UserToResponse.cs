using AutoMapper;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model.Dto.User;

namespace WebAPI.Model.Mapping
{
    public class UserToResponse: Profile
    {
        public UserToResponse()
        {
            CreateMap<User, UserResponseDto>().ForMember(u => u.Phone, mapper => mapper.MapFrom(u => u.PhoneNumber));
        }
    }
}
