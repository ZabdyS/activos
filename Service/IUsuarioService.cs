using activos.Models;

namespace activos.Service
{
    public interface IUsuarioService
    {
        Task<Usuario> GetUsuario(string email, string clave);
        Task<Usuario> SaveUsuario(Usuario usuario);
    }
}
