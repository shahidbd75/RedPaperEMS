﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using RedPaperEMS.Application.Contracts.Infrastructure;
using RedPaperEMS.Application.Contracts.Persistence;
using RedPaperEMS.Domain.Entities;

namespace RedPaperEMS.Application.Features.Events.Queries.GetEventsExport
{
    public class GetEventExportQueryHandler:IRequestHandler<GetEventExportQuery, EventExportFileVm>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Event> _eventRepository;
        private readonly ICsvExporter _csvExporter;

        public GetEventExportQueryHandler(IMapper mapper, IAsyncRepository<Event> evenRepository, ICsvExporter csvExporter)
        {
            _mapper = mapper;
            _eventRepository = evenRepository;
            _csvExporter = csvExporter;
        }

        public async Task<EventExportFileVm> Handle(GetEventExportQuery request, CancellationToken cancellationToken)
        {
            var allEvents =
                _mapper.Map<List<EventExportDto>>((await _eventRepository.ListAllAsync()).OrderBy(x => x.Date));

            var fileData = _csvExporter.ExportEventsToCsv(allEvents);

            var eventExportFileDto = new EventExportFileVm{ContentType = "text/csv", Data = fileData, EventExportFileName = $"{Guid.NewGuid()}.csv"};
            return eventExportFileDto;
        }
    }
}
