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
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public DogSize SizeOfDog { get; set; }

        [Required]
        public bool IsHairLong { get; set; }


        [DataType(DataType.MultilineText)]
        public string SpecialRequest { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/yyyy}")]
        public DateTime Birthday { get; set; }

        public int PersonID { get; set; }

    }

    public class PetDetail
    {
        public int PetID { get; set; }

        public string Name { get; set; }


        [Required]
        public DogSize SizeOfDog { get; set; }


        [DataType(DataType.MultilineText)]
        public string SpecialRequest { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/yyyy}")]
        public DateTime Birthday { get; set; }

        [DataType(DataType.Date)]
        public DateTimeOffset DateAdded { get; set; }

        [DataType(DataType.Date)]
        public DateTimeOffset? DateModified { get; set; }

        public int PersonID { get; set; }


        //Ask Casey about this vs. a regular List 
        public ICollection<Appointment> Appointments { get; set; }
        //Owner 

    }

    public class PetListItem
    {
        public int PetID { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        public DogSize SizeOfDog { get; set; }


        [DefaultValue(false)]
        public bool IsHairLong { get; set; }


        [DataType(DataType.MultilineText)]
        public string SpecialRequest { get; set; }

        [DataType(DataType.Date)]
        public DateTimeOffset DateAdded { get; set; }

        public int PersonID { get; set; }



    }

    public class PetEdit
    {

        public int PetID { get; set; }

        public string Name { get; set; }

        public DogSize SizeOfDog { get; set; }


        [DataType(DataType.MultilineText)]
        public string SpecialRequest { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/yyyy}")]
        public DateTime Birthday { get; set; }


    }
}
