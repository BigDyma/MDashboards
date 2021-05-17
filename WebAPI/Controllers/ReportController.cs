using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class ReportController : BaseController
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReport(long id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "Admin")] @TO-DO uncomment this
        public async Task<IActionResult> DeleteReport(long id)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReport([FromBody] ReportUpdateDto userModel)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}/project")]
        public async Task<IActionResult> GetProjectName(long id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> CreateReport([FromBody] ReportCreateDto projectCreateDto)
        {
            throw new NotImplementedException();
        }

    }
}
