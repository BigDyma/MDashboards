using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model.Dto.Projects;
using WebAPI.Model.Dto.Reports;
using WebAPI.Model.Dto.User;

namespace WebAPI.Services.Interfaces
{
    public interface IReportService
    {
        Task<ReportResponseDto> GetReport(long id);

        Task<ReportResponseDto> UpdateReport(ReportUpdateDto reportUpdate);

        Task DeleteReport(long id);

        Task<UserResponseDto> GetReportUser(long id);

        Task CreateReport(ReportCreateDto reportCreate);

        Task<ProjectResponseDto> GetReportProject(long id);
    }
}
