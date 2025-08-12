using Microservices.Web.Models;
using Microservices.Web.Models.Dependencia;

namespace Microservices.Web.Service.IService
{
    public interface IDependenciaService
    {
        Task<ResponseDto> GetAllDependenciasAsync();
        Task<ResponseDto> GetDependenciaByIdAsync(int dependenciaId);
        Task<ResponseDto> GetDependenciaByNameAsync(string name);
        Task<ResponseDto> CreateDependenciaAsync(DependenciaRegisterDto dependenciaDto);
        Task<ResponseDto> UpdateDependenciaAsync(DependenciaRegisterDto dependenciaDto);
        Task<ResponseDto> DeleteDependenciaAsync(int dependenciaId);
  

    }
}
