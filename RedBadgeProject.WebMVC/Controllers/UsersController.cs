using Groomers.Services;
using Groonmers.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RedBadgeProject.WebMVC.CustomFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedBadgeProject.WebMVC.Controllers
{
    public class UsersController : Controller
    {
        [AuthLog(Roles = "User")]
        [Route("UserIndex")]
        public ActionResult UserIndex()
        {
            var service = CreateCustomerService();
            var model = service.GetCustomerHomePage(); 
            return View(model);
        }

        private CustomerService CreateCustomerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CustomerService(userId);
            return service;
        }

    }


    // GET: Users
    //public ActionResult Index()
    //{
    //    if (User.Identity.IsAuthenticated)
    //    {
    //        var user = User.Identity;
    //        ViewBag.Name = user.Name;

    //        ViewBag.displayMenu = "No";

    //        if (isAdminUser())
    //        {
    //            ViewBag.displayMenu = "Yes";
    //        }
    //        return View();
    //    }
    //    else
    //    {
    //        ViewBag.Name = "Not Logged In";
    //    }
    //    return View();
    //}

    //public bool isAdminUser()
    //{
    //    if (User.Identity.IsAuthenticated)
    //    {
    //        var user = User.Identity;
    //        ApplicationDbContext context = new ApplicationDbContext();

    //        var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

    //        var s = UserManager.GetRoles(user.GetUserId());

    //        if (s[0].ToString() == "Admin")
    //        {
    //            return true;
    //        }
    //        else
    //        {
    //            return false;
    //        }
    //    }
    //    return false; 
    //}
}