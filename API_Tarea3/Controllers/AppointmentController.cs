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
    public class AppointmentController : ControllerBase
    {
        public IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        // GET: api/<AppointmentController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AppointmentController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Appointment>>> Get(int id)
        {
            var response = await this._appointmentService.GetAppointment(id);
            return response.Success == true ? Ok(response) : StatusCode(500, response);
        }

        // GET api/<AppointmentController>/allappointments
        [HttpGet("allappointments")]
        public async Task<ActionResult<ServiceResponse<List<Appointment>>>> GetAllAppointments()
        {
            var response = await this._appointmentService.GetAllAppointments();
            return response.Success == true ? Ok(response) : StatusCode(500, response);
        }

        // GET api/<AppointmentController>/appointmentsbyuser/5
        [HttpGet("appointmentsbyuser/{userId}")]
        public async Task<ActionResult<ServiceResponse<List<Appointment>>>> GetAppointmentsByUser(int userId)
        {
            var response = await this._appointmentService.GetAppointmentListByUserId(userId);
            return response.Success == true ? Ok(response) : StatusCode(500, response);
        }

        // GET api/<AppointmentController>/appointmentsbydate/5
        [HttpGet("appointmentsbydate/{appDate}")]
        public async Task<ActionResult<ServiceResponse<List<Appointment>>>> GetAppointmentsByDate(DateTime appDate)
        {
            var response = await this._appointmentService.GetAppointmentListByDate(appDate);
            return response.Success == true ? Ok(response) : StatusCode(500, response);
        }

        // POST api/<AppointmentController>
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Appointment>>> Post([FromBody] Appointment appointment)
        {
            var response = await this._appointmentService.AddAppointment(appointment);
            return response.Success == true ? Ok(response) : StatusCode(500, response);
        }

        // PUT api/<AppointmentController>/5
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<Appointment>>> Put([FromBody] Appointment appointment)
        {
            var response = await this._appointmentService.UpdateAppointment(appointment);
            return response.Success == true ? Ok(response) : StatusCode(500, response);
        }

        // DELETE api/<AppointmentController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<bool>>> Delete(int id)
        {
            var response = await this._appointmentService.DeleteAppointment(id);
            return response.Success == true ? Ok(response) : StatusCode(500, response);
        }
    }
}
