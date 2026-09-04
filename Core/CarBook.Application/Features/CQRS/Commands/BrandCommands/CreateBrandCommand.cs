using System;
using System.Collections.Generic;
using System.Text;

namespace CarBook.Application.Features.CQRS.Commands.BrandCommands
{
    public class CreateBrandCommand
    {
        public string Name { get; set; }
    }
}
