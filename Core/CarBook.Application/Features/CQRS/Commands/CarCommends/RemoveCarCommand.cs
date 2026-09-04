using System;
using System.Collections.Generic;
using System.Text;

namespace CarBook.Application.Features.CQRS.Commands.CarCommends
{
    public class RemoveCarCommand
    {
        public int Id { get; set; }

        public RemoveCarCommand(int id)
        {
            Id = id;
        }
    }
}
