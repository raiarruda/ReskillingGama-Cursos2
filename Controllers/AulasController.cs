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
  
        private readonly IAulasRepository _aulasRepository;

        public AulasController(IAulasRepository aulasRepository)
        {
            _aulasRepository = aulasRepository;
  
   
        }

        [Authorize]
        public async Task<IActionResult> Manage(int id)
        {
            if (id != null)
            {
                var aulasPorCurso = new AulaViewModel();

                 
                aulasPorCurso.Aulas = _aulasRepository.ObterPorCurso(id);
                aulasPorCurso.idCurso = id;
                return View(aulasPorCurso);
            }
            else {

                var context = _aulasRepository.ObterTodos();

                return View(context);
            }

          
        }

        [Authorize]
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

        [Authorize]
        public IActionResult Create(int id)
        {
            
        
            var aula = new Aula();
            aula.cursoId = id;
        
            return View(aula);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("numeroOrdem,titulo,descricao, cursoId")] Aula aula)
        {
          
            if (ModelState.IsValid)
            {
                _aulasRepository.CriarNovo(aula);
                _aulasRepository.Salvar();
                return RedirectToAction(nameof(Manage), new {id=aula.cursoId});
            }
         
            return View(aula);
        }

        [Authorize]
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
            return View(aula);
        }

        
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
                return RedirectToAction(nameof(Manage), new { id = aula.cursoId });
            }
    
            return View(aula);
        }

        [Authorize]
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

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aula = _aulasRepository.ObterPorId(id);
            _aulasRepository.Deleta(aula);
            _aulasRepository.Salvar();
            return RedirectToAction(nameof(Manage), new { id = aula.cursoId });
        }

        private bool AulaExists(int id)
        {
            return _aulasRepository.Exists(id);
        }
    }
}
