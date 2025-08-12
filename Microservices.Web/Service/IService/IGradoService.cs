using Microservices.Web.Models;
using Microservices.Web.Models.Grado;


namespace Microservices.Web.Service.IService
{
    public interface IGradoService
    {
        Task<ResponseDto> GetGradoAsync(string gradoCode);
        Task<ResponseDto> GetAllGradoAsync();
        Task<ResponseDto> GetGradoByIdAsync(int id);
        Task<ResponseDto> CreateGradoAsync(GradoRegisterDto gradoDto);
        Task<ResponseDto> UpdateGradoAsync(GradoRegisterDto gradoDto);
        Task<ResponseDto> DeleteGradoAsync(int id);
    }
}
