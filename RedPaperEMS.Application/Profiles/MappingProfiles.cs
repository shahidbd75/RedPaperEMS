using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using RedPaperEMS.Application.Features.Events;
using RedPaperEMS.Domain.Entities;

namespace RedPaperEMS.Application.Profiles
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<Event, EventListVm>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
