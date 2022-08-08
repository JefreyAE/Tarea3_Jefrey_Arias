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

            try
            {
                if (response.Data != null)
                {
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("Id", response.Data.Id.ToString()),
                        new Claim("Name", response.Data.Name),
                        new Claim("UserId", response.Data.UserId.ToString()),
                        new Claim("Birthday", response.Data.Birthday.ToString())
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);
                    return response.Success == true ? Ok(new JwtSecurityTokenHandler().WriteToken(token)) : StatusCode(500, response);
                }
                else
                {
                    return StatusCode(500, response);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
