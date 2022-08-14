using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Front_Tarea3.Helpers;
using Front_Tarea3.Models;
using Front_Tarea3.Interfaces;

namespace Front_Tarea3.Controllers
{
    public class AppointmentController : Controller
    {
        private IProtectionRoutesService _protectionRoute;
        private IAppointmentService _appointmentService;
        private IAgendaService _agendaService;

        public AppointmentController(IProtectionRoutesService protectionRoute, IAppointmentService appointmentService, IAgendaService agendaService)
        {
            _protectionRoute = protectionRoute;
            _appointmentService = appointmentService;
            _agendaService = agendaService;
        }

        // GET: AppointmentController
        public ActionResult Index()
        {
            if (!_protectionRoute.ProtectAction())
            {
                return RedirectToAction("Login", "Login");
            }
            return View();
        }
       
        // GET: AppointmentController/Details/5
        public ActionResult Details(int id)
        {
            if (!_protectionRoute.ProtectAction())
            {
                return RedirectToAction("Login", "Login");
            }
            return View();
        }

        // GET: AppointmentController/Create
        public ActionResult Create()
        {
            if (!_protectionRoute.ProtectAction())
            {
                return RedirectToAction("Login", "Login");
            }

            ViewData["item"] = TokenKeeper.Token.ToString();
            ViewData["id"] = TokenKeeper.User.Id.ToString();
            ViewData["name"] = TokenKeeper.User.Name;

            return View();
        }

        // POST: AppointmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                User user = TokenKeeper.User;
                Appointment appointment = new Appointment();
                
                appointment.Appointment_date = Convert.ToDateTime(collection["Appointment_date"]);

                var responsev = await this._appointmentService.GetAppointmentListByDateAndUserId(appointment, collection["Specialty"], user.Id);

                var response0 = await this._appointmentService.GetAppointmentByDate(appointment);

                ServiceResponse<Appointment> response1 = null;

                if (response0.Data != null)
                {
                    response1 = response0;
                }
                else
                {
                    appointment.Created_at = DateTime.Now;
                    response1 = await this._appointmentService.AddAppointment(appointment);
                }     

                Agenda agenda = new Agenda();
                agenda.AppointmentId = response1.Data.Id;
                agenda.Hour = Convert.ToInt32(collection["Hour"]);
                agenda.Specialty = collection["Specialty"];
                agenda.UserId = user.Id;
                agenda.State = "Activa";

                var response2 = await this._agendaService.AddAgenda(agenda);

                if (response1.Success == true && response2.Success == true)
                {
                    ViewData["item"] = TokenKeeper.Token.ToString();
                    ViewData["id"] = TokenKeeper.User.Id.ToString();
                    ViewData["Message_success"] = "Registro efectuado correctamente.";
                    ViewData["name"] = TokenKeeper.User.Name;

                    return RedirectToAction("Details", "Agenda", new { id = response2.Data.Id });
                    return View();
                }
                else
                {
                    ViewData["item"] = TokenKeeper.Token.ToString();
                    ViewData["id"] = TokenKeeper.User.Id.ToString();
                    ViewData["Message_error"] = "Ocurrio un error al realizar el registro.";
                    ViewData["name"] = TokenKeeper.User.Name;
                    return View();
                }

            }
            catch (Exception ex)
            {
                ViewData["Message_error"] = ex.Message;
                return View();
            }
        }

        // GET: AppointmentController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_protectionRoute.ProtectAction())
            {
                return RedirectToAction("Login", "Login");
            }
            return View();
        }

        // POST: AppointmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            if (!_protectionRoute.ProtectAction())
            {
                return RedirectToAction("Login", "Login");
            }
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AppointmentController/Delete/5
        public ActionResult Delete(int id)
        {
            if (!_protectionRoute.ProtectAction())
            {
                return RedirectToAction("Login", "Login");
            }
            return View();
        }

        // POST: AppointmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            if (!_protectionRoute.ProtectAction())
            {
                return RedirectToAction("Login", "Login");
            }
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
