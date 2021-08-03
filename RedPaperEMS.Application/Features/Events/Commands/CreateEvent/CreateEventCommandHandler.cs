using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
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
        private readonly IEmailService _emailService;
        private ILogger<CreateEventCommand> _logger;
        public CreateEventCommandHandler(IEventRepository eventRepository, IMapper mapper, IEmailService emailService, ILogger<CreateEventCommand> logger)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
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
                _logger.LogError($"Mailing about event {@event.EventId} failed due to an error with the email service:{e.Message}");
            }
            return @event.EventId;
        }
    }
}
