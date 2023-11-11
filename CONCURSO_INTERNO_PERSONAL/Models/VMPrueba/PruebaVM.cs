using Microsoft.AspNetCore.Mvc.Rendering;


namespace CONCURSO_INTERNO_PERSONAL.Models.VMPrueba
{
    public class PruebaVM
    {
        public Prueba Prueba { get; set; }
        public List<SelectListItem> oPregunta { get; set; }
    }
}
