using Entity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Entity.Repository
{
    public interface IProjectRepository: IRepository<Project>
    {
        Task<Project> GetByName(string name);
        Task<Project> GetById(long id);
        Task<Project> CreateProject(Project project);

        Task DeleteProject(long id);

        Task<ICollection<Report>> GetReports(long id);

        Task<Project> UpdateProject(Project report);

    }
}