using API_Tarea3.Helpers;
using API_Tarea3.Models;

namespace API_Tarea3.Interfaces
{
    public interface IAppointmentService
    {
        Task<ServiceResponse<Appointment>> GetAppointment(int id);
        Task<ServiceResponse<Appointment>> UpdateAppointment(Appointment appointment);
        Task<ServiceResponse<bool>> DeleteAppointment(int id);
        Task<ServiceResponse<Appointment>> AddAppointment(Appointment appointment);
        Task<ServiceResponse<List<Appointment>>> GetAllAppointments();
        Task<ServiceResponse<List<Appointment>>> GetAppointmentListByUserId(int userId);
        Task<ServiceResponse<List<Appointment>>> GetAppointmentListByDate(DateTime dateTime);
    }
}
