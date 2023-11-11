using CONCURSO_INTERNO_PERSONAL.Models;

namespace CONCURSO_INTERNO_PERSONAL.Data
{
    public class DA_Usuario
    {
        public List<Usuario> ListaUsuario()
        {
            return new List<Usuario>()
            {
                new Usuario{Nombre = "Juan Perez", Correo = "jefeFinanzas@gmail.com", Clave = "123", Roles = new string[] { "jefeFinanzas" } },
                new Usuario{Nombre = "Johana Calderon", Correo = "profesionalPerfil@gmail.com", Clave = "123", Roles = new string[] { "profesionalPerfil" } },
                new Usuario{Nombre = "Junior Montesinos", Correo = "jefeRecursosHumanos@gmail.com", Clave = "123", Roles = new string[] { "jefeRecursosHumanos"} },
                new Usuario{Nombre = "Carlos Conde", Correo = "encargadoSeleccionPersonal@gmail.com", Clave = "123", Roles = new string[] { "encargadoSeleccionPersonal"} },
                new Usuario{Nombre = "Eddie Paz", Correo = "comiteSeleccion@gmail.com", Clave = "123", Roles = new string[] { "comiteSeleccion","admin"} },
                new Usuario{Nombre = "Erick Requena", Correo = "saoga@gmail.com", Clave = "123", Roles = new string[] { "saoga" } },
                new Usuario{Nombre = "Lesly Llapo", Correo = "analistaPresupuestal@gmail.com", Clave = "123", Roles = new string[] { "analistaPresupuestal" } }
            };
        }
        public Usuario ValidarUsuario(string _correo, string _clave)
        {
            return ListaUsuario().Where(item => item.Correo == _correo && item.Clave == _clave).FirstOrDefault();
        }
    }
}
