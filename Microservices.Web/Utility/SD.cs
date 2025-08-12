namespace Microservices.Web.Utility
{
    public class SD
    {
        public static string DependenciaAPIBase { get; set; } //Llama la ruta localhost 7003
        public static string GradoAPIBase { get; set; } //Llama la ruta localhost 7001
        public static string AuthAPIBase { get; set; } //Llama la ruta localhost 7002



        public const string RoleAdmin = "ADMIN";

        public const string RoleCustomer = "CUSTOMER";

        public const string TokenCookie = "JwtToken";

        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE

        }
    }
}
