using AutoMapper;
using Microservices.Services.DependenciasAPI.Models;
using Microservices.Services.DependenciasAPI.Models.Dto;

namespace Microservices.Services.DependenciasAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Dependencia, DependenciaDto>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
