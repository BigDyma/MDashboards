using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model.Dto.Reports
{
    public class ReportCreateDto
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public long ProjectId { get; set; }
    }
}
