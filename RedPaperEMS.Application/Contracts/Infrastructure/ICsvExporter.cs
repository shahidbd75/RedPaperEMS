using System;
using System.Collections.Generic;
using System.Text;
using RedPaperEMS.Application.Features.Events.Queries.GetEventsExport;

namespace RedPaperEMS.Application.Contracts.Infrastructure
{
    public interface ICsvExporter
    {
        byte[] ExportEventsToCsv(List<EventExportDto> allEvents);
    }
}
