using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomers.Data
{
    public abstract class Customer
    {
        [Key]
        public int CustomerID { get; set; }


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


        [DataType(DataType.Date)]
        public DateTimeOffset CreatedUtc { get; set; }


        [DataType(DataType.Date)]
        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
