using AutoMapper;
using Common.Exceptions;
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
           var res =  await _projectRepository.GetById(id);

           if (res == null)
                throw new EntityNotFoundException("", "Project doesn't exist!");

            await _projectRepository.DeleteProject(id);
        }

        public async Task<ProjectResponseDto> GetProject(long id)
        {
            var res = await _projectRepository.GetById(id);

            if (res == null)
                throw new EntityNotFoundException("", "No such project exist");

            var output = _mapper.Map<ProjectResponseDto>(res);

            return output;

        }

        public async Task<ICollection<ReportResponseDto>> GetReports(long id)
        {
            var res = await _projectRepository.GetReports(id);

            var output = _mapper.Map<ICollection<ReportResponseDto>>(res);

            return output;

        }

        public async Task UpdateProject(ProjectUpdateDto projectUpdate)
        {
            //@TO-DO refactor with mapper
            var res = await _projectRepository.GetById(projectUpdate.Id);

            if (res == null)
                throw new EntityNotFoundException("", "No such project exist");

            await _projectRepository.UpdateProject(new Project { Id = projectUpdate.Id, Name = projectUpdate.Name });

        }
    }
}
