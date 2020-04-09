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
        public enum DogSize { Toy_1_12lbs = 1, Small_12_25lbs = 2, Medium_25_50lbs = 3, Large_50_100lbs = 4, Extra_Large_100_and_up = 5}


        [Key]
        public int PetID { get; set; }

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
