using CarBook.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminStatistics")]
    public class AdminStatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminStatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            Random random = new Random();
            var client = _httpClientFactory.CreateClient();

            #region 1. Toplam Araç Sayısı
            var res1 = await client.GetAsync("https://localhost:7014/api/Statistics/GetCarCount");
            if (res1.IsSuccessStatusCode)
            {
                var json1 = await res1.Content.ReadAsStringAsync();
                var val1 = JsonConvert.DeserializeObject<ResultStatisticsDto>(json1);
                ViewBag.v = val1.CarCount;
                ViewBag.v1 = random.Next(0, 101);
            }
            #endregion

            #region 2. Lokasyon Sayısı
            var res2 = await client.GetAsync("https://localhost:7014/api/Statistics/GetLocationCount");
            if (res2.IsSuccessStatusCode)
            {
                var json2 = await res2.Content.ReadAsStringAsync();
                var val2 = JsonConvert.DeserializeObject<ResultStatisticsDto>(json2);
                ViewBag.locationCount = val2.LocationCount;
                ViewBag.locationCountRandom = random.Next(0, 101);
            }
            #endregion

            #region 3. Yazar Sayısı
            var res3 = await client.GetAsync("https://localhost:7014/api/Statistics/GetAuthorCount");
            if (res3.IsSuccessStatusCode)
            {
                var json3 = await res3.Content.ReadAsStringAsync();
                var val3 = JsonConvert.DeserializeObject<ResultStatisticsDto>(json3);
                ViewBag.authorCount = val3.AuthorCount;
                ViewBag.authorCountRandom = random.Next(0, 101);
            }
            #endregion

            #region 4. Blog Sayısı
            var res4 = await client.GetAsync("https://localhost:7014/api/Statistics/GetBlogCount");
            if (res4.IsSuccessStatusCode)
            {
                var json4 = await res4.Content.ReadAsStringAsync();
                var val4 = JsonConvert.DeserializeObject<ResultStatisticsDto>(json4);
                ViewBag.blogCount = val4.BlogCount;
                ViewBag.blogCountRandom = random.Next(0, 101);
            }
            #endregion

            #region 5. Marka Sayısı
            var res5 = await client.GetAsync("https://localhost:7014/api/Statistics/GetBrandCount");
            if (res5.IsSuccessStatusCode)
            {
                var json5 = await res5.Content.ReadAsStringAsync();
                var val5 = JsonConvert.DeserializeObject<ResultStatisticsDto>(json5);
                ViewBag.brandCount = val5.BrandCount;
                ViewBag.brandCountRandom = random.Next(0, 101);
            }
            #endregion

            #region 6. Günlük Ortalama Araç Fiyatı
            var res6 = await client.GetAsync("https://localhost:7014/api/Statistics/GetAvgRentPriceForDaily");
            if (res6.IsSuccessStatusCode)
            {
                var json6 = await res6.Content.ReadAsStringAsync();
                var val6 = JsonConvert.DeserializeObject<ResultStatisticsDto>(json6);
                decimal dailyPrice = val6.AvgRentPriceForDaily != 0 ? val6.AvgRentPriceForDaily : val6.AvgPriceForDaily;
                ViewBag.avgRentPriceForDaily = dailyPrice.ToString("0.00");
                ViewBag.avgRentPriceForDailyRandom = random.Next(0, 101);
            }
            #endregion

            #region 7. Haftalık Ortalama Araç Fiyatı
            var res7 = await client.GetAsync("https://localhost:7014/api/Statistics/GetAvgRentPriceForWeekly");
            if (res7.IsSuccessStatusCode)
            {
                var json7 = await res7.Content.ReadAsStringAsync();
                var val7 = JsonConvert.DeserializeObject<ResultStatisticsDto>(json7);
                decimal weeklyPrice = val6_or_val7(val7.AvgRentPriceForWeekly, val7.AvgPriceForWeekly);
                ViewBag.avgRentPriceForWeekly = weeklyPrice.ToString("0.00");
                ViewBag.avgRentPriceForWeeklyRandom = random.Next(0, 101);
            }
            #endregion

            #region 8. Aylık Ortalama Araç Fiyatı
            var res8 = await client.GetAsync("https://localhost:7014/api/Statistics/GetAvgRentPriceForMonthly");
            if (res8.IsSuccessStatusCode)
            {
                var json8 = await res8.Content.ReadAsStringAsync();
                var val8 = JsonConvert.DeserializeObject<ResultStatisticsDto>(json8);
                decimal monthlyPrice = val6_or_val7(val8.AvgRentPriceForMonthly, val8.AvgPriceForMonthly);
                ViewBag.avgRentPriceForMonthly = monthlyPrice.ToString("0.00");
                ViewBag.avgRentPriceForMonthlyRandom = random.Next(0, 101);
            }
            #endregion

            #region 9. Otomatik Vites Araç Sayısı
            var res9 = await client.GetAsync("https://localhost:7014/api/Statistics/GetCarCountByTransmissionIsAuto");
            if (res9.IsSuccessStatusCode)
            {
                var json9 = await res9.Content.ReadAsStringAsync();
                var val9 = JsonConvert.DeserializeObject<ResultStatisticsDto>(json9);
                ViewBag.carCountByTransmissionIsAuto = val9.CarCountByTransmissionIsAuto;
                ViewBag.carCountByTransmissionIsAutoRandom = random.Next(0, 101);
            }
            #endregion

            #region 10. En Çok Araçlı Marka
            var res10 = await client.GetAsync("https://localhost:7014/api/Statistics/GetBrandNameByMaxCar");
            if (res10.IsSuccessStatusCode)
            {
                var json10 = await res10.Content.ReadAsStringAsync();
                var val10 = JsonConvert.DeserializeObject<ResultStatisticsDto>(json10);
                ViewBag.brandNameByMaxCar = val10.BrandNameByMaxCar;
                ViewBag.brandNameByMaxCarRandom = random.Next(0, 101);
            }
            #endregion

            #region 11. En Çok Yorumlu Blog
            var res11 = await client.GetAsync("https://localhost:7014/api/Statistics/GetBlogTitleByMaxBlogComment");
            if (res11.IsSuccessStatusCode)
            {
                var json11 = await res11.Content.ReadAsStringAsync();
                var val11 = JsonConvert.DeserializeObject<ResultStatisticsDto>(json11);
                ViewBag.blogTitleByMaxBlogComment = val11.BlogTitleByMaxBlogComment;
                ViewBag.blogTitleByMaxBlogCommentRandom = random.Next(0, 101);
            }
            #endregion

            #region 12. 1000 KM Altındaki Araç Sayısı
            var res12 = await client.GetAsync("https://localhost:7014/api/Statistics/GetCarCountByKmSmallerThen1000");
            if (res12.IsSuccessStatusCode)
            {
                var json12 = await res12.Content.ReadAsStringAsync();
                var val12 = JsonConvert.DeserializeObject<ResultStatisticsDto>(json12);
                ViewBag.carCountByKmSmallerThen1000 = val12.CarCountByKmSmallerThen1000;
                ViewBag.carCountByKmSmallerThen1000Random = random.Next(0, 101);
            }
            #endregion

            #region 13. Benzin veya Dizel Araç Sayısı
            var res13 = await client.GetAsync("https://localhost:7014/api/Statistics/GetCarCountByFuelGasolineOrDiesel");
            if (res13.IsSuccessStatusCode)
            {
                var json13 = await res13.Content.ReadAsStringAsync();
                var val13 = JsonConvert.DeserializeObject<ResultStatisticsDto>(json13);
                ViewBag.carCountByFuelGasolineOrDiesel = val13.CarCountByFuelGasolineOrDiesel;
                ViewBag.carCountByFuelGasolineOrDieselRandom = random.Next(0, 101);
            }
            #endregion

            #region 14. Elektrikli Araç Sayısı
            var res14 = await client.GetAsync("https://localhost:7014/api/Statistics/GetCarCountByFuelElectric");
            if (res14.IsSuccessStatusCode)
            {
                var json14 = await res14.Content.ReadAsStringAsync();
                var val14 = JsonConvert.DeserializeObject<ResultStatisticsDto>(json14);
                ViewBag.carCountByFuelElectric = val14.CarCountByFuelElectric;
                ViewBag.carCountByFuelElectricRandom = random.Next(0, 101);
            }
            #endregion

            #region 15. Günlük Kirası En Yüksek Araç
            var res15 = await client.GetAsync("https://localhost:7014/api/Statistics/GetCarBrandAndModelByRentPriceDailyMax");
            if (res15.IsSuccessStatusCode)
            {
                var json15 = await res15.Content.ReadAsStringAsync();
                var val15 = JsonConvert.DeserializeObject<ResultStatisticsDto>(json15);
                ViewBag.carBrandAndModelByRentPriceDailyMax = val15.CarBrandAndModelByRentPriceDailyMax;
                ViewBag.carBrandAndModelByRentPriceDailyMaxRandom = random.Next(0, 101);
            }
            #endregion

            #region 16. Günlük Kirası En Düşük Araç
            var res16 = await client.GetAsync("https://localhost:7014/api/Statistics/GetCarBrandAndModelByRentPriceDailyMin");
            if (res16.IsSuccessStatusCode)
            {
                var json16 = await res16.Content.ReadAsStringAsync();
                var val16 = JsonConvert.DeserializeObject<ResultStatisticsDto>(json16);
                ViewBag.carBrandAndModelByRentPriceDailyMin = val16.CarBrandAndModelByRentPriceDailyMin;
                ViewBag.carBrandAndModelByRentPriceDailyMinRandom = random.Next(0, 101);
            }
            #endregion

            return View();
        }

        private static decimal val6_or_val7(decimal p1, decimal p2)
        {
            return p1 != 0 ? p1 : p2;
        }
    }
}