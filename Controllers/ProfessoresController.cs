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
using WebApplication2.Dominio.Interfaces;

namespace Cursos.Controllers
{
    public class ProfessoresController : Controller
    {
        //private readonly ApplicationDbContext _context;
        private readonly IProfessoresRepository _professoresRepository;

        public ProfessoresController(IProfessoresRepository professoresRepository)
        {
            _professoresRepository = professoresRepository;
        }

        // GET: Professores
        public async Task<IActionResult> Manage()
        {
            return View(_professoresRepository.ObterTodos());
        }

      
        // GET: Professores/Details/5
        public async Task<IActionResult> Details(int id)
        {
          
            var professor = _professoresRepository.ObterPorId(id);
            if (professor == null)
            {
                return NotFound();
            }

            return View(professor);
        }

        // GET: Professores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Professores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,nome,titulo,sobre,foto,urlFacebook,urlTwitter,urlInstagram")] Professor professor)
        {
            if (ModelState.IsValid)
            {
                _professoresRepository.CriarNovo(professor);
                _professoresRepository.Salvar();
                return RedirectToAction(nameof(Index));
            }
            return View(professor);
        }

        // GET: Professores/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professor = _professoresRepository.ObterPorId(id);
            if (professor == null)
            {
                return NotFound();
            }
            return View(professor);
        }

        // POST: Professores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,nome,titulo,sobre,foto,urlFacebook,urlTwitter,urlInstagram")] Professor professor)
        {
           

            if (ModelState.IsValid)
            {
                try
                {
                    _professoresRepository.Atualiza(professor);
                    _professoresRepository.Salvar();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessorExists(professor.Id))
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
            return View(professor);
        }

        // GET: Professores/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
          
            var professor = _professoresRepository.ObterPorId(id);
            if (professor == null)
            {
                return NotFound();
            }

            return View(professor);
        }

        // POST: Professores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var professor = _professoresRepository.ObterPorId(id);
            _professoresRepository.Deleta(professor);
            _professoresRepository.Salvar();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfessorExists(int id)
        {
            return _professoresRepository.Exists(id);
        }


        //controller publica 

        public IActionResult Index()
        {

            List<Professor> professores = _professoresRepository.ObterTodos() ;


            return View(professores);

        }




    }
}
