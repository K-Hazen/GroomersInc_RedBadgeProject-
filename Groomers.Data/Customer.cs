using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomers.Data
{
    public class Customer : Person
    {
        //Get -- Pet --> Get -- Appointment (allows access to get appointments for owner)
        public virtual ICollection<Pet> Pets { get; set; }

       
        [DataType(DataType.Date)]
        public DateTimeOffset ProfileCreationDate { get; set; }


        [DataType(DataType.Date)]
        public DateTimeOffset? ProfileModifiedDate { get; set; }


        // public virtual ICollection<Appointment> Appointments { get; set; }

    }
}
