using EShopCart.Models;
using EShopCart.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EShopCart.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEcontApiService econtApiService;

        public HomeController(
            ILogger<HomeController> logger,
            IEcontApiService econtApiService)
        {
            _logger = logger;
            this.econtApiService = econtApiService;
        }

        public async Task<IActionResult> Index()
        {
            var cities = await this.econtApiService.GetAllCitiesAsync();

            var viewModel = new OrderInputModel();
            viewModel.CityItems = cities.Cities
                .Where(x => x.Country != null && x.Country.Code3 == "BGR" && x.PostCode != string.Empty)
                .Select(x => new KeyValuePair<string, string>
                (
                    $"{x.Name};{x.PostCode}",
                    $"{x.Name} ({x.PostCode})"
                ))
                .ToList();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Order(OrderInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction(nameof(this.Index));
            }

            var isValid = await this.econtApiService.ValidateAddressAsync(inputModel);

            if (!isValid)
            {
                ModelState.AddModelError("Error", "An unexpected error has occured, check your input data!");
                return this.RedirectToAction(nameof(this.Index));
            }

            var labelUrl = await this.econtApiService.GetLabelAsync(inputModel);

            return this.Redirect(labelUrl);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
