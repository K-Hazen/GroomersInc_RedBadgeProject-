using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomers.Models
{
    public class CustomerCreate
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string StreetAddress { get; set; }


        [Required]
        [Display(Name = "City")]
        public string City { get; set; }


        [Required]
        [Display(Name = "State")]
        [MaxLength(2, ErrorMessage = "Please use state abbreviation")]
        public string State { get; set; }


        [Required]
        [Display(Name = "Zip Code")]
        [DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }

        [DataType(DataType.Date)]
        public DateTimeOffset CreatedUtc { get; set; }


        [DataType(DataType.Date)]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }

    public class CustomerContactInfo
    {
        [Key]
        public int CustomerID { get; set; }

        [Display(Name = "Name")]
        public string FullName { get; set; }

        [Display(Name = "Address")]
        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [DisplayFormat(DataFormatString = "{0:(###) ###-####}")]
        public string PhoneNumber { get; set; }


        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

    }

    public class CusotmerEssentials
    {
        [Key]
        public int CustomerID { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [DisplayFormat(DataFormatString = "{0:(###) ###-####}")]
        public string PhoneNumber { get; set; }


        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTimeOffset CreateUtc { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTimeOffset? ModifiedUTC { get; set; }
    }

    public class CustomersEdit
    {

        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [Display(Name = "Address")]
        public string StreetAddress { get; set; }


        [Display(Name = "City")]
        public string City { get; set; }


        [MaxLength(2, ErrorMessage = "Please use state abbreviation")]
        public string State { get; set; }


        [Display(Name = "Zip Code")]
        [DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }
    }

}
