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
using Microsoft.AspNetCore.Authorization;

namespace Cursos.Controllers
{
    public class PostagensBlogController : Controller
    {
        private readonly IPostagensBlogRepository _postagemBlogRepository;

        public PostagensBlogController(IPostagensBlogRepository postagemBlogRepository)
        {
            _postagemBlogRepository=postagemBlogRepository;
        }

        [Authorize]
        public async Task<IActionResult> Manage()
        {
            return View(_postagemBlogRepository.ObterTodos());
        }

        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postagemBlog = _postagemBlogRepository.ObterPorId(id);
            if (postagemBlog == null)
            {
                return NotFound();
            }

            return View(postagemBlog);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,tituloPost,imagemCapa,conteudo,autor")] PostagemBlog postagemBlog)
        {
            if (ModelState.IsValid)
            {
                _postagemBlogRepository.CriarNovo(postagemBlog);
                _postagemBlogRepository.Salvar();
                return RedirectToAction(nameof(Index));
            }
            return View(postagemBlog);
        }

        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postagemBlog = _postagemBlogRepository.ObterPorId(id);
            if (postagemBlog == null)
            {
                return NotFound();
            }
            return View(postagemBlog);
        }


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
                    _postagemBlogRepository.Atualiza(postagemBlog);
                    _postagemBlogRepository.Salvar();
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


        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postagemBlog = _postagemBlogRepository.ObterPorId(id);
            if (postagemBlog == null)
            {
                return NotFound();
            }

            return View(postagemBlog);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var postagemBlog = _postagemBlogRepository.ObterPorId(id);
            _postagemBlogRepository.Deleta(postagemBlog);
            _postagemBlogRepository.Salvar();
            return RedirectToAction(nameof(Index));
        }


        [HttpPost, ActionName("Like")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Like(int id)
        {
            var postagemBlog = _postagemBlogRepository.ObterPorId(id);
            postagemBlog.gostei += 1;

            _postagemBlogRepository.Atualiza(postagemBlog);
            _postagemBlogRepository.Salvar();
            return RedirectToAction(nameof(Post), new {@id = id});
        }


        [HttpPost, ActionName("Dislike")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Dislike(int id)
        {
            var postagemBlog = _postagemBlogRepository.ObterPorId(id);
            postagemBlog.naoGostei += 1;

            _postagemBlogRepository.Atualiza(postagemBlog);
            _postagemBlogRepository.Salvar();
            return RedirectToAction(nameof(Post), new { @id = id });
        }

        private bool PostagemBlogExists(int id)
        {
            return _postagemBlogRepository.Exists(id);
        }

    

        public IActionResult Index()
        {
            List<PostagemBlog> postagens = _postagemBlogRepository.ObterTodos();


            return View(postagens);
        }

        public async Task<IActionResult> Post(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postagemBlog = _postagemBlogRepository.ObterPorId(id);
            if (postagemBlog == null)
            {
                return NotFound();
            }

            return View(postagemBlog);
        }



    }
}
