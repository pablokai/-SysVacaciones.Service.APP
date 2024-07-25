using Microsoft.AspNetCore.Mvc;

namespace SysVacaciones.Service.Controllers
{
    public class EmpleadosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
