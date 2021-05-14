using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class UserRepository : SQLGenericRepository<User>, IUserRepository
    {

        public UserRepository(ApplicationContext context) : base(context)
        {

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
            _db.Entry(user).State = EntityState.Modified;
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();

            return user;
        }
    }

}
