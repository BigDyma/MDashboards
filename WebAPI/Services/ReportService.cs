using AutoMapper;
using Common.Exceptions;
using Entity.Models;
using Entity.Repository;
using Entity.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model.Dto.Projects;
using WebAPI.Model.Dto.Reports;
using WebAPI.Model.Dto.User;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{
    public class ReportService : IReportService
    {
        private IProjectRepository _projectRepository { get; }

        private IMapper _mapper { get; } 
        private IReport  _reportRepository { get; }

        public ReportService(IReport reportRepository, IMapper mapper, IProjectRepository projectRepository)
        {
            _reportRepository = reportRepository;
            _mapper = mapper;
            _projectRepository = projectRepository;
        }

        public async Task CreateReport(ReportCreateDto reportCreate)
        {
            var project = await _projectRepository.GetById(reportCreate.ProjectId);

            if (project == null)
                throw new EntityNotFoundException("", "Project doesn't exist!");

            var report = _mapper.Map<Report>(reportCreate);

            await _reportRepository.CreateReport(report);
        }

        public async Task DeleteReport(long id)
        {
            var report =  await _reportRepository.GetEntity(id);

            checkExistance(report);

            await _reportRepository.Delete(report);

        }

        public async Task<ReportResponseDto> GetReport(long id)
        {
            var report = await _reportRepository.GetEntity(id);

            var response = _mapper.Map<ReportResponseDto>(report);

            return response;
        }

        public async Task<UserResponseDto> GetReportUser(long id)
        {
            var user = await _reportRepository.GetReportUser(id);

            var resul = _mapper.Map<UserResponseDto>(user);

            return resul;
        }

        public async Task<ReportResponseDto> UpdateReport(ReportUpdateDto reportUpdate)
        {
            var report =  _mapper.Map<Report>(reportUpdate);

            await _reportRepository.Update(report);

            var response = _mapper.Map<ReportResponseDto>(reportUpdate);

            return response;

        }
        private void checkExistance(Report report)
        {
            if (report == null)
                throw new EntityNotFoundException("", "No such user exist");
        }

        public async Task<ProjectResponseDto> GetReportProject(long id)
        {
            var project = await _reportRepository.GetReportProject(id);

            var resul = _mapper.Map<ProjectResponseDto>(project);

            return resul;
        }
    }
}
