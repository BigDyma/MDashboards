using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Models
{
    public class Project: EntityBase
    {
        public string Name { get; set; }
        public ICollection<Report> Reports { get; set; }

        public virtual long UserId { get; set; }
        public virtual User User { get; set; }
    }
}
