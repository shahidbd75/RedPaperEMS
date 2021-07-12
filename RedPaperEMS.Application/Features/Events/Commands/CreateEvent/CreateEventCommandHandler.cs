using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using RedPaperEMS.Application.Contracts.Persistence;
using RedPaperEMS.Application.Exceptions;
using RedPaperEMS.Domain.Entities;

namespace RedPaperEMS.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler: IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        public CreateEventCommandHandler(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateEventCommandValidator(_eventRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if(validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);
            var @event = _mapper.Map<Event>(request);

            @event = await _eventRepository.AddAsync(@event);

            return @event.EventId;
        }
    }
}
