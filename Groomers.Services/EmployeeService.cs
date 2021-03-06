﻿using Groomers.Data;
using Groomers.Models;
using Groonmers.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomers.Services
{
    public class EmployeeService
    {
        private readonly Guid _userID;
        private readonly ApplicationDbContext _context;

        public EmployeeService(Guid userID)
        {
            _context = new ApplicationDbContext();
            _userID = userID;
        }

        public bool CreateEmployee(EmployeeCreate model)
        {
            var entity =
                new Employee()
                {
                    UserID = _userID,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    EmployeeID = model.EmployeeID,
                    JobTitle = model.JobTitle,
                    StreetAddress = model.StreetAddress,
                    City = model.City,
                    State = model.State,
                    ZipCode = model.ZipCode,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    HireDate = model.HireDate,
                };

            _context.Employees.Add(entity);
            return _context.SaveChanges() == 1;
        }

        public IEnumerable<EmployeeListItem> GetEmployees()
        {
            var entityList = _context.Employees.ToList();

            var petList =
                entityList
                .Where(e => e.UserID == _userID)
                .Select(
                    e =>
                    new EmployeeListItem
                    {
                        PersonID = e.PersonID,
                        EmployeeID = e.EmployeeID,
                        FullName = e.FullName,
                        JobTitle = e.JobTitle,
                        PhoneNumber = e.PhoneNumber,
                        Email = e.Email,
                        HireDate = e.HireDate,
                        Pets = e.Pets, 
                    }).ToList();

            return (petList);
        }

        public EmployeeDetail GetEmployeeById(int id)
        {
            var entity = _context.Employees.Find(id);

            if (entity == null)
                return null;

            var model = new EmployeeDetail
            {
                PersonID = entity.PersonID,
                EmployeeID = entity.EmployeeID, 
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                JobTitle = entity.JobTitle,
                StreetAddress = entity.StreetAddress,
                City = entity.City,
                State = entity.State,
                ZipCode = entity.ZipCode,
                PhoneNumber = entity.PhoneNumber,
                Email = entity.Email,
                Pets = entity.Pets,
                HireDate = entity.HireDate,
                TerminationDate = entity.TerminationDate,
            };

            return (model);
        }

        public bool UpdateEmployee(EmployeeEdit model)
        {
            using (_context)
            {
                var entity =
                    _context
                    .Employees
                    .Single(e => e.PersonID == model.PersonID && e.UserID == _userID);

                entity.PersonID = model.PersonID;
                entity.EmployeeID = model.EmployeeID;
                entity.HireDate = model.HireDate; 
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.JobTitle = model.JobTitle;
                entity.StreetAddress = model.StreetAddress;
                entity.City = model.City;
                entity.State = model.State;
                entity.ZipCode = model.ZipCode;
                entity.PhoneNumber = model.PhoneNumber;
                entity.Email = model.Email;
                entity.TerminationDate = entity.TerminationDate;

                return _context.SaveChanges() == 1;
            }

        }

        public bool DeleteEmployee(int id)
        {
            using (_context)
            {
                var entity = 
                    _context
                    .Employees
                    .Single(e => e.PersonID == id && e.UserID == _userID);
                _context.Employees.Remove(entity);

                return _context.SaveChanges() == 1;
            }
        }

    }
}
