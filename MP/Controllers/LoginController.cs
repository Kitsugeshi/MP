using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MP.Models;
using System.Security.Claims;

namespace MP.Controllers
{
    public class LoginController : Controller
    {
        MarketDbContext _db;
        public LoginController(MarketDbContext context)
        {
            _db = context;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Authorization(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                return BadRequest("Логин и/или пароль не установлены.");
            }

            var worker = await _db.Employees.FirstOrDefaultAsync(w => w.Login == login && w.Password == password);
            if (worker == null)
            {
                return Unauthorized();
            }

            var role = await _db.Roles.FirstOrDefaultAsync(r => r.Id == worker.IdRole);
            if (role == null)
            {
                return NotFound("Роль не найдена у данного пользователя.");
            }

            var pickuppoint = await _db.PickUpPoints.FirstOrDefaultAsync(p => p.Id == worker.IdPickUpPoint);
            if (pickuppoint == null)
            {
                return NotFound("Данный пользователь не закреплён ни за какаим ПВЗ.");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, worker.Name),
                new Claim(ClaimTypes.Role, role.Name)
            };

            var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            await HttpContext.SignInAsync(claimsPrincipal);

            return RedirectToAction("Index", "Products");
        }
    }
}
