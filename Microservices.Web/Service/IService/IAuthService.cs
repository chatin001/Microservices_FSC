using Microservices.Web.Models;
using Microservices.Web.Models.Auth;

namespace Microservices.Web.Service.IService
{
    public interface IAuthService
    {
        Task<ResponseDto?> RegisterAsync(RegistrationRequestDtoRole registrationRequestDto);
        Task<ResponseDto?> LoginAsync(LoginRequestDto loginRequestDto);
        Task<ResponseDto?> AssignRoleAsync(RegistrationRequestDtoRole registrationRequestDtoRole);
    }
}
