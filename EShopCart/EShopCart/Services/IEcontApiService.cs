using EShopCart.Models;
using EShopCart.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShopCart.Services
{
    public interface IEcontApiService
    {
        public Task<CitiesContainerDto> GetAllCitiesAsync();

        public Task<bool> ValidateAddressAsync(OrderInputModel inputModel);

        public Task<string> GetLabelAsync(OrderInputModel inputModel);
    }
}
