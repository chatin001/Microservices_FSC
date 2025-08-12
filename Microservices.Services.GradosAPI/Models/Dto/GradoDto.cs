namespace Microservices.Services.GradosAPI.Models.Dto
{
    public class GradoDto
    {
        public int GradoId { get; set; }
        public string GradoCode { get; set; }
        public string GradoName { get; set; }
        public string GradoAbrev { get; set; }
        public bool IsActive { get; set; }
    }
}

