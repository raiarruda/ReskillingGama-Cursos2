using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Cursos.Models.Entidades
{
    public class Aula
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Numero")]
        public int numeroOrdem { get; set; }
        [Display(Name ="Titulo")]
        public string titulo { get; set; }
        [Display(Name ="Resumo")]
        public string descricao { get; set; }
        
        public int cursoId { get; set; }

        public virtual Curso? curso { get; set; }
    }
}
