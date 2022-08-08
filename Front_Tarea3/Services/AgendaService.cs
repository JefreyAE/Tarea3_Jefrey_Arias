using Front_Tarea3.Interfaces;
using Front_Tarea3.Models;

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
        }

        public Task<Agenda> AddAgenda(Agenda agenda)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAgenda(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Agenda> GetAgenda(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Agenda> GetAgendaByAppointmentId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Agenda>> GetAllAgenda()
        {
            throw new NotImplementedException();
        }

        public Task<Agenda> UpdateAgenda(Agenda agenda)
        {
            throw new NotImplementedException();
        }
    }
}
