using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    class UserRepository : SQLGenericRepository<User>
    {
        public UserRepository(ApplicationContext context) : base(context)
        {

        }
      
    }

}
