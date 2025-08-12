using System.ComponentModel.DataAnnotations;

namespace Microservices.Web.Models.Dependencia

{
    public class DependenciaDto
    {
        public int DependenciaId { get; set; }
        public string DependenciaName { get; set; }
        public string? DependenciaAbrev { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
