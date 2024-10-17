using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SensorsProject.Data;
using SensorsProject.Models;

namespace SensorsProject.Controllers
{
    public class SensorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SensorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sensors
        public async Task<IActionResult> Index()
        {
            var tempSensors = await _context.Sensors.OfType<TempSensor>()
                .Include(ts => ts.TempData)
                .ToListAsync();
            var phSensors = await _context.Sensors.OfType<PhSensor>()
                .Include(ps => ps.PhData)
                .ToListAsync();
            var ECSensors = await _context.Sensors.OfType<ECSensor>()
               .Include(ps => ps.ECData)
               .ToListAsync();

            // Combine the lists into a single list of Sensor
            var combinedSensors = tempSensors.Cast<Sensor>()
                .Concat(phSensors.Cast<Sensor>())
                .Concat(ECSensors.Cast<Sensor>())
                .ToList();

            // Pass the combined list to the view
            return View(combinedSensors);

        }
        public IActionResult ViewSensorsByType(string type)
        {
            var sensors = _context.Sensors.Where(s => s.SensorType == type).ToList();
            return View("SensorsByType", sensors);
        }

        // GET: Sensors/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sensor = await _context.Sensors
                .Include(s => (s as TempSensor).TempData)
                .Include(s => (s as PhSensor).PhData)
                .Include(s=> (s as ECSensor).ECData)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sensor == null)
            {
                return NotFound();
            }

            return View(sensor);
        }

        // GET: Sensors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sensors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SensorName,SensorType")] Sensor sensor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sensor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sensor);
        }

        // GET: Sensors/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sensor = await _context.Sensors.FindAsync(id);
            if (sensor == null)
            {
                return NotFound();
            }
            return View(sensor);
        }

        // POST: Sensors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,SensorName,SensorType")] Sensor sensor)
        {
            if (id != sensor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sensor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SensorExists(sensor.Id))
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
            return View(sensor);
        }

        // GET: Sensors/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sensor = await _context.Sensors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sensor == null)
            {
                return NotFound();
            }

            return View(sensor);
        }

        // POST: Sensors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var sensor = await _context.Sensors.FindAsync(id);
            if (sensor != null)
            {
                _context.Sensors.Remove(sensor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SensorExists(string id)
        {
            return _context.Sensors.Any(e => e.Id == id);
        }
    }
}
