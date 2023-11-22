using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CONCURSO_INTERNO_PERSONAL.Models;
using Microsoft.EntityFrameworkCore;
using CONCURSO_INTERNO_PERSONAL.Models.VMPersonal;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CONCURSO_INTERNO_PERSONAL.Controllers
{
    public class SeleccionPersonalController : Controller
    {
        private readonly SmvConcursoInternoContext _SmvContext;

        public SeleccionPersonalController(SmvConcursoInternoContext context)
        {
            _SmvContext = context;
        }


        [Authorize(Roles = "comiteSeleccion, saoga, admin")]
        public IActionResult Index()
        {
            List<Personal> lista = _SmvContext.Personals
                .Include(pt => pt.oPuesto)
                .Include(cl => cl.oConocimientosLaborales)
                .Include(hb => hb.oHabilidadesBlandas)
                .ToList();
            return View(lista);
        }

        [HttpGet]
        public IActionResult AdministrarPersonal(int idpersonal)
        {
            PersonalVM oPersonalVM = new PersonalVM()
            {
                oPersonal = new Personal(),
                oListaConocimientosLaborales = _SmvContext.ConocimientosLaborales.Select(conocimientoslaborales => new SelectListItem()
                {
                    Text = conocimientoslaborales.NomCl,
                    Value = conocimientoslaborales.IdCl.ToString()
                }).ToList(),
                oListaHabilidadesBlandas = _SmvContext.HabilidadesBlandas.Select(habilidadesblandas => new SelectListItem()
                {
                    Text = habilidadesblandas.NomHb,
                    Value = habilidadesblandas.IdHb.ToString()
                }).ToList(),
                oListaPuesto = _SmvContext.Puestos.Select(puestos => new SelectListItem()
                {
                    Text = puestos.NomPuesto,
                    Value = puestos.IdPuesto.ToString()
                }).ToList(),
            };
            if (idpersonal != 0)
            {
                oPersonalVM.oPersonal = _SmvContext.Personals.Find(idpersonal);
            }

            return View(oPersonalVM);
        }

        [HttpPost]
        public IActionResult AdministrarPersonal(PersonalVM oPersonalVM)
        {
            try
            {
                if (oPersonalVM.oPersonal.Idpersonal == 0)
                {
                    if(oPersonalVM.oPersonal.Dni != 0)
                    {
                        _SmvContext.Personals.Add(oPersonalVM.oPersonal);
                        _SmvContext.SaveChanges();
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Ingresar Datos requeridos para agregar Postulante.";
                        return RedirectToAction("AdministrarPersonal", "SeleccionPersonal");
                    }

                }
                else
                {
                    _SmvContext.Personals.Update(oPersonalVM.oPersonal);
                    _SmvContext.SaveChanges();
                }
            }catch
            {
                TempData["ErrorMessage"] = "Ingresar Datos requeridos para agregar Postulante.";
                return RedirectToAction("AdministrarPersonal", "SeleccionPersonal");
            }
            return RedirectToAction("Index", "SeleccionPersonal");
        }

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

