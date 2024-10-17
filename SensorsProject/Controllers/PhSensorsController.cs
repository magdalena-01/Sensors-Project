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
    public class PhSensorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PhSensorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PhSensors
        public async Task<IActionResult> Index()
        {
            return View(await _context.PhSensor.ToListAsync());
        }

        // GET: PhSensors/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phSensor = await _context.PhSensor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phSensor == null)
            {
                return NotFound();
            }

            return View(phSensor);
        }

        // GET: PhSensors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PhSensors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Position,Id,SensorName,SensorType")] PhSensor phSensor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phSensor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phSensor);
        }

        // GET: PhSensors/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phSensor = await _context.PhSensor.FindAsync(id);
            if (phSensor == null)
            {
                return NotFound();
            }
            return View(phSensor);
        }

        // POST: PhSensors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Position,Id,SensorName,SensorType")] PhSensor phSensor)
        {
            if (id != phSensor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phSensor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhSensorExists(phSensor.Id))
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
            return View(phSensor);
        }

        // GET: PhSensors/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phSensor = await _context.PhSensor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phSensor == null)
            {
                return NotFound();
            }

            return View(phSensor);
        }

        // POST: PhSensors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var phSensor = await _context.PhSensor.FindAsync(id);
            if (phSensor != null)
            {
                _context.PhSensor.Remove(phSensor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhSensorExists(string id)
        {
            return _context.PhSensor.Any(e => e.Id == id);
        }
    }
}
