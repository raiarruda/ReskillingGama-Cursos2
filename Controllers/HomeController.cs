using AutoMapper;
using Cursos.Models;
using Cursos.Models.Entidades;
using Cursos.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplication2.Data;
using WebApplication2.Models;

namespace Cursos.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public HomeController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel();

            List<Curso> cursos = _context.Curso.ToList();
            List<PostagemBlog> postagens = _context.PostagemBlogs.OrderByDescending(p => p.dataPublicacao).ToList();

            homeViewModel.Cursos = _mapper.Map<List<CursoViewModel>>(cursos);
            homeViewModel.Postagens = _mapper.Map<List<PostagemBlogViewModel>>(postagens);

            return View(homeViewModel);
        }



        public IActionResult CursosIndex()
        {
            List<Curso> cursos = _context.Curso.OrderBy(c => c.nome).ToList();
          

            return View(cursos);
        }

        public async Task<IActionResult> CursosDetalhes(int? id)
        {



            if (id == null)
            {
                return NotFound();
            }

            var curso = await _context.Curso.FirstOrDefaultAsync(m => m.Id == id);
            CursoViewModel cursoViewModel = new CursoViewModel();
            List<Aula> aulasCurso = _context.Aula.Where(c => c.cursoId == id).ToList();

            if (curso == null)
            {
                return NotFound();
            }

            cursoViewModel.Id = curso.Id;
            cursoViewModel.thumbnail = curso.thumbnail;
            cursoViewModel.nome = curso.nome;
            cursoViewModel.resumo = curso.resumo;
            cursoViewModel.descricao = curso.descricao;
            cursoViewModel.cargaHoraria = curso.cargaHoraria;
            cursoViewModel.publicoAlvo = curso.publicoAlvo;
            cursoViewModel.aulas = aulasCurso;


            return View(cursoViewModel);
        }



        public IActionResult PRofessoresIndex()
        {

            List<Professor> professores = _context.Professor.OrderBy(c => c.nome).ToList();


            return View(professores);
          
        }



        public IActionResult BlogIndex()
        {
            List<PostagemBlog> postagens = _context.PostagemBlogs.OrderByDescending(c => c.dataPublicacao).ToList();


            return View(postagens);
        }

        public async Task<IActionResult> BlogPostagem(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postagemBlog = await _context.PostagemBlogs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postagemBlog == null)
            {
                return NotFound();
            }

            return View(postagemBlog);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}