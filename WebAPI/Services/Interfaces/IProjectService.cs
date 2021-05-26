using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model.Dto.Projects;
using WebAPI.Model.Dto.Reports;

namespace WebAPI.Services.Interfaces
{
    public interface IProjectService
    {
        Task<ProjectResponseDto> GetProject(long id);
        Task DeleteProject(long id);
        Task<ICollection<ReportResponseDto>> GetReports(long id);

        Task UpdateProject(ProjectUpdateDto projectUpdate);

        Task CreateProject(ProjectCreateDto projectCreate);
    }
}
