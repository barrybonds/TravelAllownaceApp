using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAllowance.Data.Models
{
    public class TravelAllowance
    {
        public string Employee { get; set; }
        public string Transport { get; set; }
        public decimal Distance { get; set; }
        public decimal Compensation { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
