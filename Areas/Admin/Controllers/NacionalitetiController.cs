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
    public class NacionalitetiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NacionalitetiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Nacionaliteti
        public async Task<IActionResult> Index()
        {
            return View(await _context.Nacionaliteti.ToListAsync());
        }

        // GET: Admin/Nacionaliteti/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nacionaliteti = await _context.Nacionaliteti
                .FirstOrDefaultAsync(m => m.Nacionaliteti_ID == id);
            if (nacionaliteti == null)
            {
                return NotFound();
            }

            return View(nacionaliteti);
        }

        // GET: Admin/Nacionaliteti/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Nacionaliteti/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nacionaliteti_ID,Nacionaliteti_Name")] Nacionaliteti nacionaliteti)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nacionaliteti);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nacionaliteti);
        }

        // GET: Admin/Nacionaliteti/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nacionaliteti = await _context.Nacionaliteti.FindAsync(id);
            if (nacionaliteti == null)
            {
                return NotFound();
            }
            return View(nacionaliteti);
        }

        // POST: Admin/Nacionaliteti/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nacionaliteti_ID,Nacionaliteti_Name")] Nacionaliteti nacionaliteti)
        {
            if (id != nacionaliteti.Nacionaliteti_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nacionaliteti);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NacionalitetiExists(nacionaliteti.Nacionaliteti_ID))
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
            return View(nacionaliteti);
        }

        // GET: Admin/Nacionaliteti/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nacionaliteti = await _context.Nacionaliteti
                .FirstOrDefaultAsync(m => m.Nacionaliteti_ID == id);
            if (nacionaliteti == null)
            {
                return NotFound();
            }

            return View(nacionaliteti);
        }

        // POST: Admin/Nacionaliteti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nacionaliteti = await _context.Nacionaliteti.FindAsync(id);
            _context.Nacionaliteti.Remove(nacionaliteti);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NacionalitetiExists(int id)
        {
            return _context.Nacionaliteti.Any(e => e.Nacionaliteti_ID == id);
        }
    }
}
