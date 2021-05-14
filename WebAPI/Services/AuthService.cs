using AutoMapper;
using Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Exceptions;
using WebAPI.Model.Dto;
using WebAPI.Model.Dto.User;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{
    public class AuthService : IAuthService
    {
        private  IUserRepository _userRepository { get; }
        private IMapper _mapper { get; }
        private SignInManager<User> _signInManager { get; }
        private  UserManager<User> _userManager { get; }
        public AuthService(IUserRepository userRepository, IMapper mapper, UserManager<User> userManager)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public Task<UserResponseDto> Login(LoginUserQueryDto loginUserDto)
        {
            throw new NotImplementedException();
        }

        public void LogOut()
        {
            throw new NotImplementedException();
        }

        public async Task<UserResponseDto> RegisterUser(RegisterUserQueryDto registerUserDto)
        {
           var check = await _userRepository.SingleUserNameAndEmail(username: registerUserDto.UserName, email: registerUserDto.Email);

            if (check != null)
            {
                var email = registerUserDto.Email == check.Email ? registerUserDto.Email  : "";
                var username = registerUserDto.UserName == check.UserName ? registerUserDto.UserName : "";

                var e = registerUserDto.Email == check.Email ? "Email - " : "";
                var u = registerUserDto.UserName == check.UserName ? "UserName :" : "";

                throw new UserAlreadyExistException($" {e} {u} {email} - {username} is already taken!");
            }

            var user = _mapper.Map<User>(registerUserDto);

            var result = await RegisterNewUser(user, registerUserDto.Password);
            if (!result.Succeeded)
            {
                throw new InvalidFormException("", result.Errors
                                                            .Select(e => e.Description)
                                                            .Aggregate((x, res) => res += x + "\n"));
            }

            return _mapper.Map<UserResponseDto>(registerUserDto);
        }

        private async Task<IdentityResult> RegisterNewUser(User user, string password )
        {
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
               await _userRepository.Save();
            }

            return result;
        }
    }
}
