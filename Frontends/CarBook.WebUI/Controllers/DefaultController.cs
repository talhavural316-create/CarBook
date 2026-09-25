using CarBook.Dto.LocationDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CarBook.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7014/api/Locations");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);

                List<SelectListItem> values2 = (from x in values
                                                select new SelectListItem
                                                {
                                                    Text = x.Name,
                                                    Value = x.LocationId.ToString()
                                                }).ToList();

                ViewBag.v = values2;
            }

            return View();
        }

        [HttpPost]
        public IActionResult Index(string bookpickdate, string bookoffdate, string timepick, string timeoff, string locationId)
        {
            TempData["bookpickdate"] = bookpickdate;
            TempData["bookoffdate"] = bookoffdate;
            TempData["timepick"] = timepick;
            TempData["timeoff"] = timeoff;
            TempData["locationId"] = locationId;

            return RedirectToAction("Index", "RentACarList");
        }
    }
}