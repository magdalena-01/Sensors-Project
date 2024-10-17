using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SensorsProject.Models;

namespace SensorsProject.Controllers
{
    public class ECSensorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ECSensorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ECSensors
        public async Task<IActionResult> Index()
        {
            return View(await _context.ECSensors.ToListAsync());
        }

        // GET: ECSensors/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eCSensor = await _context.ECSensors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eCSensor == null)
            {
                return NotFound();
            }

            return View(eCSensor);
        }

        // GET: ECSensors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ECSensors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Position,Id,SensorName,SensorType")] ECSensor eCSensor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eCSensor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eCSensor);
        }

        // GET: ECSensors/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eCSensor = await _context.ECSensors.FindAsync(id);
            if (eCSensor == null)
            {
                return NotFound();
            }
            return View(eCSensor);
        }

        // POST: ECSensors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Position,Id,SensorName,SensorType")] ECSensor eCSensor)
        {
            if (id != eCSensor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eCSensor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ECSensorExists(eCSensor.Id))
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
            return View(eCSensor);
        }

        // GET: ECSensors/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eCSensor = await _context.ECSensors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eCSensor == null)
            {
                return NotFound();
            }

            return View(eCSensor);
        }

        // POST: ECSensors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var eCSensor = await _context.ECSensors.FindAsync(id);
            if (eCSensor != null)
            {
                _context.ECSensors.Remove(eCSensor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ECSensorExists(string id)
        {
            return _context.ECSensors.Any(e => e.Id == id);
        }
    }
}
