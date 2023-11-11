using Microsoft.AspNetCore.Mvc.Rendering;

namespace CONCURSO_INTERNO_PERSONAL.Models.VMPerfil_Puesto
{
    public class Perfil_Puesto_VM
    {


        public PerfilPuesto oPerfilPuesto { get; set; }

       

        public List<SelectListItem> oConocimientoslaborales { get; set; }

        public List<SelectListItem> oHabilidades { get; set; }

        public List<SelectListItem> oPuesto { get; set; }

        public List<SelectListItem> oSede { get; set; }


    }
}
