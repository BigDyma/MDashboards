using AutoMapper;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model.Dto.Reports;
using WebAPI.Model.Dto.User;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{
    public class ReportService : IReportService
    {
        private IMapper _mapper { get; } 


        public ReportService()
        {

        }
        public Task CreateUser(ReportCreateDto reportCreate)
        {
            throw new NotImplementedException();
        }

        public Task DeleteReport(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Report> GetReport(long id)
        {
            throw new NotImplementedException();
        }

        public Task<UserResponseDto> GetReportUser(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ReportResponseDto> UpdateReport(ReportUpdateDto reportUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
