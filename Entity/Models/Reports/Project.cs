using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Models
{
    public class Project: EntityBase
    {
        public string Name { get; set; }
        public uint ReportId { get; set; }
        public ICollection<Report> Reports { get; set; }

        public virtual uint UserId { get; set; }
        public virtual User User { get; set; }
    }
}
