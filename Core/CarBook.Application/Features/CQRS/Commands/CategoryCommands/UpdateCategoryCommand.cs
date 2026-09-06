using System;
using System.Collections.Generic;
using System.Text;

namespace CarBook.Application.Features.CQRS.Commands.CategoryCommands
{
    public class UpdateCategoryCommand
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}
