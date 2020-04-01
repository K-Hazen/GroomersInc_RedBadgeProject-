using Groomers.Models;
using Groomers.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedBadgeProject.WebMVC.Controllers
{
    public class OwnerController : Controller
    {
        // GET: Owner
        public ActionResult Index()
        {
            var service = CreateOwnerService();
            var model = service.GetOwners();
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(OwnerCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateOwnerService();

            if (service.CreateOwner(model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Owner could not be created");

            return View(model);
        }

        public ActionResult FullInfo(int id)
        {
            var service = CreateOwnerService();
            var model = service.GetOwnerById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateOwnerService();
            var detail = service.GetOwnerById(id);
            var model =
                new OwnerEdit
                {
                    OwnerID = detail.OwnerID,
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

        public ActionResult Edit(int id, OwnerEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.OwnerID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateOwnerService();

            if (service.UpdateOwner(model))
            {
                TempData["SaveResult"] = "Your profile has been updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your profile could not be updated.");
            return View(model); 
        }

        [ActionName("Delete")]

        public ActionResult Delete(int id)
        {
            var service = CreateOwnerService();
            var model = service.GetOwnerById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateOwnerService();

            service.DeleteOwner(id);

            TempData["SaveResult"] = "Your profile was deleted";

            return RedirectToAction("Index");
        }


        //helper method
        private OwnerService CreateOwnerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new OwnerService(userId);
            return service;
        }
    }
}