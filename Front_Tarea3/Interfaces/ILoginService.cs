using Front_Tarea3.Helpers;
using Front_Tarea3.Models;

namespace Front_Tarea3.Interfaces
{
    public interface ILoginService
    {
        Task<ServiceResponse<User>> LoginUser(User user);
    }
}
