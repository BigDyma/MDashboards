using Entity.Models;
using Entity.Repository.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Entity.Repository
{
    public class ReportRepository : SQLGenericRepository<Report>, IReport
    {
        public ReportRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task CreateReport(Report report)
        {
            await base.Create(report);
        }

        public async Task<Project> GetReportProject(long id)
        {
            var report = await base.GetEntity(id);

            var project = _db.Set<Project>().FirstOrDefault(p => p.Id == report.ProjectId);

            return project;
        }

        public async Task<User> GetReportUser(long id)
        {
            var project = await GetReportProject(id);

            return _db.Set<User>().FirstOrDefault(p => p.Id == project.UserId); 
        }

    }
}
