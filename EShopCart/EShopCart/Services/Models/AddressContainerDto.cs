using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShopCart.Services.Models
{
    public class AddressContainerDto
    {
        [JsonProperty("address")]
        public AddressDto Address { get; set; }
    }
}
