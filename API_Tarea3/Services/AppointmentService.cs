using API_Tarea3.DataContext;
using API_Tarea3.Helpers;
using API_Tarea3.Interfaces;
using API_Tarea3.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Tarea3.Services
{
    public class AppointmentService : IAppointmentService
    {
        public readonly AppDbContext appDbContext;

        public AppointmentService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }


        public async Task<ServiceResponse<Appointment>> AddAppointment(Appointment appointment)
        {
            var response = new ServiceResponse<Appointment>();

            try
            {
                await this.appDbContext.Appointments.AddAsync(appointment);
                await this.appDbContext.SaveChangesAsync();

                int lastId = this.appDbContext.Appointments.Max(a => a.Id);

                var saved = await this.appDbContext.Appointments.FirstOrDefaultAsync(s => s.Id == lastId);
                response.Data = saved;
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ServiceResponse<bool>> DeleteAppointment(int id)
        {
            var response = new ServiceResponse<bool>();

            try
            {
                var appointment = await this.appDbContext.Appointments.FirstOrDefaultAsync(a => a.Id == id);

                if (appointment == null)
                {
                    response.Success = false;
                    response.Message = "Resource not found";
                }
                else
                {
                    this.appDbContext.Appointments.Remove(appointment);
                    await this.appDbContext.SaveChangesAsync();
                    response.Data = true;
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ServiceResponse<List<Appointment>>> GetAllAppointments()
        {
            var response = new ServiceResponse<List<Appointment>>();

            try
            {
                var appointment = await this.appDbContext.Appointments.Select(a => a).ToListAsync();
                response.Data = appointment;
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ServiceResponse<Appointment>> GetAppointment(int id)
        {
            var response = new ServiceResponse<Appointment>();

            try
            {
                var appointment = await this.appDbContext.Appointments.FirstOrDefaultAsync(a => a.Id == id);
                response.Data = appointment;
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ServiceResponse<List<Appointment>>> GetAppointmentListByDate(DateTime dateTime)
        {
            var response = new ServiceResponse<List<Appointment>>();

            try
            {
                var appointment = await this.appDbContext.Appointments.Where(a => a.Appointment_date == dateTime).ToListAsync();
                response.Data = appointment;
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ServiceResponse<List<Appointment>>> GetAppointmentListByUserId(int userId)
        {
            var response = new ServiceResponse<List<Appointment>>();

            try
            {
                var appointment = await this.appDbContext.Appointments.Where(a => a.UserId == userId).ToListAsync();
                response.Data = appointment;
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ServiceResponse<Appointment>> UpdateAppointment(Appointment appointment)
        {
            var response = new ServiceResponse<Appointment>();

            try
            {
                if (appointment == null)
                {
                    response.Success = false;
                    response.Message = "Resource not found";
                }
                else
                {
                    this.appDbContext.Update(appointment);
                    await this.appDbContext.SaveChangesAsync();
                    response.Data = appointment;
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }
    }
}
