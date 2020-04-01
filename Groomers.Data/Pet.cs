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

    public class Pet : Customer
    {
        [Key]
        public int PetID { get; set; }

        [Required]
        public List<string> DogSize
        {
            get
            {
                return new List<string> { "Toy (1 - 12lbs)", "Small (12 - 25lbs)", "Medium (25 - 50lbs)", "Large (50- 100lbs)", "Extra Large (100lbs. and up)" };
            }
            set { }
        }

        [Required]
        [DefaultValue(false)]
        public bool IsHairLong { get; set; }


        [DataType(DataType.MultilineText)]
        public string SpecialRequest { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/yyyy}")]
        public DateTime Birthday { get; set; }

        [ForeignKey(nameof(Owner))]
        public int OwnerID { get; set; }
        public virtual Owner Owner { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }


    }
}
