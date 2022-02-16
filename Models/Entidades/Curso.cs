using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Cursos.Models.Entidades
{
    public class Curso
    {
        public Curso()
        {
            Aulas = new HashSet<Aula>();
        }

        [Key]
        public int Id { get; set; }
        [DisplayName("Imagem")]
        public string thumbnail { get; set; }
        [DisplayName("Nome ")]
        public string nome { get; set; }
        [DisplayName("Resumo")]
        [StringLength(150, ErrorMessage = "Limite de 150 caracteres")]
        public string resumo { get; set; }
        [DisplayName("Descrição")]
        [StringLength(500, ErrorMessage = "Limite de 500 caracteres")]
        public string descricao { get; set; }
        [DisplayName("Público Alvo")]
        public string publicoAlvo { get; set; }
        [DisplayName("Carga Horária")]
        [Range(0, int.MaxValue, ErrorMessage ="Não pode cadastrar curso com carga horária negativa")]
        public int cargaHoraria { get; set; }

        public virtual ICollection<Aula> Aulas { get; set; }





    }
}
