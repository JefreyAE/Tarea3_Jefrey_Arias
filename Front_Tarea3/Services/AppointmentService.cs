using Front_Tarea3.Interfaces;
using Front_Tarea3.Models;
using System.Text;
using Newtonsoft.Json;

namespace Front_Tarea3.Services
{
    public class AppointmentService : IAppointmentService
    {
        public static string _urlbase;
        HttpClient _httpClient = new HttpClient();

        public AppointmentService()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _urlbase = builder.GetSection("ApiSettings:baseUrl").Value;

            this._httpClient.BaseAddress = new Uri(_urlbase);
        }

        public Task<Appointment> AddAppointment(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAppointment(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Appointment>> GetAllAppointments()
        {
            throw new NotImplementedException();
        }

        public Task<Appointment> GetAppointment(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Appointment>> GetAppointmentListByDate(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public Task<List<Appointment>> GetAppointmentListByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<Appointment> UpdateAppointment(Appointment appointment)
        {
            throw new NotImplementedException();
        }
    }
}
