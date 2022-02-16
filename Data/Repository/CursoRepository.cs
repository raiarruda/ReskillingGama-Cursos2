using Cursos.Models.Entidades;
using WebApplication2.Dominio.Interfaces;

namespace WebApplication2.Data.Repository
{
    public class CursoRepository : Repository<Curso>, ICursosRepository
    {

        public CursoRepository(ApplicationDbContext context) : base(context)
        {

        }

        public override List<Curso> ObterTodos()
        {
            return _context.Curso.ToList();
        }

        public override Curso ObterPorId(int id)
        {
            return _context.Curso.Find(id);
        }


        public override bool Exists(int id)
        {
            return _context.Curso.Any(e => e.Id == id);
        }


    }
}
