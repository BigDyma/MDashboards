using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model.Dto.User;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class UsersController : BaseController
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(long id)
        {
            throw new NotImplementedException();
        }
        
        [HttpDelete("{id}")]
        //[Authorize(Roles = "Admin")] @TO-DO uncomment this
        public async Task<IActionResult> DeleteUser(long id)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UserUpdateDto userModel)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}/projects")]
        public async Task<IActionResult> GetUserProjects(long id)
        {
            throw new NotImplementedException();
        }
        [HttpGet("{id}/reports")]
        public async Task<IActionResult> GetUserReports(long id)
        {
            throw new NotImplementedException();
        }

    }
}
