using Entity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Entity
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByUserName(string username);

        Task<User> GetByEmail(string email);

        Task<User> CreateUser(User user);
        Task<User> SingleUserNameAndEmail(string username, string email);
        Task DeleteUser(long id);

        Task<ICollection<Project>> GetProjects(long id);
    }
}