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

        public bool CreateAppointment(AppointmentCreate model)
        {
            var entity =
                new Appointment()
                {
                    AppointmentDate = model.AppointmentDate,
                    StartTime = model.StartTime,
                    EndTime = model.EndTime,
                    IsAvailable = model.IsAvailable,
                    NumberOfAppointmentsAvailable = model.NumberOfAppointmentsAvailable,
                };

            _context.Appointments.Add(entity);

            //Trying to make multiple copies 
            for (int i = 0; i < model.NumberOfAppointmentsAvailable - 1; i++)
            {
                var entityClones =
                    new Appointment()
                    {
                        AppointmentDate = model.AppointmentDate,
                        StartTime = model.StartTime,
                        EndTime = model.EndTime,
                        IsAvailable = model.IsAvailable,
                    };

                _context.Appointments.Add(entityClones);
                //_context.SaveChanges(); may need this 

            }
            //Not sure if this will work it may just write over _context line multiple time verses making multiple copies 

            return _context.SaveChanges() == model.NumberOfAppointmentsAvailable;
        }

        //Get All 

        public IEnumerable<AppointmentDetails> GetAppointments()
        {
            using (_context)
            {
                var query =
                    _context
                    .Appointments
                    .Select(
                        e =>
                        new AppointmentDetails
                        {
                            AppointmentID = e.AppointmentID,
                            AppointmentDate = e.AppointmentDate,
                            Duration = e.Duration,
                            IsAvailable = e.IsAvailable,
                        });
                return query.ToList(); 
            }
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
                Duration = entity.Duration,
                IsAvailable = entity.IsAvailable,
            };

            return (model);
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
