using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Models
{
    public class Report: EntityBase
    {
        public string Name { get; set; }
        public string ProjectName { get; set; }
        public string Link { get; set; }
        public DateTime CreatedTime { get; set; }

        public long ProjectId { get; set; }
        public Project Projects { get; set; }
    }
}
