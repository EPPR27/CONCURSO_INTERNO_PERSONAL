using Microsoft.AspNetCore.Mvc.Rendering;

namespace CONCURSO_INTERNO_PERSONAL.Models.VMPerfil_Puesto
{
    public class Perfil_Puesto_VM
    {


        public PerfilPuesto oPerfilPuesto { get; set; }

       

        public List<SelectListItem> listaCL { get; set; }

        public List<SelectListItem> listaHB { get; set; }

        public List<SelectListItem> listaP { get; set; }

        public List<SelectListItem> listaS { get; set; }


    }
}
