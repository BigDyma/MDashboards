using AutoMapper;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model.Dto;
using WebAPI.Model.Dto.User;

namespace WebAPI.Model.Mapping
{
    public class UserRegisterProfile: Profile
    {
        public UserRegisterProfile()
        {
            CreateMap<RegisterUserQueryDto, User>();

            CreateMap<RegisterUserQueryDto, UserResponseDto>();

            
        }
    }
}
