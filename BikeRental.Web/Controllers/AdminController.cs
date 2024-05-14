using System.Web.Mvc;
using BikeRental.Domain.Entities.User;
using BikeRental.Domain.Enums;
using BikeRental.Web.Services;
using BikeRental.Web.Extension;
using BikeRental.Web.Models.Admin;
using BikeRental.Web.Services;

namespace BikeRental.Web.Controllers
{
    public class AdminController : BaseController
    {
        private readonly UserService _userService;

        public AdminController() : base()
        {
            _userService = new UserService();
        }

        // GET: Admin
        public ActionResult Index()
        {
            SessionStatus();

            if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
            {
                return RedirectToAction("Index", "Login");
            }

            if (System.Web.HttpContext.Current.GetMySessionObject().Level != UserRole.Admin)
            {
                return new HttpStatusCodeResult(403, "Forbidden");
            }

            return View();
        }

        public ActionResult UsersList()
        {
            var users = _userService.GetAllUsers();

            return View(users);
        }


        public ActionResult UserEdit(int id)
        {
            var user = _userService.GetById(id);

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserEdit(int id, UserEdit userEdit)
        {
            var user = _userService.UpdateUser(id, userEdit);

            return View(user);
        }

    }
}