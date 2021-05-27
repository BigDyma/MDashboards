using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Models
{
    public class CSVFile: EntityBase
    {
        public string FileName { get; set; }

        public string Content { get; set; }

        public long UserId { get; set; }

        public User user { get; set; }
    }
}
