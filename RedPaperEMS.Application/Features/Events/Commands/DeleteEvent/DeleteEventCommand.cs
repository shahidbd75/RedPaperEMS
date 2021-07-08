using System;
using MediatR;

namespace RedPaperEMS.Application.Features.Events.Commands.DeleteEvent
{
    public class DeleteEventCommand:IRequest
    {
        public Guid EventId { get; set; }
    }
}
