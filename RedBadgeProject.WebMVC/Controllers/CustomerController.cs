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
    [Authorize]
    public class CustomerController : Controller
    {
        private ApplicationDbContext _dB = new ApplicationDbContext();


        // GET: Customer

        [Authorize(Roles = "User")]
        [Route("User/Customer/Index")]
        public ActionResult Index()
        {
            var service = CreateCustomerService();
            var model = service.GetCustomers();
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [Route("Admin/Customer/AdminCustomerList")]
        public ActionResult AdminCustomerList()
        {
            var service = CreateCustomerService();
            var model = service.GetCustomersAdminOnly();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(CustomerCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCustomerService();

            if (service.CreateCustomer(model))
            {
                TempData["SaveResult"] = "Your profile was created.";
                return RedirectToAction("UserIndex", "Users");
            }

            ModelState.AddModelError("", "Your profile could not be created");

            return View(model);
        }

      
        public ActionResult Details(int id)
        {
            var service = CreateCustomerService();
            var model = service.GetCustomerById(id);

            //ViewBag.PetID = new SelectList(model.Pets, "PetID", "Name");
            return View(model);
        }

      
        public ActionResult Edit(int id)
        {
            var service = CreateCustomerService();
            var detail = service.GetCustomerById(id);
            var model =
                new CustomerEdit
                {
                    PersonID = detail.PersonID,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    StreetAddress = detail.StreetAddress,
                    City = detail.City,
                    State = detail.State,
                    ZipCode = detail.ZipCode,
                    PhoneNumber = detail.PhoneNumber,
                    Email = detail.Email,
                };

            return View(model); 
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(int id, CustomerEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PersonID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateCustomerService();

            if (service.UpdateCustomer(model))
            {
                TempData["SaveResult"] = "Your profile has been updated.";
                return RedirectToAction("UserIndex", "Users");
            }

            ModelState.AddModelError("", "Your profile could not be updated.");
            return View(model); 
        }

        [ActionName("Delete")]

        public ActionResult Delete(int id)
        {
            var service = CreateCustomerService();
            var model = service.GetCustomerById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCustomerService();

            service.DeleteCustomer(id);

            TempData["SaveResult"] = "Your profile was deleted";

            return RedirectToAction("Index");
        }
            

        //helper method
        private CustomerService CreateCustomerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CustomerService(userId);
            return service;
        }
    }
}