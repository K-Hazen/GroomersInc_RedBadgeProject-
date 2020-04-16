using Groomers.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Groomers.Data.Pet;

namespace Groomers.Models
{
    public class PetCreate
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Size")]
        public DogSize SizeOfDog { get; set; }

        [Required]
        [Display(Name = "Long Hair?")]
        public bool IsHairLong { get; set; }


        [DataType(DataType.MultilineText)]
        [Display(Name = "Grooming Requests")]
        public string SpecialRequest { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/yyyy}")]
        public DateTime Birthday { get; set; }

        [Display(Name = "Owner")]
        public int PersonID { get; set; }

    }

    public class PetDetail
    {
        public int PetID { get; set; }

        public string Name { get; set; }


        [Required]
        [Display(Name = "Size")]
        public DogSize SizeOfDog { get; set; }


        [DataType(DataType.MultilineText)]
        [Display(Name = "Grooming Requests")]
        public string SpecialRequest { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/yyyy}")]
        public DateTime Birthday { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Pet Added On")]
        public DateTimeOffset DateAdded { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Modified")]
        public DateTimeOffset? DateModified { get; set; }

        public int PersonID { get; set; }

        [Display(Name = "Owner")]
        public string FullName { get; set; }

       public IEnumerable<AppointmentDetails> Appointments { get; set; }

    }

    public class PetListItem
    {
        public int PetID { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Size")]
        public DogSize SizeOfDog { get; set; }


        [DefaultValue(false)]
        [Display(Name = "Long Hair")]
        public bool IsHairLong { get; set; }


        [DataType(DataType.MultilineText)]
        [Display(Name = "Requests")]
        public string SpecialRequest { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Pet Added On")]
        public DateTimeOffset DateAdded { get; set; }

        [Display(Name = "Owner")]
        public string OwnerName { get; set; }
    }

    public class PetEdit
    {

        public int PetID { get; set; }

        public string Name { get; set; }

        [Display(Name = "Size")]
        public DogSize SizeOfDog { get; set; }

        [DefaultValue(false)]
        [Display(Name = "Long Hair")]
        public bool IsHairLong { get; set; }


        [DataType(DataType.MultilineText)]
        [Display(Name = "Grooming Requests")]
        public string SpecialRequest { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Birthday { get; set; }

    }
}
