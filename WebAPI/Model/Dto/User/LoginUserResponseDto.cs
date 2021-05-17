using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model.Dto.User
{
    public class LoginUserResponseDto
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
    }
}
