#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cursos.Models.Entidades;
using AutoMapper;
using Cursos.Models.ViewModels;
using WebApplication2.Data;
using WebApplication2.Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Cursos.Controllers
{
    public class CursosController : Controller
    {
        
        private readonly IMapper _mapper;
        private readonly ICursosRepository _cursoRepository;
        private readonly IAulasRepository _aulasRepository;
        public CursosController(ICursosRepository cursosRepository, IAulasRepository aulasRepository, IMapper mapper)
        {
            _cursoRepository = cursosRepository;
            _aulasRepository = aulasRepository;
            _mapper = mapper;
        }

        [Authorize]
        public async Task<IActionResult> Manage()
        {
            return View(_cursoRepository.ObterTodos());
        }

      
        public async Task<IActionResult> Details(int id)
        {
           


            if (id == null)
            {
                return NotFound();
            }

            var curso = _cursoRepository.ObterPorId(id);
            CursoViewModel cursoViewModel = new CursoViewModel();
            List<Aula> aulasCurso = _aulasRepository.ObterPorCurso(id);

            if (curso == null)
            {
                return NotFound();
            }

            cursoViewModel.Id = curso.Id;
            cursoViewModel.thumbnail=curso.thumbnail;
            cursoViewModel.nome = curso.nome;
            cursoViewModel.resumo = curso.resumo;
            cursoViewModel.descricao = curso.descricao;
            cursoViewModel.cargaHoraria = curso.cargaHoraria;
            cursoViewModel.publicoAlvo = curso.publicoAlvo;
            cursoViewModel.aulas = aulasCurso;


            return View(cursoViewModel);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,thumbnail,nome,resumo,descricao,publicoAlvo,cargaHoraria")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                _cursoRepository.CriarNovo(curso);
                _cursoRepository.Salvar();
                return RedirectToAction(nameof(Index));
            }
            return View(curso);
        }

        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = _cursoRepository.ObterPorId(id);
            if (curso == null)
            {
                return NotFound();
            }
            return View(curso);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,thumbnail,nome,resumo,descricao,publicoAlvo,cargaHoraria")] Curso curso)
        {
            if (id != curso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _cursoRepository.Atualiza(curso);
                    _cursoRepository.Salvar();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursoExists(curso.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(curso);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = _cursoRepository.ObterPorId(id);
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var curso = _cursoRepository.ObterPorId(id);
            _cursoRepository.Deleta(curso);
            _cursoRepository.Salvar();
            return RedirectToAction(nameof(Index));
        }

        private bool CursoExists(int id)
        {
            return _cursoRepository.Exists(id);
        }


        //controllers de páginas publicas 



        public IActionResult Index()
        {
            List<Curso> cursos = _cursoRepository.ObterTodos().OrderBy(c => c.nome).ToList();


            return View(cursos);
        }

        public async Task<IActionResult> CursosDetalhes(int id)
        {



            if (id == null)
            {
                return NotFound();
            }

            var curso = _cursoRepository.ObterPorId(id);
            CursoViewModel cursoViewModel = new CursoViewModel();
            List<Aula> aulasCurso = _aulasRepository.ObterPorCurso(id);

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





    }
}
