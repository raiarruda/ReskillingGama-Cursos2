using AutoMapper;
using Cursos.Models.Entidades;
using Cursos.Models.ViewModels;

namespace Cursos.Aplicacao.Mapper
{
    public class CursosMapper : Profile
    {
        public CursosMapper()
        {
            CreateMap<Curso, CursoViewModel>();
            CreateMap<PostagemBlog, PostagemBlogViewModel>();
            CreateMap<Aula, AulaViewModel>();
        }
                
                

    }
}
