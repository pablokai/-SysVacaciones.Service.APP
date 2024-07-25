using Microsoft.AspNetCore.Mvc;

namespace SysVacaciones.Service.Controllers
{
    public class DisponiblesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
