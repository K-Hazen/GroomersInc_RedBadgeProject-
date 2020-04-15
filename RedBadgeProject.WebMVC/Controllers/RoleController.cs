using Groonmers.Data;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RedBadgeProject.WebMVC.Controllers
{
   
    public class RoleController : Controller
    {

        ApplicationDbContext context;

        public RoleController()
        {
            context = new ApplicationDbContext();
        }

        // GET: All Roles
        [Authorize(Roles = "Admin")]
        [Route("Admin/Role/Index")]
        public ActionResult Index()
        {
            var Roles = context.Roles.ToList();
            return View(Roles);
        }

        //Create a new role
        [Authorize(Roles = "Admin")]
        [Route("Admin/Role/Create")]
        public ActionResult Create()
        {
            var Role = new IdentityRole();
            return View(Role);
        }

        //Create a New role
        //<param name = "Role"> </param>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("Admin/Role/Create")]
        public ActionResult Create(IdentityRole role)
        {
            context.Roles.Add(role);
            context.SaveChanges();
            TempData["SaveResult"] = "Your role was created.";
            return RedirectToAction("AdminIndex", "Admin");
        }
    }
}