using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using CONCURSO_INTERNO_PERSONAL.Models;
using CONCURSO_INTERNO_PERSONAL.Models.VMPresupuesto;
using System.ComponentModel.DataAnnotations;

namespace CONCURSO_INTERNO_PERSONAL.Controllers
{
    public class PresupuestoController : Controller
    {
        private readonly SmvConcursoInternoContext _context;
        public PresupuestoController(SmvConcursoInternoContext context)
        {
            _context = context;
        }
        [Authorize (Roles = "jefeFinanzas")]
        public IActionResult Solicitud_Presupuesto()
        {

            return View();
        }
        [Authorize (Roles = "jefeRecursosHumanos, analistaPresupuestal")]
        [HttpGet]
        public IActionResult Solicitud_detalle()
        {

            return View();
        }
    }
}
