using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using RedPaperEMS.Application.Contracts.Infrastructure;
using RedPaperEMS.Application.Contracts.Persistence;
using RedPaperEMS.Application.Exceptions;
using RedPaperEMS.Application.Models.Mail;
using RedPaperEMS.Domain.Entities;

namespace RedPaperEMS.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler: IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        private IEmailService _emailService;
        public CreateEventCommandHandler(IEventRepository eventRepository, IMapper mapper, IEmailService emailService)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
            _emailService = emailService;
        }
        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateEventCommandValidator(_eventRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if(validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);
            var @event = _mapper.Map<Event>(request);

            @event = await _eventRepository.AddAsync(@event);

            var email = new Email {To = "abdul.baset@aci-bd.com",Subject = "A new event was created", Body = $"A new event was created: {request}"};

            try
            {
                await _emailService.SendMail(email);
            }
            catch (Exception e)
            {
                // logging in future
            }
            return @event.EventId;
        }
    }
}
