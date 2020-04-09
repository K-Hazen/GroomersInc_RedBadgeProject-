using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomers.Data
{
    public abstract class Person
    {
        [Key]
        [Required]
        public int PersonID { get; set; }

        [Required]
        public Guid UserID { get; set; }

        [Required]
        public string FirstName { get; set; }


        [Required]
        public string LastName { get; set; }


        public string FullName => $"{FirstName } {LastName }";


        [Required]
        public string StreetAddress { get; set; }


        [Required]
        public string City { get; set; }


        [Required]
        public string State { get; set; }


        [Required]
        public string ZipCode { get; set; }


        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }


        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


    }
}
