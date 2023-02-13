using AutoMapper;
using SmartSchool.WebAPI.Helpers;
using SmartSchool.WebAPI.Models;
using SmartSchool.WebAPI.Models.Dto;

namespace SmartSchool.WebAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Student, StudentDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.Name} {src.Surname}"))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => DateTimeExtensions.GetCurrentAge(src.DateBirth)))
                .ReverseMap();

            });

            return mappingConfig;
        }
    }
}
