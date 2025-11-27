namespace PGP.Turnos.Modelos
{
    /// <summary>
    /// Representa un registro de la tabla 'usuarios'.
    /// </summary>
    public class Usuario
    {
        public int Dni { get; set; }
        public string Login { get; set; } = string.Empty;
        public string Area { get; set; } = string.Empty;
        public string Unidad { get; set; } = string.Empty;
        public string Privilegios { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public int Incremental { get; set; }
        public int FechaSeguridad { get; set; }
    }
}
