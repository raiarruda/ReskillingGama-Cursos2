using Cursos.Models.Entidades;
using WebApplication2.Dominio.Interfaces;

namespace WebApplication2.Data.Repository
{
    public class ProfessoresRepository : Repository<Professor>, IProfessoresRepository
    {

        public ProfessoresRepository(ApplicationDbContext context) : base(context)
        {

        }

        public override List<Professor> ObterTodos()
        {
            return _context.Professor.OrderBy(c => c.nome).ToList();
        }

        public override Professor ObterPorId(int id)
        {
            return _context.Professor.Find(id);
        }


        public override bool Exists(int id)
        {
            return _context.Professor.Any(e => e.Id == id);
        }


    }
}
