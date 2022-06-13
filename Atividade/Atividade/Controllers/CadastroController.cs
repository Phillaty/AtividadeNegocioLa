using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Atividade.Models;

namespace Atividade.Controllers
{
    public class CadastroController : Controller
    {
        private readonly Context _context;

        public CadastroController(Context context)
        {
            _context = context;
        }

        // GET: Cadastro
        public async Task<IActionResult> Index()
        {
              return _context.Cadastro != null ? 
                          View(await _context.Cadastro.ToListAsync()) :
                          Problem("Entity set 'Context.Cadastro'  is null.");
        }

        // GET: Cadastro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cadastro == null)
            {
                return NotFound();
            }

            var dtoCadastro = await _context.Cadastro
                .FirstOrDefaultAsync(m => m.id == id);
            if (dtoCadastro == null)
            {
                return NotFound();
            }

            return View(dtoCadastro);
        }

        // GET: Cadastro/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cadastro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nome,email,datanasc,sexo,rua,numero,cep,cidade,estado,mensagem")] DtoCadastro dtoCadastro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dtoCadastro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dtoCadastro);
        }

        // GET: Cadastro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cadastro == null)
            {
                return NotFound();
            }

            var dtoCadastro = await _context.Cadastro.FindAsync(id);
            if (dtoCadastro == null)
            {
                return NotFound();
            }
            return View(dtoCadastro);
        }

        // POST: Cadastro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nome,email,datanasc,sexo,rua,numero,cep,cidade,estado,mensagem")] DtoCadastro dtoCadastro)
        {
            if (id != dtoCadastro.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dtoCadastro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DtoCadastroExists(dtoCadastro.id))
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
            return View(dtoCadastro);
        }

        // GET: Cadastro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cadastro == null)
            {
                return NotFound();
            }

            var dtoCadastro = await _context.Cadastro
                .FirstOrDefaultAsync(m => m.id == id);
            if (dtoCadastro == null)
            {
                return NotFound();
            }

            return View(dtoCadastro);
        }

        // POST: Cadastro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cadastro == null)
            {
                return Problem("Entity set 'Context.Cadastro'  is null.");
            }
            var dtoCadastro = await _context.Cadastro.FindAsync(id);
            if (dtoCadastro != null)
            {
                _context.Cadastro.Remove(dtoCadastro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DtoCadastroExists(int id)
        {
          return (_context.Cadastro?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
