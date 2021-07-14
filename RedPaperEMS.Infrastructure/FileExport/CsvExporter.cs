using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using RedPaperEMS.Application.Contracts.Infrastructure;
using RedPaperEMS.Application.Features.Events.Queries.GetEventsExport;

namespace RedPaperEMS.Infrastructure.FileExport
{
    public class CsvExporter: ICsvExporter
    {
        public byte[] ExportEventsToCsv(List<EventExportDto> allEvents)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter,new CsvConfiguration(CultureInfo.CurrentCulture));
                csvWriter.WriteRecords(allEvents);
            }

            return memoryStream.ToArray();
        }
    }
}
