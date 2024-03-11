﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            return View();
        }

        // POST: Login
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

                if (userLogin.Status) { 
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("error", "Invalid data");
    
                    return RedirectToAction("Index", "Home");
                }
            }

            return RedirectToAction("Index");
        }
    }
}