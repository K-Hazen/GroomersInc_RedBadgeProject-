using Groomers.Data;
using Groomers.Models;
using Groonmers.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomers.Services
{
    public class PetService
    {
        private readonly ApplicationDbContext _context;
        private readonly Guid _userID;

        public PetService() { }

        public PetService(Guid userID)
        {
            _context = new ApplicationDbContext();
            _userID = userID; 
        }



        public bool CreatePet(PetCreate model)
        {

            var customerService = new CustomerService(_userID);
            var customerDetail = customerService.GetCustomerByCurrentUserId();

            var entity =
                new Pet()
                {
                    Name = model.Name,
                    SizeOfDog = model.SizeOfDog,
                    IsHairLong = model.IsHairLong,
                    SpecialRequest = model.SpecialRequest,
                    Birthday = model.Birthday,
                    DateAdded = DateTimeOffset.Now,
                    PersonID = customerDetail.PersonID,
                };

            _context.Pets.Add(entity);

            return _context.SaveChanges() == 1;
        }

        public IEnumerable<PetListItem> GetPets()
        {
            var entityList = _context.Pets.ToList();

            var petList =
                entityList
                    .Select(
                        e =>
                        new PetListItem
                        {
                            PetID = e.PetID,
                            Name = e.Name,
                            SizeOfDog = e.SizeOfDog,
                            IsHairLong = e.IsHairLong,
                            SpecialRequest = e.SpecialRequest,
                            DateAdded= e.DateAdded,
                            PersonID = e.PersonID,
                        }).ToList(); 

            return (petList);
            
        }

        public IEnumerable<PetListItem> GetPetsByUserID()
        {

            //_context.Pets where e.Person.UserID
            var entityList = _context.Pets.ToList();

            var petList =
                entityList
                    .Where(e => e.Person.UserID == _userID)
                    .Select(
                        e =>
                        new PetListItem
                        {
                            PetID = e.PetID,
                            Name = e.Name,
                            SizeOfDog = e.SizeOfDog,
                            IsHairLong = e.IsHairLong,
                            SpecialRequest = e.SpecialRequest,
                            DateAdded = e.DateAdded,
                            PersonID = e.PersonID,
                        }).ToList();

            return (petList);

        }

        public PetDetail GetPetById(int id)
        {
            using (_context)
            {
                var entity =
                    _context
                    .Pets
                    .Single(e => e.PetID == id);
                
                return
                new PetDetail
                {
                    PetID = entity.PetID,
                    Name = entity.Name,
                    SizeOfDog = entity.SizeOfDog,
                    SpecialRequest = entity.SpecialRequest,
                    Birthday = entity.Birthday,
                   // PersonID = entity.PersonID,
                    FullName = entity.Person.FullName, 
                    DateAdded = entity.DateAdded,
                    DateModified = entity.DateModified,
                    Appointments = entity.Appointments.Select(app => new AppointmentDetails
                    {
                        AppointmentDate = app.AppointmentDate,
                        StartTime = app.StartTime,
                    })
                };
            }
        }

        public bool UpdatePet(PetEdit model)
        {
            using (_context)
            {
                var entity =
                    _context
                    .Pets
                    .Single(e => e.PetID == model.PetID);

                entity.PetID = model.PetID;
                entity.Name = model.Name;
                entity.SizeOfDog = model.SizeOfDog;
                entity.Birthday = model.Birthday;
                entity.SpecialRequest = model.SpecialRequest;
                entity.DateModified = DateTimeOffset.Now;

                return _context.SaveChanges() == 1; 

            }
        }

        public bool DeletePet(int id)
        {
            using (_context)
            {
                var entity =
                    _context
                    .Pets
                    .Single(e => e.PetID == id);
                    _context.Pets.Remove(entity);

                return _context.SaveChanges() == 1; 
            }
        }

        
    }

}
