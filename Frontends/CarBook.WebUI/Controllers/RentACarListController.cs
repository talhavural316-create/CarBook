using CarBook.Dto.RentACarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CarBook.WebUI.Controllers
{
    public class RentACarListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RentACarListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id)
        {
            var bookpickdate = TempData.Peek("bookpickdate");
            var bookoffdate = TempData.Peek("bookoffdate");
            var timepick = TempData.Peek("timepick");
            var timeoff = TempData.Peek("timeoff");
            var locationId = TempData.Peek("locationId");

            int targetLocationId = id;

            if (locationId != null)
            {
                var matches = Regex.Matches(locationId.ToString(), @"\d+");
                if (matches.Count > 0)
                {
                    targetLocationId = int.Parse(matches[matches.Count - 1].Value);
                }
            }

            if (targetLocationId == 0)
            {
                targetLocationId = 4;
            }

            ViewBag.bookpickdate = bookpickdate;
            ViewBag.bookoffdate = bookoffdate;
            ViewBag.timepick = timepick;
            ViewBag.timeoff = timeoff;
            ViewBag.locationId = targetLocationId;

            var client = _httpClientFactory.CreateClient();

            var filterObj = new
            {
                LocationId = targetLocationId,
                Available = true
            };

            var stringContent = new StringContent(JsonConvert.SerializeObject(filterObj), Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7014/api/RentACars", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<FilterRentACarDto>>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}