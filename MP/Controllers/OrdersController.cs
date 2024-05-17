using System;
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
    public class OrdersController : Controller
    {
        private readonly MarketDbContext _context;

        public OrdersController(MarketDbContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var marketDbContext = _context.Orders.Include(o => o.IdClientNavigation).Include(o => o.IdPickUpPointNavigation);
            return View(await marketDbContext.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Products");
        }
    }
}
