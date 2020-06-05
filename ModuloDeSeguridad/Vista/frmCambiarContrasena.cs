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
    public partial class frmCambiarContrasena : Form, Logica.Interfaces.ISesionObserver
    {
        private Logica.UsuarioBL usuarioBL;
        private Modelo.Usuario usuario;
        int userId;
        public frmCambiarContrasena(int miUserId)
        {
            InitializeComponent();
            userId = miUserId;
            usuarioBL = new Logica.UsuarioBL();
            usuario = usuarioBL.Consultar(userId);
            Logica.SesionBL.ObtenerInstancia().Suscribir(this);
        }

        public void Actualizar()
        {
            Logica.SesionBL.ObtenerInstancia().Desuscribir(this);
            this.Dispose();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtContrasenaActual.Text) ||
                String.IsNullOrWhiteSpace(txtContrasenaNueva.Text) ||
                String.IsNullOrWhiteSpace(txtRepetirContrasena.Text))
            {
                MessageBox.Show("Debe completar todos los campos");
                return;
            }

            if (txtContrasenaNueva.Text != txtRepetirContrasena.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden");
                return;
            }

            if (!usuarioBL.ValidarContrasena(usuario,txtContrasenaActual.Text,txtContrasenaNueva.Text))
            {
                MessageBox.Show("La contraseña actual no es correcta o coincide con la nueva");
                return;
            }
            try
            {
                usuarioBL.CambiarContrasena(txtContrasenaNueva.Text, userId,Modelo.Sesion.ObtenerInstancia().Usuario.ID);
                
                Actualizar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
