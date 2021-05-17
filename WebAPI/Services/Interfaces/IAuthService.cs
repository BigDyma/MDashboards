using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model.Dto;
using WebAPI.Model.Dto.User;

namespace WebAPI.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginUserResponseDto> Login(LoginUserQueryDto loginUserDto);

        Task LogOut();

        Task<UserResponseDto> RegisterUser(RegisterUserQueryDto registerUserDto);

    }
}
