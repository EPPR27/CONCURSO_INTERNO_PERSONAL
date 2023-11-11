using Microsoft.AspNetCore.Mvc.Rendering;

namespace CONCURSO_INTERNO_PERSONAL.Models.VMPersonal
{
    public class PersonalVM
    {
        public Personal? oPersonal { get; set; }
        public List<SelectListItem> oListaPruebasMedicas { get; set; }
        public List<SelectListItem> oListaHabilidadesBlandas { get; set; }
        public List<SelectListItem> oListaConocimientosLaborales { get; set; }
        public List<SelectListItem> oListaPuesto { get; set; }
    }
}
