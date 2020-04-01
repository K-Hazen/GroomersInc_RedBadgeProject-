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
    public class PetCreate
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Required]
        public List<string> DogSize { get; set; }
        

        [Required]
        public bool IsHairLong { get; set; }


        [DataType(DataType.MultilineText)]
        public string SpecialRequest { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/yyyy}")]
        public DateTime Birthday { get; set; }

        [DataType(DataType.Date)]
        public DateTimeOffset CreatedUtc { get; set; }

    }

    public class PetContactInfo
    {
        public int PetID { get; set; }

        [Display(Name = "Name")]
        public string FullName { get; set; }

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
        public string ZipCode { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/yyyy}")]
        public DateTime Birthday { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
        //Owner 

    }

    public class PetCharacteristics
    {
        public int PetID { get; set; }

        [Display(Name = "Name")]
        public string FullName { get; set; }

        [Required]
        public List<string> DogSize { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool IsHairLong { get; set; }


        [DataType(DataType.MultilineText)]
        public string SpecialRequest { get; set; }

        [DataType(DataType.Date)]
        public DateTimeOffset CreatedUtc { get; set; }

        //Owner Connection
        //list of appointments 
    }

    public class PetEdit
    {
        public int PetID { get; set; }
        

        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        public List<string> DogSize { get; set; }


        [DataType(DataType.MultilineText)]
        public string SpecialRequest { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/yyyy}")]
        public DateTime Birthday { get; set; }


        [DataType(DataType.Date)]
        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
