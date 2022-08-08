using Front_Tarea3.Interfaces;
using Front_Tarea3.Models;
using System.Text;
using Newtonsoft.Json;

namespace Front_Tarea3.Services
{
    public class UserService : IUserService
    {
        private static string _urlbase;
        HttpClient _httpClient = new HttpClient();

        public UserService()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _urlbase = builder.GetSection("ApiSettings:baseUrl").Value;

            this._httpClient.BaseAddress = new Uri(_urlbase);
        }

        public Task<User> AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> LoginUser(int userId, DateTime birthday)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
