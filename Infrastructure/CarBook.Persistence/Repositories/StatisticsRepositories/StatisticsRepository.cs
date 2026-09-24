using CarBook.Application.Interfaces.StatisticsInterfaces;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CarBook.Persistence.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly CarBookContext _context;

        public StatisticsRepository(CarBookContext context)
        {
            _context = context;
        }

        public string GetBlogTitleByMaxBlogComment()
        {
            var blogId = _context.Comments
                .GroupBy(x => x.BlogId)
                .OrderByDescending(y => y.Count())
                .Select(z => z.Key)
                .FirstOrDefault();

            var blogTitle = _context.Blogs.Where(x => x.BlogId == blogId).Select(y => y.Title).FirstOrDefault();
            return blogTitle;
        }

        public string GetBrandNameByMaxCar()
        {
            var brandId = _context.Cars
                .GroupBy(x => x.BrandId)
                .OrderByDescending(y => y.Count())
                .Select(z => z.Key)
                .FirstOrDefault();

            var brandName = _context.Brands.Where(x => x.BrandId == brandId).Select(y => y.Name).FirstOrDefault();
            return brandName;
        }

        public int GetAuthorCount()
        {
            return _context.Authors.Count();
        }

        public decimal GetAvgRentPriceForDaily()
        {
            int id = _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingId).FirstOrDefault();
            return _context.CarPricings.Where(w => w.PricingId == id).Average(x => x.Amount);
        }

        public decimal GetAvgRentPriceForMonthly()
        {
            int id = _context.Pricings.Where(x => x.Name == "Aylık").Select(y => y.PricingId).FirstOrDefault();
            return _context.CarPricings.Where(w => w.PricingId == id).Average(x => x.Amount);
        }

        public decimal GetAvgRentPriceForWeekly()
        {
            int id = _context.Pricings.Where(x => x.Name == "Haftalık").Select(y => y.PricingId).FirstOrDefault();
            return _context.CarPricings.Where(w => w.PricingId == id).Average(x => x.Amount);
        }

        public int GetBlogCount()
        {
            return _context.Blogs.Count();
        }

        public int GetBrandCount()
        {
            return _context.Brands.Count();
        }

        public string GetCarBrandAndModelByRentPriceDailyMax()
        {
            int pricingId = _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingId).FirstOrDefault();
            decimal maxPrice = _context.CarPricings.Where(x => x.PricingId == pricingId).Max(y => y.Amount);
            int carId = _context.CarPricings.Where(x => x.Amount == maxPrice && x.PricingId == pricingId).Select(y => y.CarId).FirstOrDefault();
            return _context.Cars.Where(x => x.CarId == carId).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefault();
        }

        public string GetCarBrandAndModelByRentPriceDailyMin()
        {
            int pricingId = _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingId).FirstOrDefault();
            decimal minPrice = _context.CarPricings.Where(x => x.PricingId == pricingId).Min(y => y.Amount);
            int carId = _context.CarPricings.Where(x => x.Amount == minPrice && x.PricingId == pricingId).Select(y => y.CarId).FirstOrDefault();
            return _context.Cars.Where(x => x.CarId == carId).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefault();
        }

        public int GetCarCount()
        {
            return _context.Cars.Count();
        }

        public int GetCarCountByFuelElectric()
        {
            return _context.Cars.Where(x => x.Fuel == "Elektrik").Count();
        }

        public int GetCarCountByFuelGasolineOrDiesel()
        {
            return _context.Cars.Where(x => x.Fuel == "Benzin" || x.Fuel == "Dizel").Count();
        }

        public int GetCarCountByKmSmallerThen1000()
        {
            return _context.Cars.Where(x => x.Km <= 1000).Count();
        }

        public int GetCarCountByTranmissionIsAuto()
        {
            return _context.Cars.Where(x => x.Transmission == "Otomatik").Count();
        }

        public int GetLocationCount()
        {
            return _context.Locations.Count();
        }
    }
}