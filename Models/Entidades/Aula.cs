using System.ComponentModel.DataAnnotations;

namespace Cursos.Models.Entidades
{
    public class Aula
    {
        [Key]
        public int Id { get; set; }
        public int numeroOrdem { get; set; }
        public string titulo { get; set; }
        public string descricao { get; set; }
        
        public int cursoId { get; set; }

        public virtual Curso? curso { get; set; }
    }
}
