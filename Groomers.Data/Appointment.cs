using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomers.Data
{
    public class Appointment
    {
        [Key]
        public int AppointmentID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime AppointmentDate { get; set; }


        [Required]
        [DataType(DataType.Time)]
        public DateTimeOffset StartTime { get; set; }


        [Required]
        [DataType(DataType.Time)]
        public DateTimeOffset EndTime { get; set; }


        public TimeSpan Duration 
        {
            get { return EndTime - StartTime; }
        }



        //Automated logic for to indicate whether block is available 
        [DefaultValue(true)]
        public bool IsAvailable { get; set; }


        //[DataType(DataType.Currency)]
        //public decimal Price { get; set; }


        //Get --> number of null PetID spots available 
        public int? NumberOfAppointmentsAvailable { get; set; }


        //[ForeignKey(nameof(Owner))]
        //public int? OwnerID { get; set; }
        //public virtual Owner Owner { get; set; }

       
        [ForeignKey(nameof(Pet))]
        public int? PetID { get; set; }
        public virtual Pet Pet { get; set; }

        [ForeignKey(nameof(Person))]
        public int? PersonID { get; set; }
        public virtual Person Person { get; set; }





    }
}
