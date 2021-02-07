using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShopCart.Services.Models
{
    public class LabelDto
    {
        [JsonProperty("senderClient")]
        public ClientDto SenderClient { get; set; }

        [JsonProperty("senderAddress")]
        public AddressDto SenderAddress { get; set; }

        [JsonProperty("receiverClient")]
        public ClientDto ReceiverClient { get; set; }

        [JsonProperty("receiverAddress")]
        public AddressDto ReceiverAddress { get; set; }

        [JsonProperty("packCount")]
        public int PackCount { get; set; }

        [JsonProperty("shipmentType")]
        public string ShipmentType { get; set; }

        [JsonProperty("weight")]
        public double Weight { get; set; }

        [JsonProperty("shipmentDescription")]
        public string ShipmentDescription { get; set; }
    }
}
