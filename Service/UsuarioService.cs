using activos.Models;
using Microsoft.EntityFrameworkCore;

namespace activos.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly MyDbContext _context; 
        public UsuarioService(MyDbContext context)
        {
            _context = context;
        }
        public async Task<Usuario> GetUsuario(string correo, string clave)
        {
            Usuario usuario = await _context.Usuarios.Where(u => u.Correo == correo && u.Clave == clave).FirstOrDefaultAsync();
            return usuario;
        }

        public async Task<Usuario> SaveUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }
    }
}
