using WebApplication2.Dominio.Interfaces;

namespace WebApplication2.Data.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Atualiza(T entidade)
        {
            _context.Update(entidade);
        }

        public void CriarNovo(T entidade)
        {
            _context.Add(entidade);
        }

        public void Deleta(T entidade)
        {
            _context.Remove(entidade);
        }

        public abstract bool Exists(int id);

        public abstract T ObterPorId(int id);
        public abstract List<T> ObterTodos();

        public bool Salvar()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
