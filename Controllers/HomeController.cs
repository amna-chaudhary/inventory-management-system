using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCPro.Models; // Make sure this matches your actual namespace

namespace MVCPro.Controllers
{
    public class HomeController : Controller
    {
        private MVCProEntities db = new MVCProEntities();

        public ActionResult Index()
        {
            if (!db.Users.Any())
            {
                return RedirectToAction("Register", "Account");
            }

            return RedirectToAction("Login", "Account");
        }
    }
}
