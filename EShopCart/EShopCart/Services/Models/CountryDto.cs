using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EShopCart.Services.Models
{
    public class CountryDto
    {
        [JsonProperty("code3")]
        public string Code3 { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
