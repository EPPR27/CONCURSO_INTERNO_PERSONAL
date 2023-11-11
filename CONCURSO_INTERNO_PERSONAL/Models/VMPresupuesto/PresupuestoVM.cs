using Microsoft.AspNetCore.Mvc.Rendering;

namespace CONCURSO_INTERNO_PERSONAL.Models.VMPresupuesto
{
    public class PresupuestoVM
    {
        public SolicitudSueldo oSolicitudSueldo { get; set; }
        public List<SelectListItem> oDNI { get; set; }
    }
}
