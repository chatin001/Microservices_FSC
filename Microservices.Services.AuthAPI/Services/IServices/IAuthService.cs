using Microservices.Services.AuthAPI.Models.Dto;

namespace Microservices.Services.AuthAPI.Services.IServices

//Metodos para hacer autenticacion (service-iservices)
{
    public interface IAuthService
    {
        Task<string> Register(RegistrationRequestDto registrationRequestDto);
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
        Task<bool> AssignRole(string email, string roleName);
    }
}
