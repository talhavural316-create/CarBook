using CarBook.Application.Features.CQRS.Results.AuthorResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarBook.Application.Features.CQRS.Queries.AuthorQueries
{
    public class GetAuthorByIdQuery : IRequest<List<GetAuthorQueryResult>>
    {
    }
}
