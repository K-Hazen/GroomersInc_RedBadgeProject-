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
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public bool CreatePet(PetCreate model)
        {
            var entity =
                new Pet()
                {
                    FirstName = model.FirstName,
                    DogSize = model.DogSize, //how would this be used? I was thinking drop down box
                    IsHairLong = model.IsHairLong,
                    SpecialRequest = model.SpecialRequest,
                    Birthday = model.Birthday,
                    CreatedUtc = DateTimeOffset.Now,
                };

            _context.Pets.Add(entity);

            return _context.SaveChanges() == 1;
        }

        public IEnumerable<PetCharacteristics> GetPets()
        {
            using (_context)
            {
                var query =
                    _context
                    .Pets
                    .Select(
                        e =>
                        new PetCharacteristics
                        {
                            PetID = e.PetID,
                            FullName = e.FullName,
                            DogSize = e.DogSize,
                            IsHairLong = e.IsHairLong,
                            SpecialRequest = e.SpecialRequest,
                            CreatedUtc = e.CreatedUtc,
                            //Owner Connection?
                        });

                return query.ToList();
            }
        }

        public PetContactInfo GetPetById(int petID)
        {
            using (_context)
            {
                var entity =
                    _context
                    .Pets
                    .Single(e => e.PetID == petID);

                return
                new PetContactInfo
                {
                    PetID = entity.PetID,
                    FullName = entity.FullName,
                    StreetAddress = entity.StreetAddress,
                    City = entity.City,
                    State = entity.State,
                    ZipCode = entity.ZipCode,
                    Birthday = entity.Birthday,
                    Appointments = entity.Appointments,
                    //Owner?? 
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

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.DogSize = model.DogSize;
                entity.Birthday = model.Birthday;
                entity.SpecialRequest = model.SpecialRequest;
                entity.ModifiedUtc = DateTimeOffset.Now;

                return _context.SaveChanges() == 1; 

            }
        }

        public bool DeleteNote(int petID)
        {
            using (_context)
            {
                var entity =
                    _context
                    .Pets
                    .Single(e => e.PetID == petID);
                    _context.Pets.Remove(entity);

                return _context.SaveChanges() == 1; 
            }
        }

    }
}
