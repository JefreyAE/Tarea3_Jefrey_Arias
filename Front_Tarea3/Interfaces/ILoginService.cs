using Front_Tarea3.Models;

namespace Front_Tarea3.Interfaces
{
    public interface ILoginService
    {
        Task<String> LoginUser(User user);
    }
}
