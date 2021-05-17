using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model.Dto.Reports
{
    public class ReportResponseDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
