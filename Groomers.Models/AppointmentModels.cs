using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomers.Models
{
    public class AppointmentCreate
    {
        [Required]
        [Display(Name = "Appointment Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime AppointmentDate { get; set; }


        [Required]
        [Display(Name = "Appointment Start Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm}")]
        public DateTimeOffset StartTime { get; set; }


        [Required]
        [Display(Name = "Appointment End Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm}")]
        public DateTimeOffset EndTime { get; set; }


        [DefaultValue(true)]
        public bool IsAvailable { get; set; }


        //[DataType(DataType.Currency)]
        //[DisplayFormat(DataFormatString = "{0:C0}")]
        //public decimal Price { get; set; }

        public int? NumberOfAppointmentsAvailable { get; set; }
    }

    public class AppointmentListItem
    {
        public int AppointmentID { get; set; }

        [Display(Name = "Appointment Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime AppointmentDate { get; set; }

        [Display(Name = "Appointment Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm}")]
        public DateTimeOffset StartTime { get; set; }

        [Display(Name = "Duration")]
        [DataType(DataType.Time)]
       //[DisplayFormat(DataFormatString = "{0:HH:MM}")]
        public TimeSpan Duration { get; set; }


        [DefaultValue(true)]
        public bool IsAvailable { get; set; }


        //[DataType(DataType.Currency)]
        //[DisplayFormat(DataFormatString = "{0:C0}")]
        //public decimal Price { get; set; }

    }

    public class AppointmentDetails
    {
        public int AppointmentID { get; set; }

        [Display(Name = "Appointment Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime AppointmentDate { get; set; }


        [Display(Name = "Appointment Start Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm}")]
        public DateTimeOffset StartTime { get; set; }



        [Display(Name = "Appointment End Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm}")]
        public DateTimeOffset EndTime { get; set; }



        [DefaultValue(true)]
        public bool IsAvailable { get; set; }


        //[DataType(DataType.Currency)]
        //[DisplayFormat(DataFormatString = "{0:C0}")]
        //public decimal Price { get; set; }

    }

    public class AppointmentEdit
    {
        public int AppointmentID { get; set; }

        [Display(Name = "Appointment Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime AppointmentDate { get; set; }


        [Display(Name = "Appointment Start Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm}")]
        public DateTimeOffset StartTime { get; set; }



        [Display(Name = "Appointment End Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm}")]
        public DateTimeOffset EndTime { get; set; }


        [DefaultValue(true)]
        public bool IsAvailable { get; set; }


        //[DataType(DataType.Currency)]
        //[DisplayFormat(DataFormatString = "{0:C0}")]
        //public decimal Price { get; set; }
    }

    public class AppointmentSelect
    {
        public int AppointmentID { get; set; }

        [Display(Name = "Appointment Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTimeOffset AppointmentDate { get; set; }


        [Display(Name = "Appointment Start Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm}")]
        public DateTimeOffset StartTime { get; set; }

        [DefaultValue(true)]
        public bool IsAvailable { get; set; }

    }

    public class AppointmentBook
    {
        public int AppointmentID { get; set; }

        [Display(Name = "Appointment Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime AppointmentDate { get; set; }


        [Display(Name = "Appointment Start Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm}")]
        public DateTimeOffset StartTime { get; set; }



        [Display(Name = "Appointment End Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm}")]
        public DateTimeOffset EndTime { get; set; }


        [DefaultValue(true)]
        public bool IsAvailable { get; set; }
        
        public int PetID { get; set; }



    }
}
