using System;
using System.Windows.Forms;

namespace PGP.Turnos.UI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            using (var frmLogin = new FrmLogin())
            {
                var resultado = frmLogin.ShowDialog();

                if (resultado != DialogResult.OK)
                {
                    return;    // si no hay login correcto, salimos
                }
            }

            Application.Run(new FrmLogin());
        }
    }
}
