using System;
using Npgsql;
using PGP.Turnos.Modelos;

namespace PGP.Turnos.Datos
{
    /// <summary>
    /// Acceso a datos para la tabla usuarios.
    /// </summary>
    public class UsuarioRepository
    {
        /// <summary>
        /// Devuelve el usuario si el login/clave son correctos, o null si no.
        /// </summary>
        public Usuario? ObtenerPorLoginYClave(string login, string clave)
        {
            using var conn = ConexionPostgre.CrearConexion();
            conn.Open();

            const string sql = @"
                SELECT 
                    dni,
                    ""Login"",
                    area,
                    ""UNIDAD"",
                    ""PRIVILEGIOS"",
                    nombre,
                    ""INCREMENTAL"",
                    ""FechaSeguridad""
                FROM usuarios
                WHERE ""Login"" = @login
                  AND clave = @clave
                LIMIT 1;";

            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("login", login);
            cmd.Parameters.AddWithValue("clave", clave);

            using var reader = cmd.ExecuteReader();

            if (!reader.Read())
                return null;

            var usuario = new Usuario
            {
                Dni = reader.GetInt32(reader.GetOrdinal("dni")),
                Login = reader.GetString(reader.GetOrdinal("Login")),
                Area = reader.GetString(reader.GetOrdinal("area")),
                Unidad = reader.GetString(reader.GetOrdinal("UNIDAD")),
                Privilegios = reader.GetString(reader.GetOrdinal("PRIVILEGIOS")),
                Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                Incremental = reader.GetInt32(reader.GetOrdinal("INCREMENTAL")),
                FechaSeguridad = reader.GetInt32(reader.GetOrdinal("FechaSeguridad"))
            };

            return usuario;
        }
    }

    /// <summary>
    /// Helper para crear conexiones Npgsql. Lee la cadena de conexión desde la variable de entorno
    /// "PGP_TURNOS_CONN" o usa una cadena por defecto para desarrollo local.
    /// Añade validaciones para evitar intentar abrir conexiones con credenciales incompletas.
    /// </summary>
    public static class ConexionPostgre
    {
        public static NpgsqlConnection CrearConexion()
        {
            var connString = Environment.GetEnvironmentVariable("PGP_TURNOS_CONN");
            if (string.IsNullOrWhiteSpace(connString))
            {
                // Cadena por defecto de desarrollo. Cambiar en producción.
                connString = "Host=217.182.206.142;Username=pgp_app_user;Password=;Database=turnos";
            }

            // Validar que la cadena contiene Username y Password antes de crear la conexión
            var normalized = connString.ToLowerInvariant();
            if (!normalized.Contains("username=") || !normalized.Contains("password="))
            {
                throw new InvalidOperationException("Cadena de conexión inválida. Asegúrese de que la variable de entorno 'PGP_TURNOS_CONN' incluya Username y Password. Ejemplo: 'Host=...;Username=...;Password=...;Database=...'.");
            }

            return new NpgsqlConnection(connString);
        }
    }
}
