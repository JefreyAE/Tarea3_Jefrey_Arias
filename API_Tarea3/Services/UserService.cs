using API_Tarea3.DataContext;
using API_Tarea3.Helpers;
using API_Tarea3.Interfaces;
using API_Tarea3.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Tarea3.Services
{
    public class UserService : IUserService
    {
        public readonly AppDbContext appDbContext;

        public UserService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<ServiceResponse<User>> AddUser(User user)
        {
            var response = new ServiceResponse<User>();

            try
            {
                await this.appDbContext.Users.AddAsync(user);
                await this.appDbContext.SaveChangesAsync();

                var saved = await this.appDbContext.Users.FirstOrDefaultAsync(u => u.UserId == user.UserId);
                response.Data = saved;

                return response;
            }catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ServiceResponse<bool>> DeleteUser(int id)
        {
            var response = new ServiceResponse<bool>();

            try
            {
                var user = await this.appDbContext.Users.FirstOrDefaultAsync(u => u.Id == id);

                if(user != null)
                {
                    response.Success = false;
                    response.Message = "Resource not found"; 
                }
                else
                {
                    this.appDbContext.Users.Remove(user);
                    await this.appDbContext.SaveChangesAsync();

                    response.Data = true;
                }
                return response;

            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }

        }

        public async Task<ServiceResponse<User>> GetUser(int id)
        {
            var response = new ServiceResponse<User>();

            try
            {
                var user = await this.appDbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
                response.Data = user;
                return response;
            }catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ServiceResponse<User>> UpdateUser(User user)
        {
            var response = new ServiceResponse<User>();

            try
            {
                if(user == null)
                {
                    response.Success = false;
                    response.Message = "Resource not found";
                }
                else
                {
                    this.appDbContext.Users.Update(user);
                    await this.appDbContext.SaveChangesAsync();
                    response.Data = user;
                }

                return response;
            }catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }
    }
}
