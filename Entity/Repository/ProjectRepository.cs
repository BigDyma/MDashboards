using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Entity.Repository
{
    public class ProjectRepository : SQLGenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(ApplicationContext context) : base(context)
        {

        }
        public async Task<Project> CreateProject(Project project)
        {
            await base.Create(project);

            return project;

        }

        public async Task DeleteProject(long id)
        {
            // @TO-DO find a way to refactor this in a more generic way
            var res = await _db.Set<Project>().FirstOrDefaultAsync(u => u.Id == id);


            await Delete(res);
        }

        public async Task<Project> GetById(long id)
        {
            var res = await _db.Set<Project>().FirstOrDefaultAsync(x => x.Id == id);

            return res;
        }

        public async Task<Project> GetByName(string name)
        {
            return await _db.Set<Project>().FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<ICollection<Report>> GetReports(long id)
        {
            var res = await _db.Set<Project>().FirstOrDefaultAsync(u => u.Id == id);

            return res?.Reports;
        }

        public async Task<Project> UpdateProject( Project project)
        {
            await base.Update(project);

            return project;
        }
    }
}
