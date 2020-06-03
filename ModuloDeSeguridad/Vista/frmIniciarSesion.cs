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
        private Logica.SesionBL sesionBL;
        public frmIniciarSesion()
        {
            InitializeComponent();
            sesionBL = Logica.SesionBL.ObtenerInstancia();
        }

        public void Actualizar()
        {
            sesionBL.Desuscribir(this);
            Modelo.Sesion.ObtenerInstancia().LogOut = DateTime.Now;
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

                    var sesion = Modelo.Sesion.ObtenerInstancia();
                    sesion.Usuario = sesionBL.ConsultarUsuario(userId);
                    sesion.LogIn = DateTime.Now;
                    frmInicio inicio = new frmInicio();
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
