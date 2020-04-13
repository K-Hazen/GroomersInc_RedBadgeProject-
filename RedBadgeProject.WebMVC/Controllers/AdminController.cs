using RedBadgeProject.WebMVC.CustomFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedBadgeProject.WebMVC.Controllers
{
    public class AdminController : Controller
    {
        [AuthLog(Roles = "Admin")]
        [Route ("AdminIndex")]
        // GET: Admin
        public ActionResult AdminIndex()
        {
            return View();
        }
    }
}