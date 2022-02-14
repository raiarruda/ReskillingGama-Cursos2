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

namespace Cursos.Controllers
{
    public class PostagensBlogController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PostagensBlogController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PostagensBlog
        public async Task<IActionResult> Index()
        {
            return View(await _context.PostagemBlogs.OrderByDescending(p=>p.dataPublicacao).ToListAsync());
        }

        // GET: PostagensBlog/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: PostagensBlog/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PostagensBlog/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,tituloPost,imagemCapa,conteudo,gostei,naoGostei,dataPublicacao,autor")] PostagemBlog postagemBlog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(postagemBlog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(postagemBlog);
        }

        // GET: PostagensBlog/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postagemBlog = await _context.PostagemBlogs.FindAsync(id);
            if (postagemBlog == null)
            {
                return NotFound();
            }
            return View(postagemBlog);
        }

        // POST: PostagensBlog/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,tituloPost,imagemCapa,conteudo,gostei,naoGostei,dataPublicacao,autor")] PostagemBlog postagemBlog)
        {
            if (id != postagemBlog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postagemBlog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostagemBlogExists(postagemBlog.Id))
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
            return View(postagemBlog);
        }

        // GET: PostagensBlog/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: PostagensBlog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var postagemBlog = await _context.PostagemBlogs.FindAsync(id);
            _context.PostagemBlogs.Remove(postagemBlog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostagemBlogExists(int id)
        {
            return _context.PostagemBlogs.Any(e => e.Id == id);
        }
    }
}
