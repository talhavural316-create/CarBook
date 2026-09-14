using CarBook.Domain.Entities;
using System.Collections.Generic;

namespace CarBook.Application.İnterfaces.CarInterfaces
{
    public interface ICarRepository
    {
        List<Car> GetCarsListWithBrands();
        List<Car> GetLast5CarsWithBrands();
        List<Car> GetCarsWithPricings();
    }
}