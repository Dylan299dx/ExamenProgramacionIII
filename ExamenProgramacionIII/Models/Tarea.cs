using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenProgramacionIII.Models
{
    public class Tarea
    {
        [Key]
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaLimite {  get; set; }
        public string Estado { get; set; }
        public string Dificultad { get; set; }
        public string TiempoEstimado { get; set; }

        public MetaPrincipal Principal { get; set; }
        public int MetaPrincipalId { get; set; }
    }
}
