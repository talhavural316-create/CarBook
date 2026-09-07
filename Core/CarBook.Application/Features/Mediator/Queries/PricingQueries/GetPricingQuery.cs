using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using CarBook.Application.Features.Mediator.Results.PricingResults;

namespace CarBook.Application.Features.Mediator.Queries.PricingQueries
{
    public class GetPricingQuery : IRequest<List<GetPricingQueryResult>>  
    {
    }
}
