using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model.Dto.Projects
{
    public class ProjectCreateDto
    {
        public long UserId { get; set; }
        public string Name { get; set; }
    }
}
