using System;
using Microsoft.AspNetCore.Mvc;
using PGP.Turnos.Negocio;
using PGP.Turnos.Modelos;

namespace PGP.Turnos.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly AutenticacionService _authService;

        public AccountController()
        {
            _authService = new AutenticacionService();
        }

        [HttpGet]
        public IActionResult Login()
        {
            // Valor por defecto del año de trabajo (como en la aplicación WinForms)
            ViewData["AnioTrabajo"] = DateTime.Today.Year;
            return View();
        }

        [HttpPost]
        public IActionResult Login(string login, string clave, string anioTrabajo)
        {
            // Validar año de trabajo como en la versión de escritorio
            if (!int.TryParse(anioTrabajo, out int anio))
            {
                ViewBag.Error = "El año de trabajo no es válido.";
                ViewData["AnioTrabajo"] = DateTime.Today.Year;
                return View();
            }

            if (anio < 2017 || anio > 2200)
            {
                ViewBag.Error = "El año de trabajo debe estar entre 2017 y 2200.";
                ViewData["AnioTrabajo"] = anio;
                return View();
            }

            // Guardar año en EstadoGlobal como en la versión de escritorio
            EstadoGlobal.AnioTrabajo = anio;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(clave))
            {
                ViewBag.Error = "Usuario o contraseña vacíos.";
                ViewData["AnioTrabajo"] = anio;
                return View();
            }

            var ok = _authService.ValidarUsuario(login, clave);
            if (!ok)
            {
                ViewBag.Error = "Usuario o contraseña incorrectos.";
                ViewData["AnioTrabajo"] = anio;
                return View();
            }

            // Pasar datos a la siguiente vista para mostrar la info del usuario (imitando la app WinForms)
            TempData["Area"] = EstadoGlobal.AreaActual;
            TempData["Login"] = EstadoGlobal.LoginUsuario;
            TempData["Unidad"] = EstadoGlobal.UnidadActual;
            TempData["Privilegios"] = EstadoGlobal.PrivilegiosUsuario;
            TempData["AnioTrabajo"] = EstadoGlobal.AnioTrabajo.ToString();
            TempData["FechaSeguridad"] = EstadoGlobal.FechaSeguridad.ToString("yyyy-MM-dd");

            return RedirectToAction("Index", "Home");
        }
    }
}