using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using livrariaDB.Models;

namespace livrariaDB.Controllers
{
    public class LivroController : Controller
    {
        private readonly Contexto _context;

        public LivroController(Contexto context)
        {
            _context = context;
        }

        // GET: Livro
        public async Task<IActionResult> Index()
        {
              return _context.livro != null ? 
                          View(await _context.livro.ToListAsync()) :
                          Problem("Entity set 'Contexto.livro'  is null.");
        }

        // GET: Livro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.livro == null)
            {
                return NotFound();
            }

            var livro = await _context.livro
                .FirstOrDefaultAsync(m => m.livroId == id);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        // GET: Livro/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Livro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("livroId,livroTitulo,livroAutor,livroPublicacao,genero,isbn,quantidade")] Livro livro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(livro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(livro);
        }

        // GET: Livro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.livro == null)
            {
                return NotFound();
            }

            var livro = await _context.livro.FindAsync(id);
            if (livro == null)
            {
                return NotFound();
            }
            return View(livro);
        }

        // POST: Livro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("livroId,livroTitulo,livroAutor,livroPublicacao,genero,isbn,quantidade")] Livro livro)
        {
            if (id != livro.livroId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(livro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LivroExists(livro.livroId))
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
            return View(livro);
        }

        // GET: Livro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.livro == null)
            {
                return NotFound();
            }

            var livro = await _context.livro
                .FirstOrDefaultAsync(m => m.livroId == id);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        // POST: Livro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.livro == null)
            {
                return Problem("Entity set 'Contexto.livro'  is null.");
            }
            var livro = await _context.livro.FindAsync(id);
            if (livro != null)
            {
                _context.livro.Remove(livro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LivroExists(int id)
        {
          return (_context.livro?.Any(e => e.livroId == id)).GetValueOrDefault();
        }
    }
}
