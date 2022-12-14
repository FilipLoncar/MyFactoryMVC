using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyFactoryMVC.Data;
using MyFactoryMVC.Models;

namespace MyFactoryMVC.Controllers
{
    [Authorize]
    [Authorize(Roles = "SUPERADMIN, Skladistar")]
    public class MeasureUnitsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MeasureUnitsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MeasureUnits
        public async Task<IActionResult> Index()
        {
            return View(await _context.MeasureUnits.ToListAsync());
        }

        // GET: MeasureUnits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var measureUnit = await _context.MeasureUnits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (measureUnit == null)
            {
                return NotFound();
            }

            return View(measureUnit);
        }

        // GET: MeasureUnits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MeasureUnits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] MeasureUnit measureUnit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(measureUnit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(measureUnit);
        }

        // GET: MeasureUnits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var measureUnit = await _context.MeasureUnits.FindAsync(id);
            if (measureUnit == null)
            {
                return NotFound();
            }
            return View(measureUnit);
        }

        // POST: MeasureUnits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] MeasureUnit measureUnit)
        {
            if (id != measureUnit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(measureUnit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeasureUnitExists(measureUnit.Id))
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
            return View(measureUnit);
        }

        // GET: MeasureUnits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var measureUnit = await _context.MeasureUnits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (measureUnit == null)
            {
                return NotFound();
            }

            return View(measureUnit);
        }

        // POST: MeasureUnits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var measureUnit = await _context.MeasureUnits.FindAsync(id);
            _context.MeasureUnits.Remove(measureUnit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeasureUnitExists(int id)
        {
            return _context.MeasureUnits.Any(e => e.Id == id);
        }
    }
}
