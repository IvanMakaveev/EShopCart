using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShopCart.Services.Models
{
    public class CityDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("postCode")]
        public string PostCode { get; set; }

        [JsonProperty("country")]
        public CountryDto Country { get; set; }
    }
}
