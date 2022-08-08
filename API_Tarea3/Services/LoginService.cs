using API_Tarea3.DataContext;
using API_Tarea3.Helpers;
using API_Tarea3.Interfaces;
using API_Tarea3.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Tarea3.Services
{
    public class LoginService:ILoginService
    {
        public readonly AppDbContext appDbContext;

        public LoginService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<ServiceResponse<User>> LoginUser(int userId, DateTime birthday)
        {
            var response = new ServiceResponse<User>();

            try
            {
                if (userId == null || birthday == null)
                {
                    response.Success = false;
                    response.Message = "Resource not found";
                }
                else
                {
                    var result = await this.appDbContext.Users.FirstOrDefaultAsync(u => u.UserId == userId && u.Birthday == birthday);
                    if (result == null)
                    {
                        response.Data = null;
                        response.Success = false;
                        response.Message = "Resource not found";
                    }
                    else
                    {
                        response.Data = result;
                    }
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
