using System.Web.Mvc;
using BikeRental.BusinessLogic;
using BikeRental.BusinessLogic.Interfaces;
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
            return View(new UserLogin());
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
                    Credentials = login.Credentials,
                    Password = login.Password
                };

                var userLogin = _session.UserLogin(data);

                if (userLogin.Status)
                {
                    // Successful login, redirect to Home/Index
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            // Model state is invalid, return to the login page
            return RedirectToAction("Index", "Home");
        }
    }
}