using System;
using System.Windows.Forms;
using PGP.Turnos.Modelos;
using PGP.Turnos.Negocio;

namespace PGP.Turnos.UI
{
    public partial class FrmPanelControl : Form
    {
        private readonly PanelControlService _panelService;

        public FrmPanelControl()
        {
            InitializeComponent();
            _panelService = new PanelControlService();
        }

        private void FrmPanelControl_Load(object? sender, EventArgs e)
        {
            // Título estándar con usuario
            Text = EstadoGlobal.ObtenerTituloPantalla("Panel de control");

            // Estilo combos
            cmbArea.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUnidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMes.DropDownStyle = ComboBoxStyle.DropDownList;

            CargarAreas();
            CargarMeses();

            // Al cambiar el Área se recargan las Unidades
            cmbArea.SelectedIndexChanged += cmbArea_SelectedIndexChanged;

            // Si ya teníamos un Área y Unidad en EstadoGlobal, seleccionarlos (si existen)
            SeleccionarAreaYUnidadDesdeEstadoGlobal();
        }

        private void CargarAreas()
        {
            var areas = _panelService.ObtenerAreas();
            cmbArea.DataSource = areas;

            // Si no hay nada, limpiamos unidades también
            if (areas.Count == 0)
            {
                cmbUnidad.DataSource = null;
            }
            else
            {
                // Cargamos las unidades de la primera área por defecto
                CargarUnidadesParaAreaSeleccionada();
            }
        }

        private void CargarUnidadesParaAreaSeleccionada()
        {
            var areaSeleccionada = cmbArea.SelectedItem as string;

            if (string.IsNullOrWhiteSpace(areaSeleccionada))
            {
                cmbUnidad.DataSource = null;
                return;
            }

            var unidades = _panelService.ObtenerUnidadesPorArea(areaSeleccionada);
            cmbUnidad.DataSource = unidades;
        }

        private void CargarMeses()
        {
            var meses = _panelService.ObtenerMeses();

            if (meses.Count > 0)
            {
                cmbMes.DataSource = meses;

                // Intentar seleccionar el mes actual si coincide por nombre
                var nombreMesActual = ObtenerNombreMesActualEnCastellano();

                var indice = meses.FindIndex(m =>
                    string.Equals(m, nombreMesActual, StringComparison.OrdinalIgnoreCase));

                if (indice >= 0)
                {
                    cmbMes.SelectedIndex = indice;
                }
                else
                {
                    cmbMes.SelectedIndex = 0;
                }
            }
            else
            {
                // Si por lo que sea la tabla 'meses' está vacía,
                // podríamos rellenar a mano como plan B
                cmbMes.DataSource = new[]
                {
                    "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
                    "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"
                };
                cmbMes.SelectedIndex = DateTime.Today.Month - 1;
            }
        }

        private string ObtenerNombreMesActualEnCastellano()
        {
            // Mes actual como número (1-12)
            int mes = DateTime.Today.Month;

            // Lo mapeamos manualmente para que coincida con la tabla 'meses'
            return mes switch
            {
                1 => "Enero",
                2 => "Febrero",
                3 => "Marzo",
                4 => "Abril",
                5 => "Mayo",
                6 => "Junio",
                7 => "Julio",
                8 => "Agosto",
                9 => "Septiembre",
                10 => "Octubre",
                11 => "Noviembre",
                12 => "Diciembre",
                _ => ""
            };
        }

        private void cmbArea_SelectedIndexChanged(object? sender, EventArgs e)
        {
            // Cada vez que cambia el Área,
            // recargamos las Unidades y actualizamos EstadoGlobal
            CargarUnidadesParaAreaSeleccionada();

            var areaSeleccionada = cmbArea.SelectedItem as string;
            if (!string.IsNullOrWhiteSpace(areaSeleccionada))
            {
                EstadoGlobal.AreaActual = areaSeleccionada;
            }
        }

        private void SeleccionarAreaYUnidadDesdeEstadoGlobal()
        {
            // Seleccionar Área si existe en la lista
            if (!string.IsNullOrWhiteSpace(EstadoGlobal.AreaActual) && cmbArea.Items.Count > 0)
            {
                int idxArea = -1;
                for (int i = 0; i < cmbArea.Items.Count; i++)
                {
                    if (string.Equals(
                            cmbArea.Items[i]?.ToString(),
                            EstadoGlobal.AreaActual,
                            StringComparison.OrdinalIgnoreCase))
                    {
                        idxArea = i;
                        break;
                    }
                }

                if (idxArea >= 0)
                {
                    cmbArea.SelectedIndex = idxArea;
                }
            }

            // Tras seleccionar Área (lo que dispara el recargado de Unidades),
            // intentamos seleccionar Unidad
            if (!string.IsNullOrWhiteSpace(EstadoGlobal.UnidadActual) && cmbUnidad.Items.Count > 0)
            {
                int idxUnidad = -1;
                for (int i = 0; i < cmbUnidad.Items.Count; i++)
                {
                    if (string.Equals(
                            cmbUnidad.Items[i]?.ToString(),
                            EstadoGlobal.UnidadActual,
                            StringComparison.OrdinalIgnoreCase))
                    {
                        idxUnidad = i;
                        break;
                    }
                }

                if (idxUnidad >= 0)
                {
                    cmbUnidad.SelectedIndex = idxUnidad;
                }
            }
        }

        // === Botones (igual que antes, de momento solo mensajes) ===

        private void btnCartelerasAlfabetico_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Edición de carteleras por orden alfabético (pendiente de implementar).",
                "Carteleras", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCartelerasPorTurno_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Edición de carteleras por orden de turno (pendiente de implementar).",
                "Carteleras por turno", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnImprimirCarteleraAlfabetico_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Impresión de cartelera por orden alfabético (pendiente de implementar).",
                "Imprimir cartelera", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnImprimirCarteleraPorTurno_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Impresión de cartelera por turno (pendiente de implementar).",
                "Imprimir cartelera por turno", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAñadirTurnos_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Añadir y modificar turnos (pendiente de implementar).",
                "Añadir turnos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnProlongarTurno_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Prolongar turno y ver programación (pendiente de implementar).",
                "Prolongar turno", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSustituciones_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Gestión de sustituciones (pendiente de implementar).",
                "Sustituciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnPresenciasSemanales_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Presencias semanales (pendiente de implementar).",
                "Presencias semanales", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSalir_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}
