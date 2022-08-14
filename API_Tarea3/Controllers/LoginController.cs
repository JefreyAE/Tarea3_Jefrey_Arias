using API_Tarea3.Helpers;
using API_Tarea3.Interfaces;
using API_Tarea3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Tarea3.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public ILoginService _loginService;
        public IConfiguration _configuration;

        public LoginController(IConfiguration config, ILoginService loginService)
        {
            _configuration = config;
            _loginService = loginService;
        }

        // POST api/login
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<User>>> Login(User user)
        {
            var response = await this._loginService.LoginUser(user.UserId, user.Birthday);
            return response.Success == true ? Ok(response) : StatusCode(500, response);
        }
    }
}
