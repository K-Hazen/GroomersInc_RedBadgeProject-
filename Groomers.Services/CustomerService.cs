using Groomers.Data;
using Groomers.Models;
using Groonmers.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomers.Services
{
    public class CustomerService
    {
        private readonly Guid _userID;
        private readonly ApplicationDbContext _context;
        private ApplicationUser _appUser;

        //create a constructor that passes in that user and assigns to the field
        //in our controller, we'll use similar syntax to get the Guid, but were going to use the .Find method to return the Application User

        public CustomerService(Guid userID)
        {
            _context = new ApplicationDbContext();
            _userID = userID;
        }


        //CREATE    

        public bool CreateCustomer(CustomerCreate model)
        {
            var entity =
                new Customer()
                {
                    UserID = _userID,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    StreetAddress = model.StreetAddress,
                    City = model.City,
                    State = model.State,
                    ZipCode = model.ZipCode,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    ProfileCreationDate = DateTimeOffset.Now,
                };

            _context.Customers.Add(entity);
            return _context.SaveChanges() == 1;
        }

        //GET
        public IEnumerable<AdminCustomerListItem> GetCustomersAdminOnly()
        {
            var entityList = _context.Customers.ToList();

            var customerList =
                entityList
                 .Select(
                    e =>
                        new AdminCustomerListItem
                        {
                            PersonID = e.PersonID,
                            FullName = e.FullName,
                            PhoneNumber = e.PhoneNumber,
                            Email = e.Email,
                            ProfileCreationDate = e.ProfileCreationDate,
                            ProfileModifiedDate = e.ProfileModifiedDate,
                            Pets = e.Pets.Select(pet => new PetListItem
                            {
                                Name = $"{pet.Name}, ",
                            }).ToList()
                        }).ToList();

            return (customerList);
        }

        public IEnumerable<CustomerListItem> GetCustomers()
        {
            var entityList = _context.Customers.ToList();

            var customerList =
                entityList
                 //.Where(e => e.UserID == _userID)
                 .Select(
                    e =>
                        new CustomerListItem
                        {
                            PersonID = e.PersonID,
                            FullName = e.FullName,
                            PhoneNumber = e.PhoneNumber,
                            Email = e.Email,
                            ProfileCreationDate = e.ProfileCreationDate,
                            //ProfileModifiedDate = e.ProfileModifiedDate,
                            Pets = e.Pets.Select(pet => new PetListItem
                            {
                                Name = $"{pet.Name}, ",
                            }).ToList()
                        }).ToList();

            return (customerList);
        }


        public CustomerListItem GetCustomerByCurrentUserId()
        {
            var entity = _context.Customers.Single(e => e.UserID == _userID);

            if (entity == null) return null;


            List<PetListItem> petList = new List<PetListItem>();

            foreach (var pet in entity.Pets)
            {
                petList.Add(new PetListItem
                {
                    PetID = pet.PetID,
                    Name = $"{pet.Name}, "
                });
            }

            var model = new CustomerListItem
            {
                PersonID = entity.PersonID,
                FullName = entity.FullName,
                PhoneNumber = entity.PhoneNumber,
                Email = entity.Email,
                ProfileCreationDate = entity.ProfileCreationDate,
                Pets = petList,
            };

            return (model);
        }

        public CustomerHomePage GetCustomerHomePage()
        
        {
            var entity = _context.Customers.Single(e => e.UserID == _userID);

            if (entity == null) return null;

            var model = new CustomerHomePage
            {
                PersonID = entity.PersonID,
                FirstName = entity.FirstName,
                UserID = _userID,
            };

            return (model);
        }

        public CustomerDetail GetCustomerById(int id)
        {
            var entity = _context.Customers.Find(id);


            if (entity == null)
                return null;

            List<PetListItem> petList = new List<PetListItem>();

            foreach (var pet in entity.Pets)
            {
                petList.Add(new PetListItem
                {
                    Name = $"{pet.Name}, "
                });
            }

            List<AppointmentListItem> appList = new List<AppointmentListItem>();
            List<AppointmentListItem> appListSorted = new List<AppointmentListItem>();
            foreach (var app in entity.Appointments)
            {
                appList.Add(new AppointmentListItem
                {
                    AppointmentDate = app.AppointmentDate,
                    StartTime = app.StartTime,
                    PetID = app.PetID,
                    PetName = app.Pet.Name,
                });

            }
            appListSorted = appList.OrderByDescending(x => x.AppointmentDate).ToList();

            var model = new CustomerDetail
            {
                PersonID = entity.PersonID,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                StreetAddress = entity.StreetAddress,
                City = entity.City,
                State = entity.State,
                ZipCode = entity.ZipCode,
                PhoneNumber = entity.PhoneNumber,
                Email = entity.Email,
                Pets = petList,
                Appointments = appListSorted,
            };
            return (model);

        }

        public bool UpdateCustomer(CustomerEdit model)
        {
            using (_context)
            {
                var entity =
                      _context
                      .Customers
                      .Single(e => e.PersonID == model.PersonID && e.UserID == _userID);

                entity.PersonID = model.PersonID;
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.StreetAddress = model.StreetAddress;
                entity.City = model.City;
                entity.State = model.State;
                entity.ZipCode = model.ZipCode;
                entity.PhoneNumber = model.PhoneNumber;
                entity.Email = model.Email;
                entity.ProfileModifiedDate = DateTimeOffset.Now;

                return _context.SaveChanges() == 1;
            }
        }

        public bool AdminUpdateCustomer(CustomerEdit model)
        {
            using (_context)
            {
                var entity =
                      _context
                      .Customers
                      .Single(e => e.PersonID == model.PersonID);

                entity.PersonID = model.PersonID;
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.StreetAddress = model.StreetAddress;
                entity.City = model.City;
                entity.State = model.State;
                entity.ZipCode = model.ZipCode;
                entity.PhoneNumber = model.PhoneNumber;
                entity.Email = model.Email;
                entity.ProfileModifiedDate = DateTimeOffset.Now;

                return _context.SaveChanges() == 1;
            }
        }

        public bool DeleteCustomer(int id)
        {
            using (_context)
            {
                var entity =
                    _context
                    .Customers
                    .Single(e => e.PersonID == id && e.UserID == _userID);
                //_context.Customers.Remove(entity);

                foreach (var app in entity.Appointments)
                {
                    app.PetID = null;
                    app.PersonID = null;
                    app.IsAvailable = true;

                }
                _context.SaveChanges();

                if (entity.Appointments.Count != 0)
                {
                    return false;
                }
                else
                    _context.Customers.Remove(entity);


                _context.SaveChanges();

                //check context to see if Pets contains an entity for the pet we deleted's Id
                foreach (var customer in _context.Customers)
                {
                    if (customer.PersonID == id)
                    {
                        return false;
                    }

                }

              //  DeleteAppUser();


                return _context.SaveChanges() == 1;

            }
        }

        public bool DeleteAppUser()
        {
            // var user = _context.Users.Find(_userID.ToString());
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));

            var roles = userManager.GetRoles(_userID.ToString());

            //if role is admin, don't let user delete themself

            foreach (var role in roles)
            {

                if (role != "Admin")
                {
                   // _appUser = role; 
                    var result = userManager.Delete(_appUser);

                    if (!result.Succeeded) return false;
                    return true;
                }
                return false;
            }
            return false;

        }
        //after you run the initial delete method in the controller then call in the 

    }
}
