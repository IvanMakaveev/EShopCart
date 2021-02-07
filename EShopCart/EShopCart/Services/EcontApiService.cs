using EShopCart.Models;
using EShopCart.Services.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EShopCart.Services
{
    public class EcontApiService : IEcontApiService
    {
        // API Endpoints
        private string getAllCitiesUrl = "http://ee.econt.com/services/Nomenclatures/NomenclaturesService.getCities.json";
        private string validateAddressUrl = "http://ee.econt.com/services/Nomenclatures/AddressService.validateAddress.json";
        private string createLabelUrl = "http://ee.econt.com/services/Shipments/LabelService.createLabel.json";

        public async Task<CitiesContainerDto> GetAllCitiesAsync()
        {
            var client = new HttpClient();
            var jsonDataCities = await client
                .GetAsync(this.getAllCitiesUrl)
                .Result
                .Content
                .ReadAsStringAsync();

            var cities = JsonConvert.DeserializeObject<CitiesContainerDto>(jsonDataCities);

            return cities;
        }

        public async Task<string> GetLabelAsync(OrderInputModel inputModel)
        {
            var label = new LabelContainerDto()
            {
                Label = new LabelDto()
                {
                    SenderClient = new ClientDto()
                    {
                        Name = "Иван Макавеев",
                        Phones = new List<string>() { "0888888888" }
                    },
                    SenderAddress = new AddressDto()
                    {
                        City = new CityDto()
                        {
                            Country = new CountryDto()
                            {
                                Code3 = "BGR",
                                Name = "България"
                            },
                            Name = "Монтана",
                            PostCode = "3400"
                        },
                        Street = "Св. Климент Охридски",
                        Num = "12",
                        Other = string.Empty,
                    },
                    ReceiverClient = new ClientDto()
                    {
                        Name = inputModel.Name,
                        Phones = new List<string>() { inputModel.Phone }
                    },
                    ReceiverAddress = new AddressDto()
                    {
                        City = new CityDto()
                        {
                            Country = new CountryDto()
                            {
                                Code3 = "BGR",
                                Name = "България"
                            },
                            Name = inputModel.City.Split(';')[0],
                            PostCode = inputModel.City.Split(';')[1],
                        },
                        Street = inputModel.Street,
                        Num = inputModel.Number,
                        Other = inputModel.Other,
                    },
                    // The following data is just for testing
                    PackCount = 1,
                    ShipmentType = "PACK",
                    Weight = 50,
                    ShipmentDescription = "Some Description"
                },
                Mode = "create"
            };

            var request = JsonConvert.SerializeObject(label, Formatting.Indented);

            var client = new HttpClient();
            var jsonLabel = await client
                .PostAsync(this.createLabelUrl, new StringContent(request))
                .Result
                .Content
                .ReadAsStringAsync();

            var labelResult = JsonConvert.DeserializeObject<LabelResultDto>(jsonLabel);

            return labelResult.Label.PdfUrl;
        }

        public async Task<bool> ValidateAddressAsync(OrderInputModel inputModel)
        {
            var address = new AddressContainerDto()
            {
                Address = new AddressDto()
                {
                    City = new CityDto()
                    {
                        Country = new CountryDto()
                        {
                            Code3 = "BGR",
                            Name = "България"
                        },
                        Name = inputModel.City.Split(';')[0],
                        PostCode = inputModel.City.Split(';')[1],
                    },
                    Street = inputModel.Street,
                    Num = inputModel.Number,
                    Other = inputModel.Other,
                }
            };

            var request = JsonConvert.SerializeObject(address, Formatting.Indented);

            var client = new HttpClient();
            var jsonDataValidation = await client
                .PostAsync(this.validateAddressUrl, new StringContent(request))
                .Result
                .Content
                .ReadAsStringAsync();

            var validation = JsonConvert.DeserializeObject<ValidationDto>(jsonDataValidation);

            return validation.ValidationStatus == "normal";
        }
    }
}
