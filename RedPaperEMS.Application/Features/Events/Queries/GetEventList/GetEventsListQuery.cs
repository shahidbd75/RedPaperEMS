using System.Collections.Generic;
using MediatR;

namespace RedPaperEMS.Application.Features.Events.Queries.GetEventList
{
    public class GetEventsListQuery: IRequest<List<EventListVm>>
    {
    }
}
