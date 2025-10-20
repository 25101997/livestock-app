using AutoMapper;
using API.Application.DTOs;
using API.Application.Models;

namespace API.Application.Mapping
{
    public class AnimalProfile : Profile
    {
        public AnimalProfile()
        {
            CreateMap<Animal, AnimalDto>();
            CreateMap<AnimalDto, Animal>();
        }
    }
}
