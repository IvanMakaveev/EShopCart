using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShopCart.Services.Models
{
    public class AddressDto
    {
        [JsonProperty("city")]
        public CityDto City { get; set; }

        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("num")]
        public string Num { get; set; }

        [JsonProperty("other")]
        public string Other { get; set; }
    }
}
