using Npgsql;
using PGP.Turnos.Modelos;

namespace PGP.Turnos.Datos
{
    /// <summary>
    /// Acceso a datos para la tabla 'usuarios'.
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
}
