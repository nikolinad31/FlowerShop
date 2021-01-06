using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FlowerShop.Models;
using FlowerShop.Data;
using Microsoft.EntityFrameworkCore;

namespace FlowerShop.Controllers
{
    public class BrowseController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BrowseController(ApplicationDbContext context)
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

            var flower = await _context.Flower.FirstOrDefaultAsync(m => m.Id == id);
            
            if (flower == null)
            {
                return NotFound();
            }

            return View(flower);
        }
    }
}
