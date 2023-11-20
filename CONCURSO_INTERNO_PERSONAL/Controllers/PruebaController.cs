using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CONCURSO_INTERNO_PERSONAL.Models;


using Microsoft.AspNetCore.Http.Extensions;
using DinkToPdf;

using CONCURSO_INTERNO_PERSONAL.Models.VMPrueba;

namespace Prueba_CRUD.Controllers
{
    public class PruebaController : Controller
    {
        private readonly SmvConcursoInternoContext _DBContext;
        private readonly IConverter _converter;
        public PruebaController(SmvConcursoInternoContext context, IConverter converter)
        {
            _DBContext = context;

            _converter = converter;
        }
        public IActionResult VistaParaPDF()
        {
            List<Prueba> lista = _DBContext.Pruebas.Include(e => e.oPregunta).ToList();
            return View(lista);
        }
        public IActionResult MostrarPDFenPagina()
        {
            string pagina_actual = HttpContext.Request.Path;
            string url_pagina = HttpContext.Request.GetEncodedUrl();
            url_pagina = url_pagina.Replace(pagina_actual, "");
            url_pagina = $"{url_pagina}/Prueba/VistaParaPDF";


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


            return File(archivoPDF, "application/pdf");
        }
        [Authorize(Roles = "encargadoSeleccionPersonal, admin")]
        public IActionResult Prueba_index()
        {
            List<Prueba> lista = _DBContext.Pruebas.Include(e => e.oPregunta).ToList();
            return View(lista);

        }
        [HttpGet]
        public IActionResult Pregunta_detalle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Pregunta_detalle(PruebaVM oPruebaVM)
        {
            try
            {
                var pregunta = new Preguntum
                {
                    IdPregunta = oPruebaVM.Prueba.oPregunta.IdPregunta,
                    Enunciado = oPruebaVM.Prueba.oPregunta.Enunciado,
                    OpcionA = oPruebaVM.Prueba.oPregunta.OpcionA,
                    OpcionB = oPruebaVM.Prueba.oPregunta.OpcionB,
                    OpcionC = oPruebaVM.Prueba.oPregunta.OpcionC,
                    OpcionD = oPruebaVM.Prueba.oPregunta.OpcionD,
                    RespuestaCorrecta = oPruebaVM.Prueba.oPregunta.RespuestaCorrecta

                };

                var pru = new Prueba
                {
                    oPregunta = pregunta,
                    IdResultado = pregunta.IdPregunta,
                    IdPregunta = pregunta.IdPregunta,

                    RespuestaCorrecta = pregunta.RespuestaCorrecta,
                    Puntaje = oPruebaVM.Prueba.Puntaje
                };
                 _DBContext.Pregunta.Add(pregunta);
                _DBContext.Pruebas.Add(pru);

                _DBContext.SaveChanges();
                return RedirectToAction("Prueba_index", "Prueba");
            }
            catch
            {
                TempData["ErrorMessage"] = "Ingresar correctamente la pregunta.";
                return RedirectToAction("Pregunta_detalle", "Prueba");
            }
        }
        public IActionResult EliminarTodasLasPreguntas()
        {
            _DBContext.Pruebas.RemoveRange(_DBContext.Pruebas.ToList());    
            _DBContext.SaveChanges();

            return RedirectToAction("Prueba_index", "Prueba");
        }
    }

}

