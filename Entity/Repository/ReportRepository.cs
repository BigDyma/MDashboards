using Entity.Models;
using Entity.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Repository
{
    class ReportRepository : SQLGenericRepository<Report>, IReport
    {
        public ReportRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task CreateReport(Report report)
        {
            await base.Create(report);
        }

        public async Task<User> GetReportUser(long id)
        {
            var project = await base.GetEntity(id);

            var projectId = project.ProjectId;



        }
    }
}
