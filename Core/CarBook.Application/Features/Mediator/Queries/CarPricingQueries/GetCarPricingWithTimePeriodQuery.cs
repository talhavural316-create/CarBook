using MediatR;
using System.Collections.Generic;
using CarBook.Application.Features.Mediator.Results.CarPricingResults;

namespace CarBook.Application.Features.Mediator.Queries.CarPricingQueries
{
    public class GetCarPricingWithTimePeriodQuery : IRequest<List<GetCarPricingWithTimePeriodQueryResult>>
    {
    }
}