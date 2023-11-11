using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CONCURSO_INTERNO_PERSONAL.Controllers
{
    public class PerfilPuestoController : Controller
    {
        [Authorize (Roles = "profesionalPerfil")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
