using System.ComponentModel.DataAnnotations;

namespace Microservices.Services.DependenciasAPI.Models
{
    public class Dependencia
    {
        [Key]
        public int DependenciaId { get; set; }
        [Required]
        public string DependenciaName { get; set; }
        [Required]
        public string DependenciaAbrev { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
