using Front_Tarea3.Interfaces;
using Front_Tarea3.Models;
using System.Text;
using Newtonsoft.Json;
using Front_Tarea3.Helpers;

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
            this._httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue($"Bearer", $"{TokenKeeper.Token}");
        }

        public async Task<ServiceResponse<Appointment>> AddAppointment(Appointment appointment)
        {
            var json = JsonConvert.SerializeObject(appointment);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            
            var response = await _httpClient.PostAsync("api/Appointment", content);
            var json_response = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ServiceResponse<Appointment>>(json_response);

            return result;
        }

        public async Task<ServiceResponse<String>> GetAppointmentListByDateAndUserId(Appointment appointment, string specialty, int UserId)
        {
            var json = JsonConvert.SerializeObject(appointment);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/Appointment/appointmentsListBydateUser/" + specialty+"/"+UserId, content);
            var json_response = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ServiceResponse<String>>(json_response);

            return result;
        }

        public async Task<ServiceResponse<Appointment>> GetAppointmentByDate(Appointment appointment)
        {
            var json = JsonConvert.SerializeObject(appointment);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/Appointment/appointmentByDate", content);
            var json_response = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ServiceResponse<Appointment>>(json_response);

            return result;
        }

        public async Task<ServiceResponse<bool>> DeleteAppointment(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<Appointment>>> GetAllAppointments()
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<Appointment>> GetAppointment(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<Appointment>>> GetAppointmentListByDate(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<Appointment>>> GetAppointmentListByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<Appointment>> UpdateAppointment(Appointment appointment)
        {
            throw new NotImplementedException();
        }
    }
}
