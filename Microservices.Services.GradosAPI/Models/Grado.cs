using System.ComponentModel.DataAnnotations;

namespace Microservices.Services.GradosAPI.Models
{
    public class Grado
    {
        [Key]
        public int GradoId { get; set; }
        [Required]
        public string GradoCode { get; set; }
        [Required]
        public string GradoName { get; set; }
        [Required]
        public string GradoAbrev { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
