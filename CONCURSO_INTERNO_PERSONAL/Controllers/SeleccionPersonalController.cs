using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CONCURSO_INTERNO_PERSONAL.Controllers
{
    public class SeleccionPersonalController : Controller
    {
        [Authorize (Roles = "comiteSeleccion, saoga")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
