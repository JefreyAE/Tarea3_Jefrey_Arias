using Front_Tarea3.Helpers;
using Front_Tarea3.Interfaces;
using Front_Tarea3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Front_Tarea3.Controllers
{
    public class AgendaController : Controller
    {
        private IProtectionRoutesService _protectionRoute;
        private IAgendaService _agendaService;

        public AgendaController(IProtectionRoutesService protectionRoute, IAgendaService agendaService)
        {
            _protectionRoute = protectionRoute;
            _agendaService = agendaService;
        }

        // GET: AgendaController
        public async Task<ActionResult> Index()
        {
            if (!_protectionRoute.ProtectAction())
            {
                return RedirectToAction("Login", "Login");
            }
            List<Agenda> Model = null;
            try
            {
                var response =  await this._agendaService.GetAgendaByUser(TokenKeeper.User.Id);

                Model = response.Data;
            }
            catch (Exception ex)
            {
                ViewData["Message_error"] = ex.Message;
                return View();
            }

            return View(Model);
        }

        // GET: AgendaController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (!_protectionRoute.ProtectAction())
            {
                return RedirectToAction("Login", "Login");
            }

            try
            {
                var response = await this._agendaService.GetAgenda(id);
                return View(response.Data);
            }
            catch (Exception ex)
            {
                ViewData["Message_error"] = ex.Message;
                
                return RedirectToAction("Index", "Agenda");
            }
        }

        // GET: AgendaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AgendaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AgendaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AgendaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AgendaController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (!_protectionRoute.ProtectAction())
            {
                return RedirectToAction("Login", "Login");
            }

            try
            {
                var response = await this._agendaService.DeleteAgenda(id);
                
            }
            catch (Exception ex)
            {
                ViewData["Message_error"] = ex.Message;
                return View();
            }
            return RedirectToAction("Index", "Agenda");
        }

        // POST: AgendaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
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
