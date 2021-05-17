using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class ProjectsController : Controller
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProject(long id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "Admin")] @TO-DO uncomment this
        public async Task<IActionResult> DeleteProject(long id)
        {
            throw new NotImplementedException();
        }

        //[HttpPut]
        //public async Task<IActionResult> UpdateProject([FromBody] ProjectUpdateDto userModel)
        //{
        //    throw new NotImplementedException();
        //}

        [HttpGet("{id}/reports")]
        public async Task<IActionResult> GetProjectReports (long id)
        {
            throw new NotImplementedException();
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateProject([FromBody] ProjectCreateDto projectCreateDto)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
