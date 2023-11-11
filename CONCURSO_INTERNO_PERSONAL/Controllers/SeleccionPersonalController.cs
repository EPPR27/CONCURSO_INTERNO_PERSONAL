﻿using Microsoft.AspNetCore.Mvc;
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


        [Authorize(Roles = "comiteSeleccion, saoga")]
        public IActionResult Index()
        {
            List<Personal> lista = _SmvContext.Personals
                .Include(pm => pm.oPruebasMedicas)
                .Include(pt => pt.oPuesto)
                .Include(hb => hb.oHabilidadesBlandas)
                .Include(cl => cl.oConocimientosLaborales)
                .ToList();
            return View(lista);
        }

        [HttpGet]
        public IActionResult CBPruebasMedicas(int idpersonal)
        {
            PersonalVM oPersonalVM = new PersonalVM()
            {
                oPersonal = new Personal(),
                oListaPruebasMedicas = _SmvContext.PruebasMedicas.Select(pruebamedica => new SelectListItem()
                {
                    Text = pruebamedica.Estado,
                    Value = pruebamedica.IdPruebasMedicas.ToString()
                }).ToList(),
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
        public IActionResult CBPruebasMedicas(PersonalVM oPersonalVM)
        {
            if (oPersonalVM.oPersonal.Idpersonal == 0)
            {
                _SmvContext.Personals.Add(oPersonalVM.oPersonal);
            }
            else
            {
                _SmvContext.Personals.Update(oPersonalVM.oPersonal);
            }

            _SmvContext.SaveChanges();

            return RedirectToAction("Index", "SeleccionPersonal");
        }

        [HttpGet]
        public IActionResult Eliminar(int idpersonal)
        {
            Personal oPersonal = _SmvContext.Personals
                .Include(pm => pm.oPruebasMedicas)
                .Include(pt => pt.oPuesto)
                .Include(hb => hb.oHabilidadesBlandas)
                .Include(cl => cl.oConocimientosLaborales)
                .Where(e => e.Idpersonal == idpersonal).FirstOrDefault();

            return View(oPersonal);
        }

        [HttpPost]
        public IActionResult Eliminar(Personal oPersonal)
        {
            _SmvContext.Personals.Remove(oPersonal);
            _SmvContext.SaveChanges();

            return RedirectToAction("Index", "SeleccionPersonal");
        }
    }
}

