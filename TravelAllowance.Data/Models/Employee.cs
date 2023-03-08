using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAllowance.Data.Models
{
   public  class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Transport { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Distance { get; set; }
        public int WorkdaysPerWeek { get; set; }
    }
}
