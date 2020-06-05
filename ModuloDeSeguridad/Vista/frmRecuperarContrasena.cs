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

                string passDES = Logica.Hasheo.RandomString(6,true);
                string passENC = Logica.Hasheo.GetMd5Hash(passDES);
                usuario.Password = passENC;
                

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("gianjuanze@gmail.com");
                mail.To.Add(usuario.Email);
                mail.Subject = "Nueva contraseña Módulo de Seguridad";
                mail.Body = "Su nueva contraseña es: " + passDES;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("gianjuanze@gmail.com", "gianjuan2020");
                SmtpServer.EnableSsl = true;

                usuarioBL.CambiarContrasena(passDES, usuario.ID, usuario.ID);
                SmtpServer.Send(mail);
                
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
