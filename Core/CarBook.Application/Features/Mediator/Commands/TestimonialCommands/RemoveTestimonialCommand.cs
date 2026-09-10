using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarBook.Application.Features.Mediator.Commands.TestimonialCommands
{
    public class RemoveTestimonialCommand : IRequest
    {
        public RemoveTestimonialCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
