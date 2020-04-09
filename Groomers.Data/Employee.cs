using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomers.Data
{
    public class Employee : Person
    {
        [Required]
        public int EmployeeID { get; set; }

        [Required]
        public DateTimeOffset HireDate { get; set; }

        public DateTimeOffset? TerminationDate { get; set; }

        public string JobTitle { get; set; }

        public ICollection<Pet> Pets { get; set; }

    }
}
