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

        public async Task<ServiceResponse<Appointment>> GetAppointmentByDate(DateTime dateTime)
        {
            var response = new ServiceResponse<Appointment>();

            try
            {
                var appointment = await this.appDbContext.Appointments.FirstOrDefaultAsync(a => a.Appointment_date == dateTime);
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

        public async Task<ServiceResponse<string>> GetAppointmentListByDateAndUserId(DateTime dateTime, string specialty, int UserId)
        {
            var response = new ServiceResponse<string>();

            try
            {
                var appointment = await this.appDbContext.Appointments.FirstOrDefaultAsync(a => a.Appointment_date == dateTime);

                if (appointment != null)
                {
                    List<Agenda> agendaList = await this.appDbContext.Agendas.Where(a => a.AppointmentId == appointment.Id).ToListAsync();

                    int cont8 = 0;
                    int cont9 = 0;
                    int cont10 = 0;
                    int cont11 = 0;
                    int cont1 = 0;
                    int cont2 = 0;
                    int cont3 = 0;
                    int cont4 = 0;


                    foreach (Agenda agenda in agendaList)
                    {
                        if (agenda.Hour == 8 && agenda.Specialty == specialty)
                        {
                            cont8++;
                        }
                        if (agenda.Hour == 9 && agenda.Specialty == specialty)
                        {
                            cont9++;
                        }
                        if (agenda.Hour == 10 && agenda.Specialty == specialty)
                        {
                            cont10++;
                        }
                        if (agenda.Hour == 11 && agenda.Specialty == specialty)
                        {
                            cont11++;
                        }
                        if (agenda.Hour == 1 && agenda.Specialty == specialty)
                        {
                            cont1++;
                        }
                        if (agenda.Hour == 2 && agenda.Specialty == specialty)
                        {
                            cont2++;
                        }
                        if (agenda.Hour == 3 && agenda.Specialty == specialty)
                        {
                            cont3++;
                        }
                        if (agenda.Hour == 4 && agenda.Specialty == specialty)
                        {
                            cont4++;
                        }
                    }
                    string availabilityHour = $"{cont8},{cont9},{cont10},{cont11},{cont1},{cont2},{cont3},{cont4}";

                    response.Data = availabilityHour;
                    return response;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Data not found.";
                    return response;
                }
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
                //var appointment = await this.appDbContext.Appointments.FirstOrDefault(a => (a.Agendas.Where(s => s.UserId == userId).ToList());
               // response.Data = appointment;
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
