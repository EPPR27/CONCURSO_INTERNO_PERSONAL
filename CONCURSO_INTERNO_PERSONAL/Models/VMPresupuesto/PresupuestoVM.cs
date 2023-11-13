using Microsoft.AspNetCore.Mvc.Rendering;

namespace CONCURSO_INTERNO_PERSONAL.Models.VMPresupuesto
{
    public class PresupuestoVM
    {
        public SolicitudSueldo oSolicitudSueldo { get; set; }
        public List<SelectListItem> oListaPersonal { get; set; }
        public Personal detallesPersonalSeleccionado { get; set; }
    }
}