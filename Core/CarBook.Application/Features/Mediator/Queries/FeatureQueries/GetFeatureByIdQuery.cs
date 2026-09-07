using CarBook.Application.Features.Mediator.Results.FeatureResults;
using MediatR;

public class GetFeatureByIdQuery : IRequest<GetFeatureByIdQueryResult>
{
    public int Id { get; set; }

    public GetFeatureByIdQuery(int id)
    {
        Id = id;
    }
}