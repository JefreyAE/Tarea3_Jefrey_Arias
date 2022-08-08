using Front_Tarea3.Models;

namespace Front_Tarea3.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUser(int id);
        Task<User> UpdateUser(User user);
        Task<bool> DeleteUser(int id);
        Task<User> AddUser(User user);
        Task<User> LoginUser(int userId, DateTime birthday);
    }
}
