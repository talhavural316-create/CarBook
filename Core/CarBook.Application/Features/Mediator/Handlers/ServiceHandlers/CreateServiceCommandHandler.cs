using CarBook.Application.Features.Mediator.Commands.ServiceCommands;
using CarBook.Application.İnterfaces;
using CarBook.Domain.Entities;

using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand>
    {
        private readonly IRepository<CarBook.Domain.Entities.Service> _repository;

        public CreateServiceCommandHandler(IRepository<CarBook.Domain.Entities.Service> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new CarBook.Domain.Entities.Service
            {
                Title = request.Title,
                Description = request.Description,
                IconUrl = request.IconUrl
            });
        }
    }
}