using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieDB.Data;
using MovieDB.Models;

namespace MovieDB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TitratController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TitratController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Titrat
        public async Task<IActionResult> Index()
        {
            return View(await _context.Titrat.ToListAsync());
        }

        // GET: Admin/Titrat/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var titrat = await _context.Titrat
                .FirstOrDefaultAsync(m => m.Titrat_ID == id);
            if (titrat == null)
            {
                return NotFound();
            }

            return View(titrat);
        }

        // GET: Admin/Titrat/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Titrat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Titrat_ID,Titrat_Name")] Titrat titrat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(titrat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(titrat);
        }

        // GET: Admin/Titrat/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var titrat = await _context.Titrat.FindAsync(id);
            if (titrat == null)
            {
                return NotFound();
            }
            return View(titrat);
        }

        // POST: Admin/Titrat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Titrat_ID,Titrat_Name")] Titrat titrat)
        {
            if (id != titrat.Titrat_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(titrat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TitratExists(titrat.Titrat_ID))
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
            return View(titrat);
        }

        // GET: Admin/Titrat/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var titrat = await _context.Titrat
                .FirstOrDefaultAsync(m => m.Titrat_ID == id);
            if (titrat == null)
            {
                return NotFound();
            }

            return View(titrat);
        }

        // POST: Admin/Titrat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var titrat = await _context.Titrat.FindAsync(id);
            _context.Titrat.Remove(titrat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TitratExists(int id)
        {
            return _context.Titrat.Any(e => e.Titrat_ID == id);
        }
    }
}
