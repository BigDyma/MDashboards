using Common.Exceptions;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Entity
{
    public class UserRepository : SQLGenericRepository<User>, IUserRepository
    {

        public UserRepository(ApplicationContext context) : base(context)
        {

        }

        public async Task DeleteUser(long id)
        {
            var res = await _db.Set<User>().FirstOrDefaultAsync(u => u.Id == id);
            if (res == null)
                throw new EntityNotFoundException("", "User doesn't exist!");
            await Delete(res);
        }
        public async Task<User> GetByUserName(string username)
        {
            return  await _db.Set<User>().FirstOrDefaultAsync(x => x.UserName == username);
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _db.Set<User>().FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User> SingleUserNameAndEmail(string username, string email)
        {
            var res =  await _db.Set<User>().FirstOrDefaultAsync(x => x.Email == email || x.UserName == username);

            return res;
        }
        public async Task<User> CreateUser(User user)
        {
           await base.Create(user);

            return user;
        }

        public async Task<ICollection<Project>> GetProjects(long id)
        {
            var res = await _db.Set<User>().FirstOrDefaultAsync(u => u.Id == id);

            return res?.Projects;
        }

        public async Task<ICollection<Report>> GetReports(long id)
        {
            var res = await _db.Set<User>().FirstOrDefaultAsync(u => u.Id == id);

           return res?.Projects.SelectMany(x => x.Reports, (a, b) => b).ToList();
        }
    }

}
