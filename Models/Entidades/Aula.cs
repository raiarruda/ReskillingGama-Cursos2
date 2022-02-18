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
        [StringLength(50, ErrorMessage = "Limite de 50 caracteres")]
        public string titulo { get; set; }
        [Display(Name ="Resumo")]
        [StringLength(150, ErrorMessage = "Limite de 150 caracteres")]
        public string descricao { get; set; }
        [Display(Name ="Curso")]
        public int cursoId { get; set; }

        public virtual Curso? curso { get; set; }
    }
}
