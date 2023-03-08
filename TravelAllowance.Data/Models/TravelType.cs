using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TravelAllowance.Data.Models
{
    public partial class TravelType
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

       [JsonProperty("base_compensation_per_km")]
        public decimal BaseCompensationPerKm { get; set; }

        [JsonProperty("exceptions")]
        public ExceptionElement[] Exceptions { get; set; }
    }

    public partial class ExceptionElement
    {
        [JsonProperty("min_km")]
        public long MinKm { get; set; }

       [JsonProperty("max_km")]
        public long MaxKm { get; set; }

        [JsonProperty("factor")]
        public long Factor { get; set; }
    }
}
