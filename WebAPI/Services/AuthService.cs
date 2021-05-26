using AutoMapper;
using Common.Exceptions;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebAPI.Model.AuthOptions;
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
        private IOptions<AuthOptions> _authOptions { get; }
        public AuthService(IUserRepository userRepository, IMapper mapper, UserManager<User> userManager,IOptions<AuthOptions> authOptions, SignInManager<User> signInManager)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userManager = userManager;
            _authOptions = authOptions;
            _signInManager = signInManager;
        }

        public async Task<LoginUserResponseDto> Login(LoginUserQueryDto loginUserDto)
        {
            var checkUsername = _userRepository.GetByUserName(loginUserDto.UserName);

            var checkPass = await _signInManager.PasswordSignInAsync(loginUserDto.UserName, loginUserDto.Password, false, false);
            if (!checkPass.Succeeded || checkUsername == null)
            {
                throw new InvalidFormException($"", "wrong username or password", StatusCodes.Status401Unauthorized);
            }
            var user = await _userRepository.GetByUserName(loginUserDto.UserName);

            var token = await GenerateToken(user);

            return new LoginUserResponseDto {  Token = token };

        }

        private async Task<string> GenerateToken(User user)
        {
            var authParams = _authOptions.Value;

            var roles = await _userManager.GetRolesAsync(user);

            var securityKey = authParams.GetSymmetricSecurityKey();

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName)
                };

            roles.ToList().ForEach(r => claims.Add(new Claim(ClaimTypes.Role, r)));

            var token = new JwtSecurityToken(authParams.Issuer, 
                                            authParams.Audience, 
                                            claims, expires: DateTime.Now.AddSeconds(authParams.TokenLifeTime), 
                                            signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<UserResponseDto> RegisterUser(RegisterUserQueryDto registerUserDto)
        {
           var check = await _userRepository.SingleUserNameAndEmail(username: registerUserDto.UserName, email: registerUserDto.Email);

            if (check != null)
            {
                // @TO-DO refactor
                var email = registerUserDto.Email == check.Email ? "Email - " : "";
                var username = registerUserDto.UserName == check.UserName ? "UserName :" : "";

                throw new EntityAlreadyExistException("", $" {email} {username} already taken!");
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
