using System.Configuration;
using Npgsql;

namespace PGP.Turnos.Datos
{
    public static class ConexionPostgre
    {
        public static string ObtenerCadenaConexion()
        {
            var cs = ConfigurationManager
                .ConnectionStrings["TurnosDb"]
                ?.ConnectionString;

            if (string.IsNullOrWhiteSpace(cs))
            {
                throw new ConfigurationErrorsException(
                    "No se ha encontrado la cadena de conexión 'TurnosDb' en App.config.");
            }

            return cs;
        }

        /// <summary>
        /// Devuelve una conexión SIN abrir.
        /// (La conservamos por si en algún sitio quieres controlarlo tú.)
        /// </summary>
        public static NpgsqlConnection CrearConexion()
        {
            var connString = ObtenerCadenaConexion();
            return new NpgsqlConnection(connString);
        }

        /// <summary>
        /// Devuelve una conexión YA ABIERTA lista para usar.
        /// Este es el método que utilizamos en los repositorios.
        /// </summary>
        public static NpgsqlConnection ObtenerConexion()
        {
            var conn = CrearConexion();
            conn.Open();
            return conn;
        }
    }
}
