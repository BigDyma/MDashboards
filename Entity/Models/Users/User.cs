using Entity.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class User : IdentityUser<long>
    {
        [MaxLength(32)]
        [Required]
        public string FullName { get; set; }

        [MaxLength(320)]
        [EmailAddress]
        public override string Email { get; set; }

        [Required]
        public DateTime DOB { get; set; }
        public string RegisterTimestamp { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
