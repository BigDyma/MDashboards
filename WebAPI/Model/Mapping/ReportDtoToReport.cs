using AutoMapper;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model.Dto.Reports;

namespace WebAPI.Model.Mapping
{
    public class ReportDtoToReport : Profile
    {
        public ReportDtoToReport() 
        {
            CreateMap<ReportUpdateDto, Report>();

            CreateMap<Report, ReportResponseDto>();

            CreateMap<ReportCreateDto, Report>();

        }
    }
}
