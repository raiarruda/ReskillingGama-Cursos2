using Cursos.Models.Entidades;

namespace WebApplication2.Dominio.Interfaces
{
    public interface IAulasRepository : IRepository<Aula>
    {
        List<Aula> ObterPorCurso(int id);
    }
}
