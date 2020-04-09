using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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
    public class Pet
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum DogSize {
            [Display(Name = "No Selection")]
            No_Selection = 0,
            [Display(Name = "Toy (1 - 12lbs)")]
            Toy_1_12lbs = 1,
            [Display(Name = "Small (12 - 15lbs)")]
            Small_12_25lbs = 2,
            [Display(Name = "Medium (25 - 50lbs)")]
            Medium_25_50lbs = 3,
            [Display(Name = "Large (50 - 100lbs)")]
            Large_50_100lbs = 4,
            [Display(Name = "XL (100lbs and up)")]
            Extra_Large_100_and_up = 5}


        [Key]
        public int PetID { get; set; }

        [Required]


        [Required]
        public string Name { get; set; }

        [Required]
        public DogSize SizeOfDog { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool IsHairLong { get; set; }


        [DataType(DataType.MultilineText)]
        public string SpecialRequest { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/yyyy}")]
        public DateTime Birthday { get; set; }

        [DataType(DataType.Date)]
        public DateTimeOffset DateAdded { get; set; }


        [DataType(DataType.Date)]
        public DateTimeOffset? DateModified { get; set; }


        [ForeignKey(nameof(Person))]
        public int PersonID { get; set; }
        public virtual Person Person { get; set; }

        
        public virtual ICollection<Appointment> Appointments { get; set; }


    }
}
