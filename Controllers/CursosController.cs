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

namespace Cursos.Controllers
{
    public class CursosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CursosController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Cursos
        public async Task<IActionResult> Manage()
        {
            return View(await _context.Curso.ToListAsync());
        }

        // GET: Cursos/Details/5
        public async Task<IActionResult> Details(int? id)
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
            cursoViewModel.thumbnail=curso.thumbnail;
            cursoViewModel.nome = curso.nome;
            cursoViewModel.resumo = curso.resumo;
            cursoViewModel.descricao = curso.descricao;
            cursoViewModel.cargaHoraria = curso.cargaHoraria;
            cursoViewModel.publicoAlvo = curso.publicoAlvo;
            cursoViewModel.aulas = aulasCurso;


            return View(cursoViewModel);
        }

        // GET: Cursos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cursos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,thumbnail,nome,resumo,descricao,publicoAlvo,cargaHoraria")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(curso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(curso);
        }

        // GET: Cursos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = await _context.Curso.FindAsync(id);
            if (curso == null)
            {
                return NotFound();
            }
            return View(curso);
        }

        // POST: Cursos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
                    _context.Update(curso);
                    await _context.SaveChangesAsync();
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

        // GET: Cursos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = await _context.Curso
                .FirstOrDefaultAsync(m => m.Id == id);
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        // POST: Cursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var curso = await _context.Curso.FindAsync(id);
            _context.Curso.Remove(curso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CursoExists(int id)
        {
            return _context.Curso.Any(e => e.Id == id);
        }


        //controllers de páginas publicas 



        public IActionResult Index()
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





    }
}
