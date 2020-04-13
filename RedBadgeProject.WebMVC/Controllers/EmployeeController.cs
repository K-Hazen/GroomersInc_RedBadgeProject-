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
   
    public class EmployeeController : Controller
    {
        private ApplicationDbContext _dB = new ApplicationDbContext();

        // GET: Employee
        [Authorize(Roles = "Admin")]
        [Route("Admin/Employee/Index")]
        public ActionResult Index()
        {
            var service = CreateEmployeeService();
            var model = service.GetEmployees();
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [Route("Admin/Employee/Create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(EmployeeCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateEmployeeService();

            if (service.CreateEmployee(model))
            {
                TempData["SaveResult"] = "Your profile was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your profile could not be created");

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [Route("Admin/Employee/Details")]
        public ActionResult Details(int id)
        {
            var service = CreateEmployeeService();
            var model = service.GetEmployeeById(id);

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [Route("Admin/Employee/Edit")]
        public ActionResult Edit(int id)
        {
            var service = CreateEmployeeService();
            var detail = service.GetEmployeeById(id);
            var model =
                new EmployeeEdit
                {
                    PersonID = detail.PersonID,
                    EmployeeID = detail.EmployeeID,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    StreetAddress = detail.StreetAddress,
                    City = detail.City,
                    State = detail.State,
                    ZipCode = detail.ZipCode,
                    PhoneNumber = detail.PhoneNumber,
                    Email = detail.Email,
                    TerminationDate = detail.TerminationDate,
                };

            ViewBag.EmployeeID = new SelectList(_dB.Appointments, "EmployeeID", "EmployeeID", model.EmployeeID);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(int id, EmployeeEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PersonID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateEmployeeService();

            if (service.UpdateEmployee(model))
            {
                TempData["SaveResult"] = "Your profile has been updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your profile could not be updated.");
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [Route("Admin/Employee/Delete")]
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateEmployeeService();
            var model = service.GetEmployeeById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateEmployeeService();

            service.DeleteEmployee(id);

            TempData["SaveResult"] = "Your profile was deleted";

            return RedirectToAction("Index");
        }

        //helper
        private EmployeeService CreateEmployeeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EmployeeService(userId);
            return service;
        }

    }
}