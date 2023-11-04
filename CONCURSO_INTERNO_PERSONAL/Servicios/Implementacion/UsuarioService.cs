using Microsoft.EntityFrameworkCore;
using CONCURSO_INTERNO_PERSONAL.Models;
using CONCURSO_INTERNO_PERSONAL.Servicios.Contrato;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CONCURSO_INTERNO_PERSONAL.Servicios.Implementacion
{
    public class UsuarioService : IUsuarioService
    {

        private readonly SmvConcursoInternoContext _dbContext;
        public UsuarioService(SmvConcursoInternoContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Usuario> GetUsuario(string email, string password)
        {
            Usuario usuario_encontrado = await _dbContext.Usuarios.Where(u => u.Email_Us == email && u.Password_Us == password).FirstOrDefaultAsync();

            return usuario_encontrado;
        }

        public async Task<Usuario> SaveUsuario(Usuario modelo)
        {
            _dbContext.Usuarios.Add(modelo);
            await _dbContext.SaveChangesAsync();
            return modelo;
        }
    }
}
