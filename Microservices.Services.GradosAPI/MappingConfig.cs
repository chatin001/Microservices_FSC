using AutoMapper;
using Microservices.Services.GradosAPI.Models;
using Microservices.Services.GradosAPI.Models.Dto;

namespace Microservices.Services.GradosAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappinfConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Grado, GradoDto>().ReverseMap();
            });

            return mappinfConfig;
        }
    }
}
