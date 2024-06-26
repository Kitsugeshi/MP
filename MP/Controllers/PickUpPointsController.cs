﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MP.Models;

namespace MP.Controllers
{
    public class PickUpPointsController : Controller
    {
        private readonly MarketDbContext _context;

        public PickUpPointsController(MarketDbContext context)
        {
            _context = context;
        }

        // GET: PickUpPoints
        public async Task<IActionResult> Index()
        {
              return _context.PickUpPoints != null ? 
                          View(await _context.PickUpPoints.ToListAsync()) :
                          Problem("Entity set 'MarketDbContext.PickUpPoints'  is null.");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Products");
        }

        private bool PickUpPointExists(int id)
        {
          return (_context.PickUpPoints?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
