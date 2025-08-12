namespace Microservices.Web.Service.IService
{
    public interface ITokenProvider
    {
        void SetTokenAsync(string token);
        string? GetTokenAsync();
        void ClearTokenAsync();
    }
}
