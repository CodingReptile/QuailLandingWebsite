using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuailLandingWebsite.Data;
using QuailLandingWebsite.Models;

namespace QuailLandingWebsite.Controllers
{
    public class QuailLandingHomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuailLandingHomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: QuailLandingHomes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Home.ToListAsync());
        }

        // GET: QuailLandingHomes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quailLandingHome = await _context.Home
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quailLandingHome == null)
            {
                return NotFound();
            }

            return View(quailLandingHome);
        }

        // GET: QuailLandingHomes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QuailLandingHomes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HomeNumber,Address")] QuailLandingHome quailLandingHome)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quailLandingHome);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quailLandingHome);
        }

        // GET: QuailLandingHomes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quailLandingHome = await _context.Home.FindAsync(id);
            if (quailLandingHome == null)
            {
                return NotFound();
            }
            return View(quailLandingHome);
        }

        // POST: QuailLandingHomes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HomeNumber,Address")] QuailLandingHome quailLandingHome)
        {
            if (id != quailLandingHome.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quailLandingHome);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuailLandingHomeExists(quailLandingHome.Id))
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
            return View(quailLandingHome);
        }

        // GET: QuailLandingHomes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quailLandingHome = await _context.Home
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quailLandingHome == null)
            {
                return NotFound();
            }

            return View(quailLandingHome);
        }

        // POST: QuailLandingHomes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var quailLandingHome = await _context.Home.FindAsync(id);
            _context.Home.Remove(quailLandingHome);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuailLandingHomeExists(int id)
        {
            return _context.Home.Any(e => e.Id == id);
        }
    }
}
