using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyAspCoreProject.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Globalization;


namespace MyAspCoreProject.Controllers
{
    public class SerialsController : Controller
    {
        public readonly SerialContext _context;

        public SerialsController(SerialContext context)
        {
            _context = context;
        }


        // GET: Serials
        public async Task<IActionResult> Index()
        {
            return View(await _context.Serials.ToListAsync());
        }

        // GET: Serials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serial = await _context.Serials
                .SingleOrDefaultAsync(m => m.SerialId == id);
            if (serial == null)
            {
                return NotFound();
            }

            return View(serial);
        }

        // GET: Serials/Create
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult DoSomethingCool()
        {
            return Content("Wow! That is really cool.");
        }

        // POST: Serials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Browse (List<IFormFile> files)
        {
            DoSomething ds = new DoSomething();
            var uploadedFileStream = files.First().OpenReadStream();
            return ds.ParseMyStuff(uploadedFileStream);
        }


        // GET: Serials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serial = await _context.Serials.SingleOrDefaultAsync(m => m.SerialId == id);
            if (serial == null)
            {
                return NotFound();
            }
            return View(serial);
        }

        // POST: Serials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SerialId,SerialName")] Serial serial)
        {
            if (id != serial.SerialId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SerialExists(serial.SerialId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(serial);
        }

        // GET: Serials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serial = await _context.Serials
                .SingleOrDefaultAsync(m => m.SerialId == id);
            if (serial == null)
            {
                return NotFound();
            }

            return View(serial);
        }

        // POST: Serials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var serial = await _context.Serials.SingleOrDefaultAsync(m => m.SerialId == id);
            _context.Serials.Remove(serial);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SerialExists(int id)
        {
            return _context.Serials.Any(e => e.SerialId == id);
        }
    }
}
