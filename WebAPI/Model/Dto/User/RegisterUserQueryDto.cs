using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model.Dto
{
    public class RegisterUserQueryDto 
    {
        [MaxLength(32)]
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        [MaxLength(320)]
        [EmailAddress]
        public string Email { get; set; }
    }
}
