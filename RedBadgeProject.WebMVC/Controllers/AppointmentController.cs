using Groomers.Models;
using Groomers.Services;
using Groonmers.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedBadgeProject.WebMVC.Controllers
{
    [Authorize]
    public class AppointmentController : Controller
    {
        private ApplicationDbContext _dB = new ApplicationDbContext();
        // GET: Appointment
        public ActionResult Index()
        {
            var service = CreateAppointmentService();
            var model = service.GetAppointments();
            return View(model);
        }

        [HttpPost]
        [ActionName ("SelectAppointmentDate")]
        public ActionResult SelectAppointmentDate(DateTimeOffset? SearchDate)
        {
            var service = CreateAppointmentService();
            var model = service.GetAppointmentByDate(SearchDate); 
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(AppointmentCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateAppointmentService();

            if (service.CreateAppointment(model))
            {
                TempData["SaveResult"] = "Your appointment was created";

                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Appointment could not be created");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var service = CreateAppointmentService();
            var model = service.GetAppointmentById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateAppointmentService();
            var detail = service.GetAppointmentById(id);
            var model =
                new AppointmentEdit
                {
                    AppointmentID = detail.AppointmentID,
                    AppointmentDate = detail.AppointmentDate,
                    StartTime = detail.StartTime,
                    EndTime = detail.EndTime,
                    IsAvailable = detail.IsAvailable,
                };

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(int id, AppointmentEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.AppointmentID != id)
            {
                ModelState.AddModelError("", "Id MisMatch");
                return View(model);
            }

            var service = CreateAppointmentService();

            if (service.UpdateAppointment(model))
            {
                TempData["SaveResult"] = "Your appointment was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your appointment could not be updated.");
            return View(model);
        }

        [ActionName("BookAppointment")]
        public ActionResult BookAppointment(int id)
        {
            var service = CreateAppointmentService();
            var detail = service.GetAppointmentById(id);
            var model =
                new AppointmentBook
                {
                    AppointmentID = detail.AppointmentID,
                    AppointmentDate = detail.AppointmentDate,
                    StartTime = detail.StartTime,
                    IsAvailable = detail.IsAvailable,
                   
                };

            ViewBag.CategoryID = new SelectList(_dB.Pets, "PetID", "Name");
            return View(model);

        }
        
        [ActionName("BookAppointment")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BookAppointment(int id, AppointmentBook model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.AppointmentID != id)
            {
                ModelState.AddModelError("", "Date is not valid.");
                return View(model);
            }

            var service = CreateAppointmentService();

            if (service.BookAppointment(model))
            {
                TempData["SaveResult"] = "Your appointment has been booked.";
                return RedirectToAction("Index", "Customer");

                //return RedirectToAction("Details", "Customer", new { id = model.PersonID });
            }

            ModelState.AddModelError("", "Your selection is already booked. Please pick another option.");
            return View(model);
        }



        [ActionName("Delete")]

        public ActionResult Delete(int id)
        {
            var service = CreateAppointmentService();
            var model = service.GetAppointmentById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult DeletePost(int id)
        {
            var service = CreateAppointmentService();

            service.DeleteAppointment(id);

            TempData["SaveResult"] = "Your appointment was deleted";

            return RedirectToAction("Index");
        }

        //helper

        private AppointmentService CreateAppointmentService()
        {
            var service = new AppointmentService();
            return service;
        }
    }
}