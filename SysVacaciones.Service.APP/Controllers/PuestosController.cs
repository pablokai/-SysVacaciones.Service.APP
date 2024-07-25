using Microsoft.AspNetCore.Mvc;

namespace SysVacaciones.Service.Controllers
{
    public class PuestosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
