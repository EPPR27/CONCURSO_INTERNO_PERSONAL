using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CONCURSO_INTERNO_PERSONAL.Models;
using DinkToPdf.Contracts;

using CONCURSO_INTERNO_PERSONAL.Models.VMPerfil_Puesto;



namespace CONCURSO_INTERNO_PERSONAL.Controllers
{
    public class PerfilPuestoController : Controller
    {
        private readonly SmvConcursoInternoContext _DBContext;
        public PerfilPuestoController(SmvConcursoInternoContext context, IConverter converter)
        {
            _DBContext = context;


        }
        [Authorize (Roles = "profesionalPerfil")]
       
        public IActionResult Index()
        {
            return View();
        }





        [HttpPost]


        public async Task<IActionResult> Perfil_Puest_detalle(Perfil_Puesto_VM oPerfil_Puesto_VM)
        {





            var habilidad = new HabilidadesBlanda
            {
                IdHb = oPerfil_Puesto_VM.oPerfilPuesto.oHabilidadesBlandas.IdHb,
                NomHb = oPerfil_Puesto_VM.oPerfilPuesto.oHabilidadesBlandas.NomHb

            };
            var conocimientos = new ConocimientosLaborale
            {
                IdCl = oPerfil_Puesto_VM.oPerfilPuesto.oConocimientosLaborales.IdCl,
                NomCl = oPerfil_Puesto_VM.oPerfilPuesto.oConocimientosLaborales.NomCl


            };
            var sede = new Sede
            {
                IdSede = oPerfil_Puesto_VM.oPerfilPuesto.oSede.IdSede,
                NomSede = oPerfil_Puesto_VM.oPerfilPuesto.oSede.NomSede

            };
            var pues = new Puesto
            {
                IdPuesto = oPerfil_Puesto_VM.oPerfilPuesto.oPuesto.IdPuesto,

                NomPuesto = oPerfil_Puesto_VM.oPerfilPuesto.oPuesto.NomPuesto


            };
            var perfil = new PerfilPuesto
            {

                oHabilidadesBlandas = habilidad,
                oConocimientosLaborales = conocimientos,
                oSede = sede,
                oPuesto = pues,
                IdHb = habilidad.IdHb,
                IdCl = conocimientos.IdCl,





            };

            await _DBContext.HabilidadesBlandas.AddAsync(habilidad);
            await _DBContext.ConocimientosLaborales.AddAsync(conocimientos);
            await _DBContext.Sedes.AddAsync(sede);
            await _DBContext.Puestos.AddAsync(pues);
            await _DBContext.PerfilPuestos.AddAsync(perfil);


            _DBContext.SaveChanges();


            return RedirectToAction("Index", "PerfilPuesto");




        }
    }
}
