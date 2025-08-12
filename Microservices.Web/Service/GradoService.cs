using Microservices.Web.Models;
using Microservices.Web.Models.Grado;
using Microservices.Web.Service.IService;
using Microservices.Web.Utility;

namespace Microservices.Web.Service
{
    public class GradoService : IGradoService
    {
        private readonly IBaseService _baseService;

        public GradoService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        //POST

        public async Task<ResponseDto> CreateGradoAsync(GradoRegisterDto gradoDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = gradoDto,
                Url = SD.GradoAPIBase + "/api/GradoAPI"
            });
        }


        //DELETE
        public async Task<ResponseDto> DeleteGradoAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.GradoAPIBase + "/api/GradoAPI/" + id
            });
        }


        //GETALL
        public async Task<ResponseDto> GetAllGradoAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.GradoAPIBase + "/api/GradoAPI"
            });
        }


        //GET GRADO BY CODE
        public async Task<ResponseDto> GetGradoAsync(string gradoCode)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.GradoAPIBase + "/api/GradoAPI/GetByCode/" + gradoCode
            });
        }

        //GT GRADO BY ID
        public async Task<ResponseDto> GetGradoByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.GradoAPIBase + "/api/GradoAPI/" + id
            });
        }

        //UPDATE
        public async Task<ResponseDto> UpdateGradoAsync(GradoRegisterDto gradoDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = gradoDto,
                Url = SD.GradoAPIBase + "/api/GradoAPI"
            });
        }
    }
}