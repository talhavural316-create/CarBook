using CarBook.Application.Features.Mediator.Results.FeatureResults;
using MediatR;
using System.Collections.Generic;

namespace CarBook.Application.Features.Mediator.Queries.FeatureQueries
{
    public class GetFeatureQuery : IRequest<List<GetFeatureQueryResult>>
    {
    }
}