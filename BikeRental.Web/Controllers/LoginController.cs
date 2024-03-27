using BikeRental.BusinessLogic.Interfaces;
using System.Web.Mvc;
using BikeRental.BusinessLogic;
using BikeRental.Domain.Entities.User;
using BikeRental.Web.Models;

namespace BikeRental.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly ISession _session;

        public LoginController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _session = bl.GetSessionBL();
        }

        // GET: Index
        public ActionResult Index()
        {
            return View();
        }

        // GET: Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: Register
        [HttpPost]
        public ActionResult Register(ULoginData register)
        {
            if (ModelState.IsValid)
            {
                ULoginData data = new ULoginData
                {
                    Username = register.Username,
                    Email = register.Email,
                    Password = register.Password
                };

                var userRegister = _session.UserRegister(data);

                if (userRegister.Status)
                {
                    // Redirect to login page after successful registration
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    ModelState.AddModelError("error", "Registration failed");
                    return View(register);
                }
            }

            return View(register);
        }

        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin login)
        {
            if (ModelState.IsValid)
            {
                ULoginData data = new ULoginData
                {
                    Username = login.Username,
                    Password = login.Password
                };

                var userLogin = _session.UserLogin(data);

                if (userLogin.Status)
                {
                    // Redirect to home page after successful login
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("error", "Invalid credentials");
                    return RedirectToAction("Index3", "Home");
                }
            }

            return View();
        }
    }
}
