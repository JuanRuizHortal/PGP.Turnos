using System;
using System.Windows.Forms;
using PGP.Turnos.Negocio;

namespace PGP.Turnos.UI
{
    public partial class FrmLogin : Form
    {
        private readonly AutenticacionService _authService;

        public FrmLogin()
        {
            InitializeComponent();
            _authService = new AutenticacionService();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            var login = txtUsuario.Text.Trim();
            var clave = txtClave.Text;

            var ok = _authService.ValidarUsuario(login, clave);

            if (!ok)
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Acceso denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Login correcto.", "Bienvenido",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
