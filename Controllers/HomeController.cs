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






        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}