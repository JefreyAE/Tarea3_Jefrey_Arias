using Front_Tarea3.Helpers;
using Front_Tarea3.Interfaces;
using Front_Tarea3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Front_Tarea3.Controllers
{
    public class LoginController : Controller
    {
        public ILoginService _loginservice;
        
        public LoginController(ILoginService loginService)
        {
            this._loginservice = loginService;
        }

        // GET: LoginController
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(IFormCollection collection)
        {
            try
            {          
                User user = new User();
                user.UserId = Convert.ToInt32(collection["UserId"]);
                user.Birthday = Convert.ToDateTime(collection["Birthday"]);

                TokenKeeper.Token = await this._loginservice.LoginUser(user);
                return RedirectToAction("Create", "Appointment");
            }
            catch(Exception ex)
            {
                var x = ex.Message;
                return View();
            }
        }

        // GET: LoginController/Logout
        public ActionResult Logout()
        {
            TokenKeeper.Token = null;
            return RedirectToAction("Index", "Login");
        }

        // GET: LoginController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LoginController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginController/Create
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

        // GET: LoginController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LoginController/Edit/5
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

        // GET: LoginController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoginController/Delete/5
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
