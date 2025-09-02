using CRUD.Models;
using CRUD.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Services
{
    public class UserService : IUserService
    {
        readonly private IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _repository.GetAllUsers();
        }

        public async Task<User> GetUser(int id)
        {
            if (id > 0)
            {
                return await _repository.GetUser(id);
            }
            return null;
        }
        
        public async Task<User> CreateUser(User user)
        {
            return await _repository.CreateUser(user);
        }

        public async Task<User> UpdateUser(UserDto userdto, int id)
        {
            return await _repository.UpdateUser(userdto, id);
        }

        public async Task<bool> DeleteUser(int id)
        {
            return await _repository.DeleteUser(id);
        }

    }
}