using System.ComponentModel.DataAnnotations;

namespace ExamenProgramacionIII.Models
{
    public class MetaPrincipal
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaLimite { get; set; }
        public string Prioridad { get; set; }
        public string Estado { get; set; }

        //Relacion uno a muchos, una meta puede tener muchas tareas
        public ICollection<Tarea> Tareas { get; set; }
    }
}
