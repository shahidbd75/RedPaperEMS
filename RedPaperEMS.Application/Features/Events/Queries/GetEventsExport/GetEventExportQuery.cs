using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace RedPaperEMS.Application.Features.Events.Queries.GetEventsExport
{
    public class GetEventExportQuery: IRequest<EventExportFileVm>
    {
    }
}
