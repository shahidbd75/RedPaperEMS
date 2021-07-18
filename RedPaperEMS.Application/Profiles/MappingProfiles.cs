using AutoMapper;
using RedPaperEMS.Application.Features.Categories.Commands.CreateCategory;
using RedPaperEMS.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using RedPaperEMS.Application.Features.Categories.Queries.GetCategoryList;
using RedPaperEMS.Application.Features.Events.Commands.CreateEvent;
using RedPaperEMS.Application.Features.Events.Commands.UpdateEvent;
using RedPaperEMS.Application.Features.Events.Queries.GetEventDetail;
using RedPaperEMS.Application.Features.Events.Queries.GetEventList;
using RedPaperEMS.Domain.Entities;

namespace RedPaperEMS.Application.Profiles
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<Event, EventListVm>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<Event, CategoryEventDto>().ReverseMap();
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, CategoryListVm>().ReverseMap();
            CreateMap<Category, CategoryEventListVm>().ReverseMap();
        }
    }
}
