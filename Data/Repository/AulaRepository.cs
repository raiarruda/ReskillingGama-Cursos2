using Cursos.Models.Entidades;
using WebApplication2.Dominio.Interfaces;

namespace WebApplication2.Data.Repository
{
    public class AulaRepository : Repository<Aula>, IAulasRepository
    {

        public AulaRepository(ApplicationDbContext context) : base(context)
        {

        }

        public override List<Aula> ObterTodos()
        {
            return _context.Aula.ToList();
        }

        public override Aula ObterPorId(int id)
        {
            return _context.Aula.Find(id);
        }


        public override bool Exists(int id)
        {
            return _context.Aula.Any(e => e.Id == id);
        }

        public List<Aula> ObterPorCurso(int id)
        {
            return _context.Aula.Where(c => c.cursoId == id).ToList();
        }
    }
}
