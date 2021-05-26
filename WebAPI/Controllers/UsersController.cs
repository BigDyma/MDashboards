using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model.Dto.User;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class UsersController : BaseController
    {
        private IUserService _userService { get; }

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(long id)
        {
            var res = await _userService.GetUser(id);

            return Ok(res);

        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "Admin")] @TO-DO uncomment this
        public async Task<IActionResult> DeleteUser(long id)
        {
            await _userService.DeleteUser(id);

            return Ok();

        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UserUpdateDto userModel)
        {

            var res = await _userService.UpdateUser(userModel);

            return Ok(res);
        }

        [HttpGet("{id}/projects")]
        public async Task<IActionResult> GetUserProjects(long id)
        {
            var res = await _userService.GetUserProjects(id);

            return Ok(res);
        }

        [HttpGet("{id}/reports")]
        public async Task<IActionResult> GetUserReports(long id)
        {
            var res = await _userService.GetUserReports(id);

            return Ok(res);
        }

    }
}
