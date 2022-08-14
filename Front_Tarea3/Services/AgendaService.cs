using Front_Tarea3.Helpers;
using Front_Tarea3.Interfaces;
using Front_Tarea3.Models;
using Newtonsoft.Json;
using System.Text;

namespace Front_Tarea3.Services
{
    public class AgendaService : IAgendaService
    {
        public static string _urlbase;
        HttpClient _httpClient = new HttpClient();

        public AgendaService()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _urlbase = builder.GetSection("ApiSettings:baseUrl").Value;

            this._httpClient.BaseAddress = new Uri(_urlbase);
            this._httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue($"Bearer", $"{TokenKeeper.Token}");
        }

        public async Task<ServiceResponse<Agenda>> AddAgenda(Agenda agenda)
        {
            var json = JsonConvert.SerializeObject(agenda);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/Agenda", content);
            var json_response = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ServiceResponse<Agenda>>(json_response);

            return result;
        }

        public async Task<ServiceResponse<List<Agenda>>> GetAgendaByUser(int UserId)
        {
            var response = await _httpClient.GetAsync("api/Agenda/list/" + UserId);
            var json_response = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject <ServiceResponse<List<Agenda>>>(json_response);

            return result;
        }

        public async Task<ServiceResponse<bool>> DeleteAgenda(int id)
        {
            var response = await _httpClient.DeleteAsync("api/Agenda/" + id);
            var json_response = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ServiceResponse<bool>>(json_response);

            return result;
        }

        public async Task<ServiceResponse<Agenda>> GetAgenda(int id)
        {
            var response = await _httpClient.GetAsync("api/Agenda/" + id);
            var json_response = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ServiceResponse<Agenda>>(json_response);

            return result;
        }

        public Task<ServiceResponse<Agenda>> GetAgendaByAppointmentId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Agenda>>> GetAllAgenda()
        {
            throw new NotImplementedException();
        }



        public Task<ServiceResponse<Agenda>> UpdateAgenda(Agenda agenda)
        {
            throw new NotImplementedException();
        }
    }
}
