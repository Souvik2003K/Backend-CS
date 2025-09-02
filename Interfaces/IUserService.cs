using CRUD.Models;


namespace CRUD.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUser(int id);
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(UserDto userdto, int id);
        Task<bool> DeleteUser(int id);
    }
}
