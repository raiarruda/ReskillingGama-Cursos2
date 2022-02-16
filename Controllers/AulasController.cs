#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cursos.Models.Entidades;
using WebApplication2.Data;
using Cursos.Models.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using WebApplication2.Dominio.Interfaces;

namespace Cursos.Controllers
{   [Authorize]
    public class AulasController : Controller
    {
   //     private readonly ApplicationDbContext _context;
        private readonly IAulasRepository _aulasRepository;

        public AulasController(IAulasRepository aulasRepository)
        {
            _aulasRepository = aulasRepository;
  
   
        }

        // GET: Aulas
        public async Task<IActionResult> Manage(int id)
        {
            if (id != null)
            {
                var aulasPorCurso = new AulaViewModel();
                //      var context = _context.Aula.Include(a => a.curso).Where(a => a.cursoId == id).ToList();
                 
                aulasPorCurso.Aulas = _aulasRepository.ObterPorCurso(id);
                aulasPorCurso.idCurso = id;
                return View(aulasPorCurso);
            }
            else {

                var context = _aulasRepository.ObterTodos();

                return View(context);
            }

          
        }

        // GET: Aulas/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aula = _aulasRepository.ObterPorId(id);
            if (aula == null)
            {
                return NotFound();
            }

            return View(aula);
        }

        // GET: Aulas/Create
        public IActionResult Create(int id)
        {
            
         //   ViewData["cursoId"] = new SelectList(_context.Curso, "Id", "nome");
            var aula = new Aula();
            aula.cursoId = id;
        
            return View(aula);
        }

        // POST: Aulas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("numeroOrdem,titulo,descricao, cursoId")] Aula aula)
        {
            //aula.cursoId = id;
            if (ModelState.IsValid)
            {
                _aulasRepository.CriarNovo(aula);
                _aulasRepository.Salvar();
                return RedirectToAction(nameof(Index), new {id=aula.cursoId});
            }
           // ViewData["cursoId"] = new SelectList(_context.Curso, "Id", "nome", aula.cursoId);
            return View(aula);
        }

        // GET: Aulas/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aula = _aulasRepository.ObterPorId(id);
            if (aula == null)
            {
                return NotFound();
            }
        //    ViewData["cursoId"] = new SelectList(_context.Curso, "Id", "Id", aula.cursoId);
            return View(aula);
        }

        // POST: Aulas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,numeroOrdem,titulo,descricao,cursoId")] Aula aula)
        {
            if (id != aula.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _aulasRepository.Atualiza(aula);
                    _aulasRepository.Salvar();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AulaExists(aula.Id))
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
      //      ViewData["cursoId"] = new SelectList(_context.Curso, "Id", "Id", aula.cursoId);
            return View(aula);
        }

        // GET: Aulas/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aula = _aulasRepository.ObterPorId(id);
            if (aula == null)
            {
                return NotFound();
            }

            return View(aula);
        }

        // POST: Aulas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aula = _aulasRepository.ObterPorId(id);
            _aulasRepository.Deleta(aula);
            _aulasRepository.Salvar();
            return RedirectToAction(nameof(Index));
        }

        private bool AulaExists(int id)
        {
            return _aulasRepository.Exists(id);
        }
    }
}
