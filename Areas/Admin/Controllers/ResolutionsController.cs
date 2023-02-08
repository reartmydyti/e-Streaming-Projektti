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
    public class ResolutionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResolutionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Resolutions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Resolution.ToListAsync());
        }

        // GET: Admin/Resolutions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resolution = await _context.Resolution
                .FirstOrDefaultAsync(m => m.Resolution_ID == id);
            if (resolution == null)
            {
                return NotFound();
            }

            return View(resolution);
        }

        // GET: Admin/Resolutions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Resolutions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Resolution_ID,Resolution_Name")] Resolution resolution)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resolution);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(resolution);
        }

        // GET: Admin/Resolutions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resolution = await _context.Resolution.FindAsync(id);
            if (resolution == null)
            {
                return NotFound();
            }
            return View(resolution);
        }

        // POST: Admin/Resolutions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Resolution_ID,Resolution_Name")] Resolution resolution)
        {
            if (id != resolution.Resolution_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resolution);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResolutionExists(resolution.Resolution_ID))
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
            return View(resolution);
        }

        // GET: Admin/Resolutions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resolution = await _context.Resolution
                .FirstOrDefaultAsync(m => m.Resolution_ID == id);
            if (resolution == null)
            {
                return NotFound();
            }

            return View(resolution);
        }

        // POST: Admin/Resolutions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resolution = await _context.Resolution.FindAsync(id);
            _context.Resolution.Remove(resolution);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResolutionExists(int id)
        {
            return _context.Resolution.Any(e => e.Resolution_ID == id);
        }
    }
}
