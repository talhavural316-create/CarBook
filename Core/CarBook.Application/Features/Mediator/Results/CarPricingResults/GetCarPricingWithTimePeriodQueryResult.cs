using System;
using System.Collections.Generic;
using System.Text;

namespace CarBook.Application.Features.Mediator.Results.CarPricingResults
{
    public class GetCarPricingWithTimePeriodQueryResult
    {
        public string Model { get; set; }
        public decimal DailyAmount { get; set; }
        public decimal WeeklyAmount { get; set; }
        public decimal MonthlyAmount { get; set; }
    }
}
