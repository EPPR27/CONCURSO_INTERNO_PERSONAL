namespace CONCURSO_INTERNO_PERSONAL.Models
{
    public class Usuario
    {
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public string[] Roles { get; set; }
    }
}
