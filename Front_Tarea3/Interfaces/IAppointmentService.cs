using Front_Tarea3.Models;

namespace Front_Tarea3.Interfaces
{
    public interface IAppointmentService
    {
        Task<Appointment> GetAppointment(int id);
        Task<Appointment> UpdateAppointment(Appointment appointment);
        Task<bool> DeleteAppointment(int id);
        Task<Appointment> AddAppointment(Appointment appointment);
        Task<List<Appointment>> GetAllAppointments();
        Task<List<Appointment>> GetAppointmentListByUserId(int userId);
        Task<List<Appointment>> GetAppointmentListByDate(DateTime dateTime);
    }
}
