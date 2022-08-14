using Front_Tarea3.Interfaces;
using Front_Tarea3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Front_Tarea3.Controllers
{
    public class UserController : Controller
    {
        IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: UserController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                User user = new User();
                user.Name = collection["Name"];
                user.UserId = Convert.ToInt32(collection["UserId"]);
                user.Birthday = Convert.ToDateTime(collection["Birthday"]);
                user.Payment_method = collection["Payment_method"];

                DateTime dateNow = DateTime.Now;

                int yearsAge = (dateNow - user.Birthday).Days/365;

                if(yearsAge <= 15)
                {
                    ViewData["Message_error"] = "No cuenta con la edad requerida para registrarse en el sistema. ( 15 años ).";
                    return View();
                }

                var response = await this._userService.AddUser(user);
                if (response != null)
                {
                    if (response.Success == true)
                    {
                        ViewData["Message_success"] = "El registro se ha efectuado correctamente.";
                        return View();
                    }
                    else
                    {
                        ViewData["Message_error"] = response.Message;
                        return View();
                    }
                }
                ViewData["Message_error"] = "Ocurrio un error al registrarse.";
                return View();

            }
            catch (Exception ex)
            {
                ViewData["Message_error"] = "Ocurrio un error al registrarse.";
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
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

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
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
