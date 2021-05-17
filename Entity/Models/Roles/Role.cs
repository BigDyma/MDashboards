
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entity.Models
{
    public class Role: IdentityRole<long>
    {
        [MaxLength(32)]
        public string RoleName { get; set; } // Moderator, User, Customer?
        //public virtual ICollection<Permission> Permissions { get; set; }
    }
}
