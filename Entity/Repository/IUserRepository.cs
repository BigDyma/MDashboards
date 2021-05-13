using System.Collections.Generic;

namespace Entity
{
    interface IUserRepository : ISQLGenericRepository<User>
    {
        IEnumerable<User> GetAdultUsers();
    }
}