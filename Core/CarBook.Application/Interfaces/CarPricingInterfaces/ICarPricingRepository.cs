using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarBook.Application.Interfaces.CarPricingInterfaces
{
    public interface ICarPricingRepository
    {
        List<CarPricing> GetCarPricingWithCars();
    }
}
