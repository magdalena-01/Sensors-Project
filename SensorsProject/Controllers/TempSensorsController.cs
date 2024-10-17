
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
    public class TempSensorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TempSensorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TempSensors
        public async Task<IActionResult> Index()
        {
            return View(await _context.TempSensors.ToListAsync());
        }

        // GET: TempSensors/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tempSensor = await _context.TempSensors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tempSensor == null)
            {
                return NotFound();
            }

            return View(tempSensor);
        }

        // GET: TempSensors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TempSensors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Position,Id,SensorName,SensorType")] TempSensor tempSensor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tempSensor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tempSensor);
        }

        // GET: TempSensors/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tempSensor = await _context.TempSensors.FindAsync(id);
            if (tempSensor == null)
            {
                return NotFound();
            }
            return View(tempSensor);
        }

        // POST: TempSensors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Position,Id,SensorName,SensorType")] TempSensor tempSensor)
        {
            if (id != tempSensor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tempSensor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TempSensorExists(tempSensor.Id))
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
            return View(tempSensor);
        }

        // GET: TempSensors/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tempSensor = await _context.TempSensors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tempSensor == null)
            {
                return NotFound();
            }

            return View(tempSensor);
        }

        // POST: TempSensors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tempSensor = await _context.TempSensors.FindAsync(id);
            if (tempSensor != null)
            {
                _context.TempSensors.Remove(tempSensor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TempSensorExists(string id)
        {
            return _context.TempSensors.Any(e => e.Id == id);
        }
    }
}
