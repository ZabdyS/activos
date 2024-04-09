using activos.Service;
using Microsoft.AspNetCore.Mvc;
using activos.Models;
using activos.Service;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace activos.Controllers
{
    public class InicioController : Controller
    {
       
        private readonly IUsuarioService _usuarioService;
        
        public InicioController(IUsuarioService usuarioService)
        {
_usuarioService = usuarioService;
        }

        public IActionResult Registrarse()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registrarse(Usuario modelo)
        {
            modelo.Clave = Service.Utilidades.EncriptarClave(modelo.Clave);
            Usuario usuario_creado = await _usuarioService.SaveUsuario(modelo);
            if(usuario_creado.id>0)
                return RedirectToAction("IniciarSesion","Inicio");
            ViewData["Mensaje"] = "No se pudo crear el usuario";

            return View();
        }
        public IActionResult IniciarSesion()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> IniciarSesion( string correo, string clave)
        {
            Usuario usuario_encontrado = await _usuarioService.GetUsuario(correo , Service.Utilidades.EncriptarClave(clave));

            if(usuario_encontrado== null)
            {
                ViewData["Mensaje"] = "No se Encontro el usuario";
                return View();
            }
            

            return RedirectToAction("Index", "Home");
        }


    }
}
