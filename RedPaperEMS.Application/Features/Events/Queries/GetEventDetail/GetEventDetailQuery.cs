using System;
using MediatR;

namespace RedPaperEMS.Application.Features.Events.Queries.GetEventDetail
{
    public class GetEventDetailQuery: IRequest<EventDetailVm>
    {
        public Guid Id { get; set; }
    }
}
