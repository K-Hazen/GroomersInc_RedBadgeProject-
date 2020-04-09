using Groomers.Models;
using Groomers.Services;
using Groonmers.Data;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedBadgeProject.WebMVC.Controllers
{
    public class SearchDateController : Controller
    {
        //private CustomerService CreateSearchSearvice()
        //{
        //    var userId = Guid.Parse(User.Identity.GetUserId());
        //    var service = new CustomerService(userId);
        //    return service; 
        //}

        // POST: SearchDate
        [ActionName("SearchDate")]
        public ActionResult SearchDate()
        {
            return View();
        }

        [HttpPost]
        [ActionName("SearchDate")]    
        public ActionResult SearchDate(SearchDatePV model)
        {
            if (!ModelState.IsValid) return View(model);

           // var something = new CustomerListItem()
  

            var service = new AppointmentService(); 

            if (service.GetAppointmentByDate(model.SearchDate) != null)
            {
                TempData["SaveResult"] = "Here are the available appointments for that date";

                return RedirectToAction("Appointment/SelectAppointmentDate");
            }

            ModelState.AddModelError("", "Your date was invalid");
            return View(model);

        }



    }
}