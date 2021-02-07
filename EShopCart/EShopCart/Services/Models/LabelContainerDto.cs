using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShopCart.Services.Models
{
    public class LabelContainerDto
    {
        [JsonProperty("label")]
        public LabelDto Label { get; set; }

        [JsonProperty("mode")]
        public string Mode { get; set; }
    }
}
