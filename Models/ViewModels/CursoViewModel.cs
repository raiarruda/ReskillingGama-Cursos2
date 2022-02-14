using Cursos.Models.Entidades;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Cursos.Models.ViewModels
{
    public class CursoViewModel
    {
        public int Id { get; set; }
        [DisplayName("Icone do curso")]
        public string thumbnail { get; set; }
        [DisplayName("Nome do curso")]
        public string nome { get; set; }
        [DisplayName("O que você vai aprender")]
        public string resumo { get; set; }
        [DisplayName("Detalhes do curso")]
        public string descricao { get; set; }
        [DisplayName("Publico Alvo")]
        public string publicoAlvo { get; set; }
        [DisplayName("Carga Horária")]
        public int cargaHoraria { get; set; }

        public IEnumerable<Aula> aulas { get; set; }
    }
}