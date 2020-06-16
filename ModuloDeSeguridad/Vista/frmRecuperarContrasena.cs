using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace ModuloDeSeguridad.Vista
{
    public partial class frmRecuperarContrasena : Form
    {
        Logica.UsuarioBL usuarioBL;
        public frmRecuperarContrasena()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            usuarioBL = new Logica.UsuarioBL();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnEnviarCorreo_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtUsername.Text) || String.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Debe completar todos los campos.");
                return;
            }
            try//validar email
            {
                var addr = new MailAddress(txtEmail.Text);
                if (addr.Address != txtEmail.Text)
                {
                    MessageBox.Show("El email no es válido");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("El email no es válido");
                return;
            }
            try
            {
                Modelo.Usuario usuario = usuarioBL.Consultar(txtUsername.Text, txtEmail.Text);
                if (usuario == null)
                {
                    MessageBox.Show("Los datos ingresados son incorrectos");
                    return;
                }

                string passDES = Logica.Hasheo.RandomString(6, true);
                usuario.Password = Logica.Hasheo.GenerarContrasena(passDES);
               
                usuarioBL.CambiarContrasena(passDES, usuario.ID, usuario.ID);

                usuarioBL.EnviarEmail(passDES,usuario.Email);
                
                MessageBox.Show("Revise su correo electrónico para conocer su nueva contraseña.");
            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error");
            }

            this.Close();
        }
    }
}
