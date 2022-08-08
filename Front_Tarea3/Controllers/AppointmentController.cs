using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Front_Tarea3.Helpers;

namespace Front_Tarea3.Controllers
{
    public class AppointmentController : Controller
    {
        private IProtectionRoutesService _protectionRoute;

        public AppointmentController(IProtectionRoutesService protectionRoute)
        {
            _protectionRoute = protectionRoute;
        }

        // GET: AppointmentController
        public ActionResult Index()
        {
            if (!_protectionRoute.ProtectAction())
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
       
        // GET: AppointmentController/Details/5
        public ActionResult Details(int id)
        {
            if (!_protectionRoute.ProtectAction())
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        // GET: AppointmentController/Create
        public ActionResult Create()
        {
            if (!_protectionRoute.ProtectAction())
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        // POST: AppointmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            if (!_protectionRoute.ProtectAction())
            {
                return RedirectToAction("Index", "Login");
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

        // GET: AppointmentController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_protectionRoute.ProtectAction())
            {
                return RedirectToAction("Index", "Login");
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
                return RedirectToAction("Index", "Login");
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
                return RedirectToAction("Index", "Login");
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
                return RedirectToAction("Index", "Login");
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
