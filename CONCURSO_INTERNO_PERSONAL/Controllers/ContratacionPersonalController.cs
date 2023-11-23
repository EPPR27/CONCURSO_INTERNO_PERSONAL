using CONCURSO_INTERNO_PERSONAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace CONCURSO_INTERNO_PERSONAL.Controllers
{
    public class ContratacionPersonalController : Controller
    {
        private readonly SmvConcursoInternoContext _SmvContext;
        private readonly IConverter _converter;

        public ContratacionPersonalController(SmvConcursoInternoContext context, IConverter converter)
        {
            _SmvContext = context;
            _converter = converter;
        }

        [Authorize(Roles = "jefeRecursosHumanos, admin")]
        [HttpGet]
        public IActionResult TablaContratPersonal()
        {
            List<Personal> lista = _SmvContext.Personals.Include(pt => pt.oPuesto).ToList();
            return View(lista);
        }
        [HttpGet]
        public IActionResult VistaPDF()
        {
            List<Personal> lista = _SmvContext.Personals.Include(p => p.oPuesto).ToList();
            return View(lista);
        }
        [Authorize(Roles = "jefeRecursosHumanos, admin")]
        [HttpGet]
        public IActionResult MostrarPDFenPagina()
        {
            string pagina_actual = HttpContext.Request.Path;
            string url_pagina = HttpContext.Request.GetEncodedUrl();
            url_pagina = url_pagina.Replace(pagina_actual, "");
            url_pagina = $"{url_pagina}/ContratacionPersonal/VistaPDF";

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = new GlobalSettings()
                {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait
                },
                Objects = {
                    new  ObjectSettings(){
                        Page = url_pagina
                    }
                }
            };
            var archivoPDF = _converter.Convert(pdf);

            return File(archivoPDF, "application/pdf");
        }
        [Authorize(Roles = "jefeRecursosHumanos, admin")]
        
        public IActionResult Eliminar(int Idpersonal)
        {
            try
            {
                Personal oPersonal = _SmvContext.Personals.Find(Idpersonal);

                if (oPersonal == null)
                {
                    return NotFound();
                }

                _SmvContext.Personals.Remove(oPersonal);
                _SmvContext.SaveChanges();

                return Json(new { success = true, message = "Eliminación exitosa" });
            }
            catch
            {
                return Json(new { success = false, message = "Error al intentar eliminar al postulante." });
            }
        }

    }
}
