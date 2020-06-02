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
    public partial class frmIniciarSesion : Form, Logica.Interfaces.ISesionObserver
    {
        private Modelo.Sesion sesion;
        private Logica.SesionBL sesionBL;
        public frmIniciarSesion()
        {
            InitializeComponent();
            sesionBL = Logica.SesionBL.ObtenerInstancia();
        }

        public void Actualizar()
        {
            sesionBL.Desuscribir(this);
            this.Show();
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
                int userId = sesionBL.ValidarUsuario(txtUsername.Text, txtContrasena.Text);
                if (userId != -1)
                {
                    sesionBL.Suscribir(this);
                    sesion = new Modelo.Sesion(DateTime.Now, sesionBL.ConsultarUsuario(userId));
                    frmInicio inicio = new frmInicio(sesion);
                    this.Hide();
                    DialogResult result = inicio.ShowDialog();
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
