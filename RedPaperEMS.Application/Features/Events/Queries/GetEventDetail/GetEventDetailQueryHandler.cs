﻿using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using RedPaperEMS.Application.Contracts.Persistence;
using RedPaperEMS.Domain.Entities;

namespace RedPaperEMS.Application.Features.Events.Queries.GetEventDetail
{
    public class GetEventDetailQueryHandler: IRequestHandler<GetEventDetailQuery, EventDetailVm>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Event> _eventRepository;
        private readonly IAsyncRepository<Category> _categoryRepository;

        public GetEventDetailQueryHandler(IMapper mapper, IAsyncRepository<Event> eventRepository, IAsyncRepository<Category> categoryRepository)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<EventDetailVm> Handle(GetEventDetailQuery request, CancellationToken cancellationToken)
        {
            var @event = await _eventRepository.GetByIdAsync(request.Id);
            var eventDetailDto = _mapper.Map<EventDetailVm>(@event);

            var category = await _categoryRepository.GetByIdAsync(eventDetailDto.CategoryId);
            eventDetailDto.Category = _mapper.Map<CategoryDto>(category);
            return eventDetailDto;
        }
    }
}
