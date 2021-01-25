using System.Collections.Generic;
using System.Text;
using MediatR;
using RedPaperEMS.Domain.Entities;

namespace RedPaperEMS.Application.Features.Events
{
    public class GetEventsListQuery: IRequest<List<EventListVm>>
    {
    }
}
