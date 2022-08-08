using Front_Tarea3.Models;

namespace Front_Tarea3.Interfaces
{
    public interface IAgendaService
    {
        Task<Agenda> GetAgenda(int id);
        Task<Agenda> UpdateAgenda(Agenda agenda);
        Task<bool> DeleteAgenda(int id);
        Task<Agenda> AddAgenda(Agenda agenda);
        Task<List<Agenda>> GetAllAgenda();
        Task<Agenda> GetAgendaByAppointmentId(int id);
    }
}
