using API_Tarea3.Helpers;
using API_Tarea3.Interfaces;
using API_Tarea3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Tarea3.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserService _userService;
        public IConfiguration _configuration;

        public UserController(IConfiguration config, IUserService userService)
        {
            _configuration = config;
            _userService = userService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<User>>> Get(int id)
        {
            var response = await this._userService.GetUser(id);
            return response.Success == true ? Ok(response) : StatusCode(500, response);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<User>>> Post([FromBody] User user)
        {
            var response = await this._userService.AddUser(user);
            return response.Success == true ? Ok(response) : StatusCode(500, response);
        }

        // PUT api/<UserController>/
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<User>>> Put([FromBody] User user)
        {
            var response = await this._userService.UpdateUser(user);
            return response.Success == true ? Ok(response) : StatusCode(500, response);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<bool>>> Delete(int id)
        {
            var response = await this._userService.DeleteUser(id);
            return response.Success == true ? Ok(response) : StatusCode(500, response);
        }
    }
}
