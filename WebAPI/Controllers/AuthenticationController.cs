using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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


    }
}
