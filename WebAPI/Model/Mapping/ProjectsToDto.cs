using AutoMapper;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model.Dto.Projects;

namespace WebAPI.Model.Mapping
{
    public class ProjectsToDto : Profile
    {
        public ProjectsToDto()
        {
            CreateMap<ProjectCreateDto, Project>();

            CreateMap<Project, ProjectResponseDto>();
        }
    }
}
