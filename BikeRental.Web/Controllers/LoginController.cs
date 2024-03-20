using BikeRental.BusinessLogic.Interfaces;
using BikeRental.BusinessLogic;
using BikeRental.Domain.Entities.User;
using BikeRental.Web.Models;
using System.Web.Mvc;

public class LoginController : Controller
{
    private readonly ISession _session;

    public LoginController()
    {
        var bl = new BusinessLogic();
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
                return View();
            }
        }

        // Redirect to home page if model state is not valid (e.g., missing fields)
        return RedirectToAction("Index", "Home");
    }
}
