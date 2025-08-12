
using Microservices.Web.Models;
using Microservices.Web.Service.IService;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using static Microservices.Web.Utility.SD;

namespace Microservices.Web.Service
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ITokenProvider _tokenProvider;

        public BaseService(IHttpClientFactory clientFactory, ITokenProvider tokenProvider)
        {
            _clientFactory = clientFactory;
            _tokenProvider = tokenProvider;
        }

        public async Task<ResponseDto> SendAsync(RequestDto requestDto, bool withBearer = true)

        {
            try
            {
                //Aca enlazamos la API q deseo consumir              
                HttpClient client = _clientFactory.CreateClient("MicroservicesAPI");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");

                //TOKEN
                //*****
                if (withBearer)
                {
                    var token = _tokenProvider.GetTokenAsync();
                    if (!string.IsNullOrEmpty(token))
                    {
                        message.Headers.Add("Authorization", $"Bearer {token}");
                        Console.WriteLine("Using Bearer Token: " + token);
                    }
                    else
                    {
                        Console.WriteLine("No Bearer Token found.");
                    }
                }


                message.RequestUri = new Uri(requestDto.Url); //viene de RequestDto

                message.Method = requestDto.ApiType switch
                {
                    ApiType.GET => HttpMethod.Get,
                    ApiType.POST => HttpMethod.Post,
                    ApiType.PUT => HttpMethod.Put,
                    ApiType.DELETE => HttpMethod.Delete,
                    _ => HttpMethod.Get
                };
                //hacer el envio
                if (requestDto.Data != null)
                {
                    var jsonData = JsonConvert.SerializeObject(requestDto.Data);
                    Console.WriteLine("Request JSON Data:" + jsonData);
                    message.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                }

                // solo para verificar error
                Console.WriteLine($"Sending request to: {message.RequestUri} with method: {message.Method}");

                //obtenemos rpta de envio en el cliente
                HttpResponseMessage apiResponse = await client.SendAsync(message);

                //Capturo el error
                if (apiResponse.IsSuccessStatusCode)
                {
                    var errorContent = await apiResponse.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error response from API: {errorContent} with status code: {apiResponse.StatusCode}");
                }

                switch (apiResponse.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return new() { IsSuccess = false, Message = "No Encontrado" };
                    case HttpStatusCode.Forbidden:
                        return new() { IsSuccess = false, Message = "Acceso Denegado" };
                    case HttpStatusCode.Unauthorized:
                        return new() { IsSuccess = false, Message = "No autorizado..!!!" };
                    case HttpStatusCode.InternalServerError:
                        return new() { IsSuccess = false, Message = "Internal Server Error" };
                    case HttpStatusCode.BadRequest:
                        return new() { IsSuccess = false, Message = "Solicitud Incorrecta" };
                    default:
                        var apiContent = await apiResponse.Content.ReadAsStringAsync();
                        ResponseDto? apiResponseDto = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
                        return apiResponseDto;
                }
            }
            catch (Exception ex)
            {
                return new ResponseDto()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
