using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarBook.Application.Features.Mediator.Commands.ServiceCommands
{
    public class RemoveServiceCommand : IRequest
    {
        public RemoveServiceCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
