using AutoMapper;
using MediatorPatternExample.Models;
using MediatorPatternExample.Models.Commands;
using MediatorPatternExample.Models.DTOs;
using MediatorPatternExample.Models.Entities;

namespace MediatorPatternExample.Mappings
{
    public class ValueMappingProfile : Profile
    {
        public ValueMappingProfile()
        {
            CreateMap<ValueEntity, ValueModel>();
            CreateMap<ValueModel, ValueDTO>();
            CreateMap<CreateValueCommand, ValueModel>();
        }
    }
}
