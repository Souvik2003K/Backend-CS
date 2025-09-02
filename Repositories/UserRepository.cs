using CRUD.Data;
using CRUD.Models;
using CRUD.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CRUD.Repositories
{
    public class UserRepository : IUserRepository
    {
        readonly private UserDbContext _context;
        public UserRepository(UserDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUser(int id)
        {
            return await _context.Users.FindAsync(id);

        }

        public async Task<User> CreateUser(User user)
        {
            var us = new User()
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password
            };

            await _context.Users.AddAsync(us);
            await _context.SaveChangesAsync();
            return us;
        }

        public async Task<User> UpdateUser(UserDto userdto, int id)
        {
            var result = await _context.Users.FindAsync(id);
            if (result == null) return null;

            result.Name = userdto.Name;
            result.Email = userdto.Email;
            result.Password = userdto.Password;

            _context.Users.Update(result);
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;

        }
    }
}
