using Cursos.Models.Entidades;
using WebApplication2.Dominio.Interfaces;

namespace WebApplication2.Data.Repository
{
    public class PostagensBlogRepository : Repository<PostagemBlog>, IPostagensBlogRepository
    {

        public PostagensBlogRepository(ApplicationDbContext context) : base(context)
        {

        }

        public override bool Exists(int id)
        {
            return _context.PostagemBlogs.Any(e => e.Id == id);
        }

        public override PostagemBlog ObterPorId(int id)
        {
            return _context.PostagemBlogs.Find(id);
        }

        public override List<PostagemBlog> ObterTodos()
        {
            return  _context.PostagemBlogs.OrderByDescending(p => p.dataPublicacao).ToList();
        }
    }
}
