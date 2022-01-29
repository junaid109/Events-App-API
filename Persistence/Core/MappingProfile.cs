using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, Event>();
        }
    }
}
