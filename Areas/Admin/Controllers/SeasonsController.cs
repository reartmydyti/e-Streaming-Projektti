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
    public class SeasonsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SeasonsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Seasons
        public async Task<IActionResult> Index()
        {
            return View(await _context.Season.ToListAsync());
        }

        // GET: Admin/Seasons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var season = await _context.Season
                .FirstOrDefaultAsync(m => m.Season_ID == id);
            if (season == null)
            {
                return NotFound();
            }

            return View(season);
        }

        // GET: Admin/Seasons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Seasons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Season_ID,Season_Name")] Season season)
        {
            if (ModelState.IsValid)
            {
                _context.Add(season);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(season);
        }

        // GET: Admin/Seasons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var season = await _context.Season.FindAsync(id);
            if (season == null)
            {
                return NotFound();
            }
            return View(season);
        }

        // POST: Admin/Seasons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Season_ID,Season_Name")] Season season)
        {
            if (id != season.Season_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(season);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeasonExists(season.Season_ID))
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
            return View(season);
        }

        // GET: Admin/Seasons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var season = await _context.Season
                .FirstOrDefaultAsync(m => m.Season_ID == id);
            if (season == null)
            {
                return NotFound();
            }

            return View(season);
        }

        // POST: Admin/Seasons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var season = await _context.Season.FindAsync(id);
            _context.Season.Remove(season);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeasonExists(int id)
        {
            return _context.Season.Any(e => e.Season_ID == id);
        }
    }
}
