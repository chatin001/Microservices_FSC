using Microservices.Web.Service.IService;
using Microservices.Web.Utility;

namespace Microservices.Web.Service
{
    public class TokenProvider : ITokenProvider
    {
        private readonly IHttpContextAccessor _contextAccesor;

        public TokenProvider(IHttpContextAccessor contextAccesor)
        {
            _contextAccesor = contextAccesor;
        }

        public void ClearTokenAsync()
        {
            _contextAccesor.HttpContext?.Response.Cookies.Delete(SD.TokenCookie);
        }

        public string? GetTokenAsync()
        {
            var context = _contextAccesor.HttpContext;
            if (context != null)
            {
                var cookie = context.Request.Cookies[SD.TokenCookie];
                Console.WriteLine($"Token from cookie: {cookie}");
                return cookie;
            }
            Console.WriteLine("HttpContext is null, cannot retrieve token from cookie.");
            return null;
        }

        public void SetTokenAsync(string token)
        {
            _contextAccesor.HttpContext?.Response.Cookies.Append(SD.TokenCookie, token);
        }
    }
}
