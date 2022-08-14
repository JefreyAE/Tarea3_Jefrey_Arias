using API_Tarea3.DataContext;
using API_Tarea3.Helpers;
using API_Tarea3.Interfaces;
using API_Tarea3.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Tarea3.Services
{
    public class AgendaService : IAgendaService
    {
        public readonly AppDbContext appDbContext;

        public AgendaService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<ServiceResponse<Agenda>> AddAgenda(Agenda agenda)
        {
            var response = new ServiceResponse<Agenda>();

            try
            {
                await this.appDbContext.Agendas.AddAsync(agenda);
                await this.appDbContext.SaveChangesAsync();

                var saved = await this.appDbContext.Agendas.FirstOrDefaultAsync(a => a.AppointmentId == agenda.AppointmentId);
                response.Data = saved;

                return response;
            }catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ServiceResponse<bool>> DeleteAgenda(int id)
        {
            var response = new ServiceResponse<bool>();

            try
            {
                var agenda = await this.appDbContext.Agendas.FirstOrDefaultAsync(a => a.Id == id);

                if(agenda == null)
                {
                    response.Success = false;
                    response.Message = "Resource not found";
                }
                else
                {
                    this.appDbContext.Agendas.Remove(agenda);
                    await this.appDbContext.SaveChangesAsync();
                    response.Data = true;
                }
                return response;
            }catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ServiceResponse<Agenda>> GetAgenda(int id)
        {
            var response = new ServiceResponse<Agenda>();

            try
            {
                var agenda = await this.appDbContext.Agendas.FirstOrDefaultAsync(a => a.Id == id);
                agenda.Appointment = await this.appDbContext.Appointments.FirstOrDefaultAsync(a => a.Id == agenda.AppointmentId);
                response.Data = agenda;
                return response;
            }catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ServiceResponse<bool>> checkAgendaBySpecialtyAndUser(int userId, string specialty)
        {
            var response = new ServiceResponse<bool>();

            try
            {
                var agenda = await this.appDbContext.Agendas.Where(a => a.UserId == userId && a.Specialty == specialty && a.State == "Activa").ToListAsync();
                if(agenda.Count() > 0)
                {
                    response.Data = true;
                    return response;
                }
                    response.Data = false;
                    response.Success = false;
                    response.Message = "Data not found";
                    return response; 
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ServiceResponse<Agenda>> GetAgendaByAppointmentId(int id)
        {
            var response = new ServiceResponse<Agenda>();

            try
            {
                var agenda = await this.appDbContext.Agendas.FirstOrDefaultAsync(a => a.AppointmentId == id);
                response.Data = agenda;
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ServiceResponse<List<Agenda>>> GetAgendaByUser(int userId)
        {
            var response = new ServiceResponse<List<Agenda>> ();
            try
            {
                var agendas = await this.appDbContext.Agendas
                    .Where(a => a.UserId == userId)
                    .ToListAsync();
                foreach(Agenda agenda in agendas)
                {
                    agenda.Appointment = await this.appDbContext.Appointments.FirstOrDefaultAsync(a => a.Id == agenda.AppointmentId);
                }
                response.Data = agendas;
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ServiceResponse<List<Agenda>>> GetAllAgenda()
        {
            var response = new ServiceResponse<List<Agenda>>();

            try
            {
                var agenda = await this.appDbContext.Agendas.Select(a => a).ToListAsync();
                response.Data = agenda;
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ServiceResponse<Agenda>> UpdateAgenda(Agenda agenda)
        {
            var response = new ServiceResponse<Agenda>();

            try
            {
                if (agenda == null)
                {
                    response.Success = false;
                    response.Message = "Resource not found";
                }
                else
                {
                    this.appDbContext.Agendas.Update(agenda);
                    await this.appDbContext.SaveChangesAsync();
                    response.Data = agenda;
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
