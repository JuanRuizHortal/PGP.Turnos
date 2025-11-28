using System.Collections.Generic;
using Npgsql;

namespace PGP.Turnos.Datos
{
    /// <summary>
    /// Acceso a datos para los desplegables del Panel de Control:
    /// Área, Unidad y Mes.
    /// </summary>
    public class PanelControlRepository
    {
        /// <summary>
        /// Devuelve la lista de ÁREAS distintas.
        /// Usa la tabla 'unidades' y la columna "AREAS".
        /// </summary>
        public List<string> ObtenerAreas()
        {
            var resultado = new List<string>();

            const string sql = @"
                SELECT DISTINCT ""AREAS""
                FROM public.unidades
                WHERE ""AREAS"" IS NOT NULL AND ""AREAS"" <> ''
                ORDER BY ""AREAS"";
            ";

            using (var conn = ConexionPostgre.ObtenerConexion())
            using (var cmd = new NpgsqlCommand(sql, conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var area = reader.GetString(0);
                    resultado.Add(area);
                }
            }

            return resultado;
        }

        /// <summary>
        /// Devuelve la lista de UNIDADES para un Área dada.
        /// Usa la tabla 'unidades' y las columnas "AREAS" y "UNIDADES".
        /// </summary>
        public List<string> ObtenerUnidadesPorArea(string area)
        {
            var resultado = new List<string>();

            const string sql = @"
                SELECT DISTINCT ""UNIDADES""
                FROM public.unidades
                WHERE ""AREAS"" = @area
                  AND ""UNIDADES"" IS NOT NULL AND ""UNIDADES"" <> ''
                ORDER BY ""UNIDADES"";
            ";

            using (var conn = ConexionPostgre.ObtenerConexion())
            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("area", area);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var unidad = reader.GetString(0);
                        resultado.Add(unidad);
                    }
                }
            }

            return resultado;
        }

        /// <summary>
        /// Devuelve la lista de meses desde la tabla 'meses'.
        /// Ajusta el nombre de la columna si en tu BD se llama distinto.
        /// </summary>
        public List<string> ObtenerMeses()
        {
            var resultado = new List<string>();

            // SUPOSICIÓN: tabla 'meses' con columna "MES".
            // Si en tu BD el nombre es otro, cambia "MES" por el real.
            const string sql = @"
                SELECT ""MES""
                FROM public.meses
                ORDER BY 1;
            ";

            using (var conn = ConexionPostgre.ObtenerConexion())
            using (var cmd = new NpgsqlCommand(sql, conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var mes = reader.GetString(0);
                    resultado.Add(mes);
                }
            }

            return resultado;
        }
    }
}

