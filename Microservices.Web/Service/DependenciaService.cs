using Microservices.Web.Models;
using Microservices.Web.Models.Dependencia;
using Microservices.Web.Service.IService;
using Microservices.Web.Utility;

namespace Microservices.Web.Service
{
    public class DependenciaService : IDependenciaService

    {
        private readonly IBaseService _baseService;
        public DependenciaService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto> CreateDependenciaAsync(DependenciaRegisterDto dependenciaDto)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.POST,
                Data = dependenciaDto,
                Url = SD.DependenciaAPIBase + "/api/DepedenciaAPI"
            });
        }

        public async Task<ResponseDto> DeleteDependenciaAsync(int dependenciaId)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.DependenciaAPIBase + "/api/DepedenciaAPI/" + dependenciaId
            });
        }

        public async Task<ResponseDto> GetAllDependenciasAsync()
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.GET,
                Url = SD.DependenciaAPIBase + "/api/DepedenciaAPI"
            });
        }

        public async Task<ResponseDto> GetDependenciaByIdAsync(int dependenciaId)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.GET,
                Url = SD.DependenciaAPIBase + "/api/DepedenciaAPI/" + dependenciaId
            });
        }

        public async Task<ResponseDto> GetDependenciaByNameAsync(string name)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.GET,
                Url = SD.DependenciaAPIBase + "/api/DepedenciaAPI/GetByName/" + name
            });
        }

        public async Task<ResponseDto> UpdateDependenciaAsync(DependenciaRegisterDto dependenciaDto)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.PUT,
                Data = dependenciaDto,
                Url = SD.DependenciaAPIBase + "/api/DepedenciaAPI"
            });
        }
    }
}
