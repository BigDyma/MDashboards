using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model.AuthOptions;
using WebAPI.Model.Dto;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class AuthenticationController: BaseController
    {
        private IAuthService _authService { get; }


        public AuthenticationController(IAuthService authService)
        {

            _authService = authService;
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Create([FromBody] RegisterUserQueryDto registerUser)
        {
            var result = await _authService.RegisterUser(registerUser);
            return Ok(result);
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserQueryDto loginUser)
        {
            var result = await _authService.Login(loginUser);
            return Ok(result);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _authService.LogOut();
            return Ok(new {});
        }

    }
}
