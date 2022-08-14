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
    public class AgendaController : ControllerBase
    {
        public IAgendaService _agendaService;

        public AgendaController(IAgendaService agendaService)
        {
            this._agendaService = agendaService;
        }

        // GET: api/<AgendaController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AgendaController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Agenda>>> Get(int id)
        {
            var response = await this._agendaService.GetAgenda(id);
            return response.Success == true ? Ok(response) : StatusCode(500, response);
        }

        // GET api/<AgendaController>/agendabyappointmentid/5
        [HttpGet("agendabyappointmentid/{id}")]
        public async Task<ActionResult<ServiceResponse<List<Agenda>>>> GetAgendaByAppointmentId(int id)
        {
            var response = await this._agendaService.GetAgendaByAppointmentId(id);
            return response.Success == true ? Ok(response) : StatusCode(500, response);
        }

        // GET api/<AgendaController>/agendabyappointmentid/5
        [HttpGet("list/{userId}")]
        public async Task<ActionResult<ServiceResponse<List<Agenda>>>> GetAgendaByUser(int userId)
        {
            var response = await this._agendaService.GetAgendaByUser(userId);
            return response.Success == true ? Ok(response) : StatusCode(500, response);
        }

        [HttpGet("agendaAvability/{userId}/{specialty}")]
        public async Task<ActionResult<ServiceResponse<bool>>> CheckAgendaBySpecialtyAndUser(int userId, string specialty)
        {
            var response = await this._agendaService.checkAgendaBySpecialtyAndUser(userId, specialty);
            return response.Success == true ? Ok(response) : StatusCode(500, response);
        }

        // POST api/<AgendaController>
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Agenda>>> Post([FromBody] Agenda agenda)
        {
            var response = await this._agendaService.AddAgenda(agenda);
            return response.Success == true ? Ok(response) : StatusCode(500, response);
        }

        // PUT api/<AgendaController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<Agenda>>>  Put([FromBody] Agenda agenda)
        {
            var response = await this._agendaService.UpdateAgenda(agenda);
            return response.Success == true ? Ok(response) : StatusCode(500, response);
        }

        // DELETE api/<AgendaController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<bool>>> Delete(int id)
        {
            var response = await this._agendaService.DeleteAgenda(id);
            return response.Success == true ? Ok(response) : StatusCode(500, response);
        }
    }
}
