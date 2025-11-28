using System;
using PGP.Turnos.Modelos;
using PGP.Turnos.Datos;

namespace PGP.Turnos.Negocio
{
    /// <summary>
    /// Lógica de negocio para autenticación de usuarios.
    /// Replica la lógica básica del formulario Clave de VB6.
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
        /// El año de trabajo ya lo habrá validado y asignado el formulario.
        /// </summary>
        public bool ValidarUsuario(string login, string clave)
        {
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(clave))
                return false;

            var usuario = _usuarioRepo.ObtenerPorLoginYClave(login, clave);
            if (usuario == null)
                return false;

            // Datos básicos
            EstadoGlobal.LoginUsuario = usuario.Login;
            EstadoGlobal.AreaActual = usuario.Area;
            EstadoGlobal.UnidadActual = usuario.Unidad;
            EstadoGlobal.PrivilegiosUsuario = usuario.Privilegios;
            EstadoGlobal.DNIUsuario = usuario.Dni.ToString();

            // --- NIF y cadena E########L (MiVarDeusuario) ---
            // NIF clásico: 8 dígitos + letra
            var dni8 = usuario.Dni.ToString("D8");         // rellena con ceros a la izquierda
            var letra = CalcularLetraNif(usuario.Dni);
            EstadoGlobal.NIFUsuario = dni8 + letra;

            // MiVarDeusuario = "E" + 8 dígitos + letra (como en VB6)
            EstadoGlobal.VarUsuario = $"E{dni8}{letra}";

            // MiRutaDeUsuario = "c:\users\E########L\"
            EstadoGlobal.RutaUsuario = $@"c:\users\{EstadoGlobal.VarUsuario}\";

            // --- Fecha de seguridad ---
            // VB6: Cfecha = DateAdd("d", -fechaseguridad, Date)
            //      If lunes y fechaseguridad=1 => DateAdd("d", -3, Date)
            var hoy = DateTime.Today;
            var dias = usuario.FechaSeguridad;  // campo int "FechaSeguridad" de la tabla usuarios
            var fechaSeg = hoy.AddDays(-dias);

            if (hoy.DayOfWeek == DayOfWeek.Monday && dias == 1)
            {
                // Caso especial de VB6 cuando es lunes
                fechaSeg = hoy.AddDays(-3);
            }

            EstadoGlobal.FechaSeguridad = fechaSeg;

            return true;
        }

        /// <summary>
        /// Calcula la letra del NIF español para un DNI numérico.
        /// </summary>
        private static string CalcularLetraNif(int dni)
        {
            const string letras = "TRWAGMYFPDXBNJZSQVHLCKE";
            int index = Math.Abs(dni) % 23;
            return letras[index].ToString();
        }
    }
}
