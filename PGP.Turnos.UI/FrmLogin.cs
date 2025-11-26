using System;
using System.Windows.Forms;
using PGP.Turnos.Negocio;
using PGP.Turnos.Modelos;

namespace PGP.Turnos.UI
{
    public partial class FrmLogin : Form
    {
        private readonly AutenticacionService _authService;

        public FrmLogin()
        {
            InitializeComponent();
            _authService = new AutenticacionService();

            // Registrar el handler Load (si el diseñador ya lo hace no perjudica)
            this.Load += FrmLogin_Load;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            // Mostrar estado global en el título del formulario
            Text = $"PGP Turnos - Usuario: {EstadoGlobal.LoginUsuario} - Unidad: {EstadoGlobal.UnidadActual}";
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

            // Mostrar mensaje con el área después de que la validación (SQL) se complete
            MessageBox.Show($"El área es: {EstadoGlobal.PrivilegiosUsuario}", "Acceso correcto",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Si todo va bien, cerrar login con OK
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
