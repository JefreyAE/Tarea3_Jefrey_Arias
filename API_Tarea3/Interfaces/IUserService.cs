using API_Tarea3.Helpers;
using API_Tarea3.Models;

namespace API_Tarea3.Interfaces
{
    public interface IUserService
    {
        Task<ServiceResponse<User>> GetUser(int id);
        Task<ServiceResponse<User>> UpdateUser(User user);
        Task<ServiceResponse<bool>> DeleteUser(int id);
        Task<ServiceResponse<User>> AddUser(User user);

    }
}
