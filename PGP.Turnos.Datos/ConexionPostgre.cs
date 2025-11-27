using System.Configuration;
using Npgsql;

namespace PGP.Turnos.Datos
{
    /// <summary>
    /// Proporciona métodos para obtener conexiones a PostgreSQL.
    /// </summary>
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

        public static NpgsqlConnection CrearConexion()
        {
            var connString = ObtenerCadenaConexion();
            return new NpgsqlConnection(connString);
        }
    }
}
