using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using CONCURSO_INTERNO_PERSONAL.Models;
using CONCURSO_INTERNO_PERSONAL.Models.VMPresupuesto;
using System.ComponentModel.DataAnnotations;
using CONCURSO_INTERNO_PERSONAL.Models.VMPersonal;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Http.Extensions;

namespace CONCURSO_INTERNO_PERSONAL.Controllers
{
    public class PresupuestoController : Controller
    {
        private readonly SmvConcursoInternoContext _context;
        private readonly IConverter _converter;
        public PresupuestoController(SmvConcursoInternoContext context, IConverter converter)
        {
            _context = context;
            _converter = converter;
        }
        [Authorize(Roles = "jefeFinanzas, admin")]
        [HttpGet]
        public IActionResult Solicitud_Presupuesto()
        {
            List<SolicitudSueldo> lista = _context.SolicitudSueldos
            .Include(pt => pt.oPersonal)
            .ToList();

            return View(lista);
        }
        [HttpPost]
        public IActionResult Eliminar(int IdSolicSueldo)
        {
            try
            {
                SolicitudSueldo oSolicitud = _context.SolicitudSueldos.Find(IdSolicSueldo);

                if (oSolicitud == null)
                {
                    return NotFound();
                }

                _context.SolicitudSueldos.Remove(oSolicitud);
                _context.SaveChanges();

                return Json(new { success = true, message = "Eliminación exitosa" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error al intentar eliminar la Solicitud de Sueldo." });
            }
        }
        [Authorize(Roles = "jefeRecursosHumanos, analistaPresupuestal, admin")]
        [HttpGet]
        public IActionResult SolicitarSueldo(int IdPersonal)
        {
            PresupuestoVM presupuestoVM = new PresupuestoVM()
            {
                oSolicitudSueldo = new SolicitudSueldo(),
                oListaPersonal = _context.Personals.ToList().Select(dni => new SelectListItem()
                {
                    Text = dni.Dni.ToString(),
                    Value = dni.Idpersonal.ToString()
                }).ToList()
            };
            if (IdPersonal != 0)
            {
                presupuestoVM.oSolicitudSueldo = _context.SolicitudSueldos.Find(IdPersonal);
            }
            return View(presupuestoVM);
        }
        [HttpPost]
        public IActionResult SolicitarSueldo(PresupuestoVM oPresupuestoVM)
        {
            if (oPresupuestoVM.oSolicitudSueldo.SueldoSolic == 0 || oPresupuestoVM.oSolicitudSueldo.Descripcion == null)
            {
                ViewBag.Script = "Swal.fire('Aviso', 'Debe Ingresar El sueldo Solicitado', 'error');";
                return RedirectToAction("SolicitarSueldo", "Presupuesto");
            }
            if (oPresupuestoVM.oSolicitudSueldo.IdSolicSueldo == 0)
            {
                _context.SolicitudSueldos.Add(oPresupuestoVM.oSolicitudSueldo);
            }
            else
            {
                _context.SolicitudSueldos.Update(oPresupuestoVM.oSolicitudSueldo);
            }
            _context.SaveChanges();

            return RedirectToAction("SolicitarSueldo", "Presupuesto");
        }
        [Authorize(Roles = "jefeFinanzas, admin")]
        [HttpGet]
        public IActionResult VistaPDF(int IdSolicitud)
        {
            SolicitudSueldo List = _context.SolicitudSueldos.Find(IdSolicitud);
            return View(List);
        }
        [Authorize(Roles = "jefeFinanzas, admin")]
        [HttpGet]
        public IActionResult VistaPDFenPagina()
        {
            string pagina_Actual = HttpContext.Request.Path;
            string url_Pagina = HttpContext.Request.GetEncodedUrl();
            url_Pagina = url_Pagina.Replace(pagina_Actual, "");
            url_Pagina = $"{url_Pagina}/Presupuesto/VistaPDF";
            var pdf = new HtmlToPdfDocument
            {
                GlobalSettings = new GlobalSettings()
                {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait
                },
                Objects =
                {
                    new ObjectSettings()
                    {
                        Page = url_Pagina
                    }
                }
            };
            var archivoPDF = _converter.Convert(pdf);
            return File(archivoPDF, "application/pdf");
        }
    }
}