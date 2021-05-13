using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Models.Users
{
    public class UserToken: IdentityUserToken<uint>
    {
    }
}
