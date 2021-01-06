using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FlowerShop.Data;
using FlowerShop.Models;
using Microsoft.AspNetCore.Authorization;

namespace FlowerShop.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class FlowersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FlowersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Flower.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flower = await _context.Flower
                .FirstOrDefaultAsync(m => m.Id == id);
            if (flower == null)
            {
                return NotFound();
            }

            return View(flower);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,InStock,Url")] Flower flower)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flower);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(flower);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flower = await _context.Flower.FindAsync(id);
            if (flower == null)
            {
                return NotFound();
            }
            return View(flower);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,InStock,Url")] Flower flower)
        {
            if (id != flower.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flower);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlowerExists(flower.Id))
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
            return View(flower);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flower = await _context.Flower
                .FirstOrDefaultAsync(m => m.Id == id);
            if (flower == null)
            {
                return NotFound();
            }

            return View(flower);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var flower = await _context.Flower.FindAsync(id);
            _context.Flower.Remove(flower);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlowerExists(int id)
        {
            return _context.Flower.Any(e => e.Id == id);
        }
    }
}