using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model.Dto.Reports;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    public class ReportController : BaseController
    {
        private IReportService _reportService { get; }
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReport(long id)
        {
            var result = await _reportService.GetReport(id);
            return Ok(result); 
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "Admin")] @TO-DO uncomment this
        public async Task<IActionResult> DeleteReport(long id)
        {
            await _reportService.DeleteReport(id);

            return Ok();

        }

        [HttpPut]
        public async Task<IActionResult> UpdateReport([FromBody] ReportUpdateDto userModel)
        {
            await _reportService.UpdateReport(userModel);

            return Ok();

        }

        [HttpGet("{id}/project")]
        public async Task<IActionResult> GetProjectName(long id)
        {
            var res = await _reportService.GetReportProject(id);

            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReport([FromBody] ReportCreateDto projectCreateDto)
        {
            await _reportService.CreateReport(projectCreateDto);

            return Ok();
        }
    }
}
