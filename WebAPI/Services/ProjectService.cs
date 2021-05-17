﻿using AutoMapper;
using Entity.Models;
using Entity.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model.Dto.Projects;
using WebAPI.Model.Dto.Reports;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{
    public class ProjectService : IProjectService
    {
        private IProjectRepository _projectRepository { get; }
        private IMapper _mapper { get; set; }
        public ProjectService(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }
        public async Task<ProjectResponseDto> CreateProject(ProjectCreateDto projectCreate)
        {
            var project = _mapper.Map<Project>(projectCreate);
            var res = await _projectRepository.CreateProject(project);

            var output = _mapper.Map<ProjectResponseDto>(res);

            return output;

        }

        public async Task DeleteProject(long id)
        {
            await _projectRepository.DeleteProject(id);
        }

        public async Task<ProjectResponseDto> GetProject(long id)
        {
            var res = await _projectRepository.GetById(id);

            var output = _mapper.Map<ProjectResponseDto>(res);

            return output;

        }

        public async Task<ICollection<ReportResponseDto>> GetReports(long id)
        {
            var res = await _projectRepository.GetReports(id);

            var output = _mapper.Map<ICollection<ReportResponseDto>>(res);

            return output;

        }

        public Task UpdateProject(long id, ProjectUpdateDto projectUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
