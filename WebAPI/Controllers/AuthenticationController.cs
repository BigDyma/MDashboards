﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class AuthenticationController: BaseController
    {
        [HttpPost("register")]
        public async Task<IActionResult> Create()
        {
            return Ok();
        }


    }
}