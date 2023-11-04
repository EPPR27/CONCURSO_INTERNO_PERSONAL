using Microsoft.EntityFrameworkCore;
using CONCURSO_INTERNO_PERSONAL.Models;

namespace CONCURSO_INTERNO_PERSONAL.Servicios.Contrato
{
    public interface IUsuarioService
    {
        Task<Usuario> GetUsuario(string email, string password);
        Task<Usuario> SaveUsuario(Usuario modelo);
    }
}
