using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model.Dto.User
{
    public class UserResponseDto
    {
        public string FullName { get; set; }

        public string UserName { get; set; }

        public  string Email { get; set; }

        public string Phone { get; set; }

        public DateTime? DOB { get; set; }
    }
}
