using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace RedPaperEMS.Application.Features.Events
{
    public class GetEventDetailQuery: IRequest<EventDetailVm>
    {
        public Guid Id { get; set; }
    }
}
