using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
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
            return await _db.Set<Project>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Project> GetByName(string name)
        {
            return await _db.Set<Project>().FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<ICollection<Report>> GetReports(long id)
        {
            var res = await _db.Set<Project>().FirstOrDefaultAsync(u => u.Id == id);

            if (res != null)
            {
                //@TO-DO refactor exceptions.
                throw new Exception("No such report");
            }
            return res.Reports;
        }

        public async Task<Project> UpdateProject(long id, Project report)
        {
            throw new NotImplementedException();
        }
    }
}
