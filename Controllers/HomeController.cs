using AutoMapper;
using Cursos.Models;
using Cursos.Models.Entidades;
using Cursos.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplication2.Data;
using WebApplication2.Dominio.Interfaces;
using WebApplication2.Models;

namespace Cursos.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICursosRepository _cursosRepository;
        private readonly IPostagensBlogRepository _postagemBlogRepository;
        private readonly IMapper _mapper;

        public HomeController(IMapper mapper, ICursosRepository cursosRepository, IPostagensBlogRepository postagemBlogRepository)
        {
            _cursosRepository = cursosRepository;
            _postagemBlogRepository = postagemBlogRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel();

            List<Curso> cursos = _cursosRepository.ObterTodos();
            List<PostagemBlog> postagens = _postagemBlogRepository.ObterTodos();

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