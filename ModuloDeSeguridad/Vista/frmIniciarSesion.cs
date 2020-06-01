using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModuloDeSeguridad.Vista
{
    public partial class frmIniciarSesion : Form
    {
        private Modelo.Sesion sesion;
        private Logica.SesionBL SesionBL;
        public frmIniciarSesion()
        {
            InitializeComponent();
            SesionBL = new Logica.SesionBL();
        }

        private void BtnIniciarSesion_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtUsername.Text) || String.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                MessageBox.Show("Debe completar todos los campos");
                return;
            }
            try
            {
                int userId = SesionBL.ValidarUsuario(txtUsername.Text, txtContrasena.Text);
                if (userId != -1)
                {
                    sesion = new Modelo.Sesion(DateTime.Now, SesionBL.ConsultarUsuario(userId));
                    frmInicio inicio = new frmInicio(sesion);
                    this.Hide();
                    inicio.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Username o Contraseña incorrectos");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
