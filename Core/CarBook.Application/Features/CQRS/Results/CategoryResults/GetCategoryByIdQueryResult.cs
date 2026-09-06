using System;
using System.Collections.Generic;
using System.Text;

namespace CarBook.Application.Features.CQRS.Results.CategoryResults
{
    public class GetCategoryByIdQueryResult
    {

        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}
