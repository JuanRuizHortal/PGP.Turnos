using System;

namespace PGP.Turnos.Modelos
{
    /// <summary>
    /// Variables globales de la aplicación, accesibles desde cualquier capa.
    /// Equivalente a las variables públicas de módulos VB6.
    /// </summary>
    public static class EstadoGlobal
    {
        // Año de trabajo (Vao en VB6)
        public static int AnioTrabajo { get; set; } = DateTime.Now.Year;

        // Empleado actual (cuando estemos en carteleras, etc.)
        public static int IdEmpleadoActual { get; set; }

        // Área y unidad actuales del usuario
        public static string AreaActual { get; set; } = string.Empty;
        public static string UnidadActual { get; set; } = string.Empty;

        // Datos de usuario
        public static string LoginUsuario { get; set; } = string.Empty;
        public static string PrivilegiosUsuario { get; set; } = string.Empty;

        public static string DNIUsuario { get; set; } = string.Empty;   // solo número
        public static string NIFUsuario { get; set; } = string.Empty;   // 8 dígitos + letra

        // Fecha de seguridad (VfechaSeguridad en VB6)
        public static DateTime FechaSeguridad { get; set; } = DateTime.Today;

        // Cadena tipo "E########L" y ruta tipo "c:\users\E########L\"
        public static string VarUsuario { get; set; } = string.Empty;   // MiVarDeusuario en VB6
        public static string RutaUsuario { get; set; } = string.Empty;  // MiRutaDeUsuario en VB6
        public static string ObtenerTituloPantalla(string nombrePantalla)
        {
            // Si todavía no hay usuario (por seguridad), evita poner "Usuario: "
            var usuario = string.IsNullOrWhiteSpace(LoginUsuario)
                ? "(sin usuario)"
                : LoginUsuario;

            return $"Programa de turnos: {nombrePantalla}, Usuario: {usuario}";
        }
    }
}


