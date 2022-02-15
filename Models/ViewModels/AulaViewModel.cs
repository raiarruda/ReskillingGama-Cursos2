using Cursos.Models.Entidades;

namespace Cursos.Models.ViewModels
{
    public class AulaViewModel
    {
        public IEnumerable<Aula> Aulas { get; set; }

        public int idCurso { get; set; }
    }
}
