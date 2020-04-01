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
    public class OwnerService
    {
        private readonly Guid _userId;
        private readonly ApplicationDbContext _context;

        public OwnerService(Guid userId)
        {
            _context = new ApplicationDbContext();
            _userId = userId;
        }

        //CREATE    

        public bool CreateOwner(OwnerCreate model)
        {
            var entity =
                new Owner()
                {
                    HumanID = _userId, 
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    StreetAddress = model.StreetAddress,
                    City = model.City,
                    State = model.State,
                    ZipCode = model.ZipCode,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    CreatedUtc = DateTimeOffset.Now,
                };

            _context.Owners.Add(entity);
            return _context.SaveChanges() == 1;
        }

        //GET -- Contact Info

        public IEnumerable<OwnerEssentials> GetOwners()
        {
            var entityList = _context.Owners.ToList();

            var ownerList =
                entityList
                 .Where(e => e.HumanID == _userId)
                 .Select(
                    e =>
                        new OwnerEssentials
                        {
                            OwnerID = e.OwnerID,
                            FullName = e.FullName,
                            PhoneNumber = e.PhoneNumber,
                            Email = e.Email,
                            CreatedUtc = e.CreatedUtc,
                            ModifiedUtc = e.ModifiedUtc,
                            Pets = e.Pets,
                        }).ToList();

            //why is list in Park Rater vs. Array in Eleven Note?

            return (ownerList); 
        }

        public OwnerFullInfo GetOwnerById(int ownerID)
        {
            var entity = _context.Owners.Find(ownerID);


            if (entity == null)
                return null;

            var model = new OwnerFullInfo
            {
                OwnerID = entity.OwnerID,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                StreetAddress = entity.StreetAddress,
                City = entity.City,
                State = entity.State,
                ZipCode = entity.ZipCode,
                PhoneNumber = entity.PhoneNumber,
                Email = entity.Email,
                Pets = entity.Pets,
                Appointments = entity.Appointments,
            };
            return (model);

        }

        public bool UpdateOwner(OwnerEdit model)
        {
            using (_context)
            {
                var entity =
                      _context
                      .Owners
                     .Single(e => e.OwnerID == model.OwnerID && e.HumanID == _userId);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.StreetAddress = model.StreetAddress;
                entity.City = model.City;
                entity.State = model.State;
                entity.ZipCode = model.ZipCode;
                entity.PhoneNumber = model.PhoneNumber;
                entity.Email = model.Email;
                entity.ModifiedUtc = DateTimeOffset.Now;

                return _context.SaveChanges() == 1; 
            }
        }

        public bool DeleteOwner(int ownerID)
        {
            using (_context)
            {
                var entity =
                    _context
                    .Owners
                    .Single(e => e.OwnerID == ownerID && e.HumanID == _userId);
                _context.Owners.Remove(entity);

                return _context.SaveChanges() == 1; 
            }
        }

    }
}
