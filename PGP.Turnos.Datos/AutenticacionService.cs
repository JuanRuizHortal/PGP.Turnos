using System;
using PGP.Turnos.Modelos;
using PGP.Turnos.Datos;

namespace PGP.Turnos.Negocio
{
    /// <summary>
    /// Lógica de negocio para autenticación de usuarios.
    /// </summary>
    public class AutenticacionService
    {
        private readonly UsuarioRepository _usuarioRepo;

        public AutenticacionService()
        {
            _usuarioRepo = new UsuarioRepository();
        }

        /// <summary>
        /// Valida usuario y clave. Si son correctos, rellena EstadoGlobal y devuelve true.
        /// </summary>
        public bool ValidarUsuario(string login, string clave)
        {
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(clave))
                return false;

            var usuario = _usuarioRepo.ObtenerPorLoginYClave(login, clave);
            if (usuario == null)
                return false;

            // Rellenar las variables globales
            EstadoGlobal.LoginUsuario = usuario.Login;
            EstadoGlobal.AreaActual = usuario.Area;
            EstadoGlobal.UnidadActual = usuario.Unidad;
            EstadoGlobal.PrivilegiosUsuario = usuario.Privilegios;
            EstadoGlobal.DNIUsuario = usuario.Dni.ToString();
            // TODO: calcular letra NIF si hace falta y asignar a EstadoGlobal.NIFUsuario

            return true;
        }
    }
}
