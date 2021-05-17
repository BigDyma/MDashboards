using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model.Dto.Projects;
using WebAPI.Model.Dto.Reports;
using WebAPI.Model.Dto.User;

namespace WebAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserResponseDto> GetUser(long id);

        Task<UserResponseDto> UpdateUser(UserUpdateDto userUpdateDto);

        Task DeleteUser(long id);

        Task<ICollection<ProjectResponseDto>> GetUserProjects(long id);

        Task<ICollection<ReportResponseDto>> GetUserReports(long id);


    }
}
