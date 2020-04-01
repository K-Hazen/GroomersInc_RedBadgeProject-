using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomers.Data
{
    public class Owner : Customer
    {
        [Key]
        public int OwnerID { get; set; }

        [Required]
        public Guid HumanID { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }


        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        public virtual ICollection<Pet> Pets { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }

    }
}
