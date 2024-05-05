using Microsoft.AspNetCore.Mvc;

namespace MP.Controllers
{
    public class AuthorizationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
