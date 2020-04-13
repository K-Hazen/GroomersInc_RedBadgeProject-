using Groomers.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [Required]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [DisplayFormat(DataFormatString = "{0:(###) ###-####}")]
        public long PhoneNumber { get; set; }


        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        //date create.now 

    }

    public class CustomerDetail
    {
        public int PersonID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Address")]
        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [DisplayFormat(DataFormatString = "{0:(###) ###-####}", ApplyFormatInEditMode = true)]
        public long PhoneNumber { get; set; }


        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        //[Display(Name = "Select Date")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        //public DateTimeOffset? SearchDate { get; set; }


        public List<PetListItem> Pets { get; set; }

        public List<AppointmentListItem> Appointments { get; set; }
    }

  
    public class CustomerListItem
    {
        public int PersonID { get; set; }

        [Display(Name = "Name")]
        public string FullName { get; set; }

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [DisplayFormat(DataFormatString = "{0:(###) ###-####}")]
        public long PhoneNumber { get; set; }


        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Profile Created On")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset ProfileCreationDate { get; set; }

        [Display(Name = "Profile Modified On")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset? ProfileModifiedDate { get; set; }

        public List<PetListItem> Pets { get; set; }
    }

    public class CustomerEdit
    {
        public int PersonID { get; set; }

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

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [DisplayFormat(DataFormatString = "{0:(###) ###-####}")]
        public long PhoneNumber { get; set; }


        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        //public bool IsRemoved { get; set; }
        //list of pets? So if they need to remove one from their profile
    }

    public class CustomerHomePage
    {
        public int PersonID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        public Guid UserID { get; set; }

    }
}
