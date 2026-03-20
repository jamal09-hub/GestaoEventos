using GestaoEventos.Data;
using GestaoEventos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoEventos.Controllers
{
    public class LocalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LocalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Locals
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Local.ToListAsync());
        }

        // GET: Locals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var local = await _context.Local
                .FirstOrDefaultAsync(m => m.Id == id);
            if (local == null)
            {
                return NotFound();
            }

            return View(local);
        }

        // GET: Locals/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Locals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,Nome,Capaciade")] Local local)
        {
            if (ModelState.IsValid)
            {
                _context.Add(local);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(local);
        }

        // GET: Locals/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var local = await _context.Local.FindAsync(id);
            if (local == null)
            {
                return NotFound();
            }
            return View(local);
        }

        // POST: Locals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Capaciade")] Local local)
        {
            if (id != local.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(local);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocalExists(local.Id))
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
            return View(local);
        }

        // GET: Locals/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var local = await _context.Local
                .FirstOrDefaultAsync(m => m.Id == id);
            if (local == null)
            {
                return NotFound();
            }

            return View(local);
        }

        // POST: Locals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var local = await _context.Local.FindAsync(id);
            if (local != null)
            {
                _context.Local.Remove(local);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocalExists(int id)
        {
            return _context.Local.Any(e => e.Id == id);
        }
    }
}
