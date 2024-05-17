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
    public class EmprestimoController : Controller
    {
        private readonly Contexto _context;

        public EmprestimoController(Contexto context)
        {
            _context = context;

        }

        // GET: Emprestimo
        public async Task<IActionResult> Index()
        {
            var contexto = _context.emprestimo.Include(e => e.livroEmprestimo);
            return View(await contexto.ToListAsync());
        }

        // GET: Emprestimo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.emprestimo == null)
            {
                return NotFound();
            }

            var emprestimo = await _context.emprestimo
                .Include(e => e.livroEmprestimo)
                .FirstOrDefaultAsync(m => m.emprestimoId == id);
            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        // GET: Emprestimo/Create
        public IActionResult Create()
        {
            ViewData["livroTitulo"] = new SelectList(_context.livro, "livroId", "livroTitulo");
            ViewData["livroId"] = new SelectList(_context.livro, "livroId", "livroId");
            return View();
        }

        // POST: Emprestimo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("emprestimoId,livroId,dataEmprestimo,dataDevolucao,cliente")] Emprestimo emprestimo)
        {
            var livro = await _context.livro.FindAsync(emprestimo.livroId);
            if (ModelState.IsValid)
            {
                if (livro != null && livro.quantidade > 0)
                {
                    livro.quantidade--;
                    _context.Update(livro);
                    _context.Add(emprestimo);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(emprestimo);
                }

            }
            ViewData["livroTitulo"] = new SelectList(_context.livro, "livroId", "livroTitulo");
            ViewData["livroId"] = new SelectList(_context.livro, "livroId", "livroId");

            return View(emprestimo);
        }

        // GET: Emprestimo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.emprestimo == null)
            {
                return NotFound();
            }

            var emprestimo = await _context.emprestimo.FindAsync(id);
            if (emprestimo == null)
            {
                return NotFound();
            }
            ViewData["livroTitulo"] = new SelectList(_context.livro, "livroId", "livroTitulo");
            ViewData["livroId"] = new SelectList(_context.livro, "livroId", "livroId", emprestimo.livroId);

            return View(emprestimo);
        }

        // POST: Emprestimo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("emprestimoId,livroId,dataEmprestimo,dataDevolucao,cliente")] Emprestimo emprestimo)
        {
            if (id != emprestimo.emprestimoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emprestimo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmprestimoExists(emprestimo.emprestimoId))
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
            ViewData["livroId"] = new SelectList(_context.livro, "livroId", "livroId", emprestimo.livroId);
            return View(emprestimo);
        }

        // GET: Emprestimo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.emprestimo == null)
            {
                return NotFound();
            }

            var emprestimo = await _context.emprestimo
                .Include(e => e.livroEmprestimo)
                .FirstOrDefaultAsync(m => m.emprestimoId == id);
            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        // POST: Emprestimo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.emprestimo == null)
            {
                return Problem("Entity set 'Contexto.emprestimo'  is null.");
            }
            var emprestimo = await _context.emprestimo.FindAsync(id);
            if (emprestimo != null)
            {
                _context.emprestimo.Remove(emprestimo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmprestimoExists(int id)
        {
          return (_context.emprestimo?.Any(e => e.emprestimoId == id)).GetValueOrDefault();
        }
    }
}
