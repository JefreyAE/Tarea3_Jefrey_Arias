using API_Tarea3.Helpers;
using API_Tarea3.Models;

namespace API_Tarea3.Interfaces
{
    public interface ILoginService
    {
        Task<ServiceResponse<User>> LoginUser(int userId, DateTime birthday);
    }
}
