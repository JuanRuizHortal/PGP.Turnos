using System;
using System.Windows.Forms;
using PGP.Turnos.Modelos;
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

            // Contraseña como *****
            txtClave.UseSystemPasswordChar = true;

            // Año por defecto: año actual
            txtAnioTrabajo.Text = DateTime.Today.Year.ToString();
        }

        private void btnAceptar_Click(object? sender, EventArgs e)
        {
            var login = txtUsuario.Text.Trim();
            var clave = txtClave.Text;

            // Validar año de trabajo
            if (!int.TryParse(txtAnioTrabajo.Text, out int anio))
            {
                MessageBox.Show("El año de trabajo no es válido.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAnioTrabajo.Focus();
                txtAnioTrabajo.SelectAll();
                return;
            }

            if (anio < 2017 || anio > 2200)
            {
                MessageBox.Show("El año de trabajo debe estar entre 2017 y 2200.",
                    "Año de trabajo incorrecto",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAnioTrabajo.Focus();
                txtAnioTrabajo.SelectAll();
                return;
            }

            // Guardar año en el estado global
            EstadoGlobal.AnioTrabajo = anio;

            // Validar usuario/clave
            var ok = _authService.ValidarUsuario(login, clave);

            if (!ok)
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Acceso denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtClave.Clear();
                txtClave.Focus();
                return;
            }

            // Autenticación correcta → cerrar formulario y que Program abra el Panel de Control
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
