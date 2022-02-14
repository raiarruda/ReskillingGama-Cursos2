namespace Cursos.Models.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<CursoViewModel> Cursos { get; set; }
        public IEnumerable<PostagemBlogViewModel> Postagens { get; set; }
    }
}
