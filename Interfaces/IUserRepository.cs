using CRUD.Models;
using System.Collections.Generic;

namespace CRUD.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUser(int id);
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(UserDto userdto, int id);
        Task<bool> DeleteUser(int id);
    }
}
