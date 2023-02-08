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
    public class ChannelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChannelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Channels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Channels.ToListAsync());
        }

        // GET: Admin/Channels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var channels = await _context.Channels
                .FirstOrDefaultAsync(m => m.Channel_ID == id);
            if (channels == null)
            {
                return NotFound();
            }

            return View(channels);
        }

        // GET: Admin/Channels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Channels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Channel_ID,Channel_Name")] Channels channels)
        {
            if (ModelState.IsValid)
            {
                _context.Add(channels);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(channels);
        }

        // GET: Admin/Channels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var channels = await _context.Channels.FindAsync(id);
            if (channels == null)
            {
                return NotFound();
            }
            return View(channels);
        }

        // POST: Admin/Channels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Channel_ID,Channel_Name")] Channels channels)
        {
            if (id != channels.Channel_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(channels);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChannelsExists(channels.Channel_ID))
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
            return View(channels);
        }

        // GET: Admin/Channels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var channels = await _context.Channels
                .FirstOrDefaultAsync(m => m.Channel_ID == id);
            if (channels == null)
            {
                return NotFound();
            }

            return View(channels);
        }

        // POST: Admin/Channels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var channels = await _context.Channels.FindAsync(id);
            _context.Channels.Remove(channels);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChannelsExists(int id)
        {
            return _context.Channels.Any(e => e.Channel_ID == id);
        }
    }
}
