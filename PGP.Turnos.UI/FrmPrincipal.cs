using System;
using System.Windows.Forms;
using PGP.Turnos.Modelos;

namespace PGP.Turnos.UI
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            Text = $"PGP Turnos - Usuario: {EstadoGlobal.LoginUsuario} - Unidad: {EstadoGlobal.UnidadActual}";
        }
    }
}
