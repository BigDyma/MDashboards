using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model.Dto.Projects;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class ProjectsController : BaseController
    {
        private IProjectService _projectService { get; }
        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProject(long id)
        {
            var result = await _projectService.GetProject(id);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "Admin,User")] @TO-DO uncomment this
        public async Task<IActionResult> DeleteProject(long id)
        {
            await _projectService.DeleteProject(id);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject([FromBody] ProjectUpdateDto userModel)
        {
            await _projectService.UpdateProject(userModel);

            return Ok();
        }

        [HttpGet("{id}/reports")]
        public async Task<IActionResult> GetProjectReports (long id)
        {
            var res = await _projectService.GetReports(id);
            return Ok(res);
        }

        [HttpPost("add")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateProject([FromBody] ProjectCreateDto projectCreateDto)
        {
            await _projectService.CreateProject(projectCreateDto);
            return Ok();
        }
    }
}
