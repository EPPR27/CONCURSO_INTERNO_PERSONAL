using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CONCURSO_INTERNO_PERSONAL.Models;
using DinkToPdf.Contracts;

using CONCURSO_INTERNO_PERSONAL.Models.VMPerfil_Puesto;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CONCURSO_INTERNO_PERSONAL.Models.VMPresupuesto;

namespace CONCURSO_INTERNO_PERSONAL.Controllers
{
    public class PerfilPuestoController : Controller
    {
        private readonly SmvConcursoInternoContext _DBContext;
        public PerfilPuestoController(SmvConcursoInternoContext context, IConverter converter)
        {
            _DBContext = context;


        }
        [Authorize(Roles = "admin,comiteSeleccion,saoga,profesionalPerfil")]
        [HttpGet]
       
        public IActionResult Perfil_Puest_detalle(int IdPerfil)
        {
            Perfil_Puesto_VM perfilpuestoVM = new Perfil_Puesto_VM()
            {
                oPerfilPuesto = new PerfilPuesto(),
                listaCL = _DBContext.ConocimientosLaborales.Select(option => new SelectListItem()
                {
                    Text = option.NomCl,
                    Value = option.IdCl.ToString()
                }).ToList(),
                listaS = _DBContext.Sedes.Select(option => new SelectListItem()
                {
                    Text = option.NomSede,
                    Value = option.IdSede.ToString()
                }).ToList(),
                listaHB = _DBContext.HabilidadesBlandas.Select(option => new SelectListItem()
                {
                    Text = option.NomHb,
                    Value = option.IdHb.ToString()
                }).ToList(),
                listaP = _DBContext.Puestos.Select(option => new SelectListItem()
                {
                    Text = option.NomPuesto,
                    Value = option.IdPuesto.ToString()
                }).ToList()
            };
            if(IdPerfil != 0)
            {
                perfilpuestoVM.oPerfilPuesto = _DBContext.PerfilPuestos.Find(IdPerfil);
            }

            return View(perfilpuestoVM);
        }
        [Authorize(Roles = "profesionalPerfil, admin")]
        [HttpPost]
        public IActionResult Perfil_Puest_detalle(Perfil_Puesto_VM oPerfil_Puesto_VM)
        {
            try
            {
                if (oPerfil_Puesto_VM.oPerfilPuesto.IdPp == 0)
                {
                    _DBContext.PerfilPuestos.Add(oPerfil_Puesto_VM.oPerfilPuesto);
                    _DBContext.SaveChanges();
                    TempData["SuccessMessage"] = "Se creó satisfactoriamente el Perfil de Puesto";
                }
                else
                {
                    _DBContext.PerfilPuestos.Update(oPerfil_Puesto_VM.oPerfilPuesto);
                    _DBContext.SaveChanges();
                    TempData["SuccessMessage"] = "Se actualizó satisfactoriamente el Perfil de Puesto";
                }
                
                return RedirectToAction("Perfil_Puest_detalle", "PerfilPuesto");
            }
            catch
            {
                TempData["ErrorMessage"] = "Seleccionar Datos necesarios para perfil de Puesto";
                return RedirectToAction("Perfil_Puest_detalle", "PerfilPuesto");
            }
            
        }
        [Authorize(Roles = "profesionalPerfil, admin")]
        [HttpGet]
        public IActionResult TablaPerfiles()
        {
            List<PerfilPuesto> lista = _DBContext.PerfilPuestos
                .Include(p => p.oPuesto)
                .Include(h => h.oHabilidadesBlandas)
                .Include(c => c.oConocimientosLaborales)
                .Include(s => s.oSede)
                .ToList();
            return View(lista);
        }
        [Authorize(Roles = "profesionalPerfil, admin")]
        public IActionResult Eliminar(int IdPp)
        {
            try
            {
                PerfilPuesto oPerfilPuesto = _DBContext.PerfilPuestos.Find(IdPp);

                if (oPerfilPuesto == null)
                {
                    return NotFound();
                }

                _DBContext.PerfilPuestos.Remove(oPerfilPuesto);
                _DBContext.SaveChanges();

                return Json(new { success = true, message = "Eliminación exitosa" });
            }
            catch
            {
                return Json(new { success = false, message = "Error al intentar eliminar El Perfil de Puesto." });
            }
        }
    }
}
