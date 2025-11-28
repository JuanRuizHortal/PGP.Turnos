using System.Collections.Generic;
using PGP.Turnos.Datos;

namespace PGP.Turnos.Negocio
{
    /// <summary>
    /// Lógica de negocio para el Panel de Control:
    /// carga de listas para Área, Unidad y Mes.
    /// </summary>
    public class PanelControlService
    {
        private readonly PanelControlRepository _repo;

        public PanelControlService()
        {
            _repo = new PanelControlRepository();
        }

        public List<string> ObtenerAreas()
        {
            return _repo.ObtenerAreas();
        }

        public List<string> ObtenerUnidadesPorArea(string area)
        {
            return _repo.ObtenerUnidadesPorArea(area);
        }

        public List<string> ObtenerMeses()
        {
            return _repo.ObtenerMeses();
        }
    }
}
