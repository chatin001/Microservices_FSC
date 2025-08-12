using Microservices.Web.Models;

namespace Microservices.Web.Service.IService
{
    public interface IBaseService
    {
        //Importante desde aca nos conectamos desde la parte front a la parte API
        Task<ResponseDto> SendAsync(RequestDto requestDto, bool withBearer = true);
    }
}
