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
    public class AppointmentService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
       
        //private readonly Guid _userID; 

        //public AppointmentService(Guid userID)
        //{
        //    _userID = userID; 
        //}

        public bool CreateAppointment(AppointmentCreate model)
        {
            var entity =
                new Appointment()
                {
                    
                    AppointmentDate = model.AppointmentDate,
                    StartTime = model.StartTime,
                    EndTime = model.EndTime,
                    IsAvailable = true,
                    NumberOfAppointmentsAvailable = model.NumberOfAppointmentsAvailable,
                };

            _context.Appointments.Add(entity);

            //Trying to make multiple copies 
            for (int i = 0; i < model.NumberOfAppointmentsAvailable - 1; i++)
            {
                var entityClone =
                    new Appointment()
                    {
                        AppointmentDate = model.AppointmentDate,
                        StartTime = model.StartTime,
                        EndTime = model.EndTime,
                        IsAvailable = true,
                    };

                _context.Appointments.Add(entityClone);
                //_context.SaveChanges(); may need this 

            }

            return _context.SaveChanges() == model.NumberOfAppointmentsAvailable;
        }

        //Get All 

        public IEnumerable<AppointmentListItem> GetAppointments()
        {
            var entityList = _context.Appointments.ToList();

            var appointmentList =
                entityList
                .Select(
                    e =>
                    new AppointmentListItem
                    {
                        AppointmentID = e.AppointmentID,
                        AppointmentDate = e.AppointmentDate,
                        StartTime = e.StartTime,
                        Duration = e.Duration,
                        IsAvailable = e.IsAvailable,
                    }).ToList();

            return (appointmentList);
        }

        public AppointmentDetails GetAppointmentById(int appointmentID)
        {
            var entity = _context.Appointments.Find(appointmentID);

            if (entity == null)
                return null;

            var model = new AppointmentDetails
            {
                AppointmentID = entity.AppointmentID,
                AppointmentDate = entity.AppointmentDate,
                StartTime = entity.StartTime,
                EndTime = entity.EndTime,
                IsAvailable = entity.IsAvailable,
            };

            return (model);
        }

        public IEnumerable<AppointmentSelect> GetAppointmentByDate(DateTimeOffset? selectedDate)
        {
           // var personID = _context.Customers.Where(e. => e.UserID == )
            var entityList = _context.Appointments.ToList();

            var appList =
                entityList
                .Where(e => e.AppointmentDate == selectedDate)
                .Select(
                    e => 
                      new AppointmentSelect
                     {
                         AppointmentID = e.AppointmentID,
                         //PersonID = personalID,
                         AppointmentDate = e.AppointmentDate,
                         StartTime = e.StartTime,
                         IsAvailable = e.IsAvailable,
                     }).ToList();
            
           var finalList = appList.OrderBy(x => x.StartTime).ToList(); 

            return (finalList);
        }

        public bool UpdateAppointment(AppointmentEdit model)
        {
            using (_context)
            {
                var entity =
                    _context
                    .Appointments
                    .Single(e => e.AppointmentID == model.AppointmentID);

                entity.AppointmentDate = model.AppointmentDate;
                entity.StartTime = model.StartTime;
                entity.EndTime = model.EndTime;
                entity.IsAvailable = model.IsAvailable;
                entity.PersonID = model.PersonID;

                return _context.SaveChanges() == 1;
            }
        }

        //Add logic to update appointment availability to false 

        public bool BookAppointment(AppointmentBook model)
        {
            using (_context)
            {
                var entity =
                    _context
                    .Appointments
                    .Single(e => e.AppointmentID == model.AppointmentID);

                entity.AppointmentID = model.AppointmentID; 
                entity.AppointmentDate = entity.AppointmentDate; 
                entity.StartTime = entity.StartTime; 
                entity.PetID = model.PetID;
                entity.IsAvailable = false;
                entity.PersonID = model.PersonID; 

                return _context.SaveChanges() == 1; 
            }

        }



        public bool DeleteAppointment(int appointmentID)
        {
            var entity =
                _context
                .Appointments
                .Single(e => e.AppointmentID == appointmentID);

            _context.Appointments.Remove(entity);

            return _context.SaveChanges() == 1;
        }


    }
}
