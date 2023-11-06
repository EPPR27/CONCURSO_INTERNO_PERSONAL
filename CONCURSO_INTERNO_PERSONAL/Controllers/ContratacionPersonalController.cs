using CONCURSO_INTERNO_PERSONAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Http.Extensions;

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

        public IActionResult VistaPDF()
        {
            List<Personal> lista = _SmvContext.Personals.Include(pt => pt.oPuesto).ToList();
            return View(lista);
        }

        public IActionResult MostrarPDFenPagina() 
        {
        string pagina_actual = HttpContext.Request.Path;
        string url_pagina = HttpContext.Request.GetEncodedUrl();
            url_pagina = url_pagina.Replace(pagina_actual, "");
            url_pagina = $"{url_pagina}/ContratacionPersonal/VistaPDF";

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = new GlobalSettings(){
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

        public IActionResult DescargarPDF()
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
                    new ObjectSettings(){
                        Page = url_pagina
                    }
                }

            };

            var archivoPDF = _converter.Convert(pdf);
            string nombrePDF = "reporte_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf";

            return File(archivoPDF, "application/pdf", nombrePDF);
        }

        public IActionResult TablaContratPersonal()
        {
            List<Personal> lista = _SmvContext.Personals.Include(pt => pt.oPuesto).ToList();
            return View(lista);
        }

        public async Task<IActionResult> MostrarDetalle(string? Dni)
        {
            if (Dni == null || _SmvContext.Personals.Include(pt => pt.oPuesto) == null)
            {
                return NotFound();
            }

            var personal = await _SmvContext.Personals.Include(pt =>pt.oPuesto)
                .FirstOrDefaultAsync(m => m.Dni == Dni);
            if (personal == null)
            {
                return NotFound();
            }
            return View(personal);
        }
    }
}
