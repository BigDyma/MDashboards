using Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Repository.Interfaces
{
    interface IReport : IRepository<Report>
    {
        Task<User> GetReportUser(long id);

        Task CreateReport(Report report);
    }
}
