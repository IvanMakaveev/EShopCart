using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShopCart.Services.Models
{
    public class ClientDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("phones")]
        public List<string> Phones { get; set; }
    }
}
