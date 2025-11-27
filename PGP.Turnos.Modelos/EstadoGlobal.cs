namespace PGP.Turnos.Modelos
{
    /// <summary>
    /// Variables globales de la aplicación, accesibles desde cualquier capa.
    /// Equivalente a las variables públicas de módulos VB6.
    /// </summary>
    public static class EstadoGlobal
    {
        public static int AnioTrabajo { get; set; } = 2025;

        public static int IdEmpleadoActual { get; set; }

        public static string AreaActual { get; set; } = string.Empty;
        public static string UnidadActual { get; set; } = string.Empty;

        public static string LoginUsuario { get; set; } = string.Empty;
        public static string PrivilegiosUsuario { get; set; } = string.Empty;

        public static string DNIUsuario { get; set; } = string.Empty;
        public static string NIFUsuario { get; set; } = string.Empty;
    }
}
