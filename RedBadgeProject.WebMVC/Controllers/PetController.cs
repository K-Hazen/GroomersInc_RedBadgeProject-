using Groomers.Data;
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
    public class PetController : Controller
    {
        private ApplicationDbContext _dB = new ApplicationDbContext(); 

        // GET: Pet (View = ListItem)
        //public ActionResult Index() ---> May still need this for admin role
        //{
        //    var service = CreatePetService();
        //    var model = service.GetPets(); 
        //    return View(model);
        //}

        public ActionResult Index()
        {
            var service = CreatePetService();
            var model = service.GetPetsByUserID();
            return View(model);
        }
        // Get: calls the view with the form to "build" a pet
        public ActionResult Create()
        {
     
            return View(); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(PetCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreatePetService();

            if (service.CreatePet(model))
            {
                TempData["SaveResult"] = "Your pet's profile was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your pet's profile could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var service = CreatePetService();
            var model = service.GetPetById(id);

            return View(model);

        }

        public ActionResult Edit(int id)
        {
            var service = CreatePetService();
            var detail = service.GetPetById(id);
            var model =
                new PetEdit
                {
                    PetID = detail.PetID,
                    Name = detail.Name,
                    SizeOfDog = detail.SizeOfDog,
                    Birthday = detail.Birthday,
                    SpecialRequest = detail.SpecialRequest,
                };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(int id, PetEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PetID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreatePetService();

            if (service.UpdatePet(model))
            {
                TempData["SaveResult"] = "Your pet's profile has been updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your pet's profile could not be updated.");

                return View(model);
        }

        [ActionName("Delete")]

        public ActionResult Delete(int id)
        {
            var service = CreatePetService();
            var model = service.GetPetById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult DeletePost(int id)
        {
            var service = CreatePetService();
            service.DeletePet(id);

            TempData["SaveResult"] = "Your profile was deleted";

            return RedirectToAction("Index");
        }

        //helper
        private PetService CreatePetService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PetService(userId);
            return service; 
        }
        private CustomerService CreateCustomerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CustomerService(userId);
            return service;
        }
    }
}