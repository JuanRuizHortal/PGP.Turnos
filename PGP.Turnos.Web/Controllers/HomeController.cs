using Microsoft.AspNetCore.Mvc;

namespace PGP.Turnos.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Mostrar área si viene en TempData
            ViewBag.Area = TempData["Area"] ?? "(no disponible)";
            return View();
        }
    }
}