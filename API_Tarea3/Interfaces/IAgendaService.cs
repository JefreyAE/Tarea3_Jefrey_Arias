using API_Tarea3.Helpers;
using API_Tarea3.Models;

namespace API_Tarea3.Interfaces
{
    public interface IAgendaService
    {
        Task<ServiceResponse<Agenda>> GetAgenda(int id);
        Task<ServiceResponse<Agenda>> UpdateAgenda(Agenda agenda);
        Task<ServiceResponse<bool>> DeleteAgenda(int id);
        Task<ServiceResponse<Agenda>> AddAgenda(Agenda agenda);
        Task<ServiceResponse<List<Agenda>>> GetAllAgenda();
        Task<ServiceResponse<List<Agenda>>> GetAgendaByUser(int userId);
        Task<ServiceResponse<Agenda>> GetAgendaByAppointmentId (int id);
        Task<ServiceResponse<bool>> checkAgendaBySpecialtyAndUser(int userId, string specialty);

    }
}
