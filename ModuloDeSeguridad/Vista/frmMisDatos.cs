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
    public partial class frmMisDatos : Form, Logica.Interfaces.ISesionObserver
    {
        private Modelo.Usuario usuario;
        private Logica.UsuarioBL usuarioBL;
        public frmMisDatos(int vistaId)
        {
            InitializeComponent();
            int userId = Modelo.Sesion.ObtenerInstancia().Usuario.ID;
            usuarioBL = new Logica.UsuarioBL();
            usuario = usuarioBL.Consultar(userId);
            Logica.SesionBL.ObtenerInstancia().Suscribir(this);

            var accionesDisponibles = usuarioBL.ListarAccionesDisponibles(userId, vistaId);
            foreach (var accion in accionesDisponibles)
            {
                var button = new Button();
                button.Name = "btn" + accion.Descripcion;
                button.Text = accion.Descripcion;
                button.AutoSize = true;
                button.Click += BtnAccion;
                flpAcciones.Controls.Add(button);
            }
            foreach (var grupo in usuario.Grupos)
            {
                var label = new Label();
                label.Name = grupo.ID.ToString();
                label.Text = grupo.Descripcion;
                flpGrupos.Controls.Add(label);
            }

            txtUsername.Text = usuario.Username;
            txtEmail.Text = usuario.Email;
            txtNombre.Text = usuario.Nombre;
            txtApellido.Text = usuario.Apellido;
        }

        private void BtnAccion(object sender, EventArgs e)
        {
            try
            {
                switch (((Button)sender).Text)
                {
                    case "Modificacion":
                        //validar
                        if (String.IsNullOrWhiteSpace(txtUsername.Text) ||
                            String.IsNullOrWhiteSpace(txtEmail.Text) ||
                            String.IsNullOrWhiteSpace(txtNombre.Text) ||
                            String.IsNullOrWhiteSpace(txtApellido.Text))
                        {
                            MessageBox.Show("Debe completar todos los campos");
                            return;
                        }
                        try//validar email
                        {
                            var addr = new System.Net.Mail.MailAddress(txtEmail.Text);
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
                        //modificar
                       
                        DialogResult modificar = MessageBox.Show("¿Está seguro que desea modificar sus datos?", "Modificación", MessageBoxButtons.YesNo);
                        if (modificar == DialogResult.Yes)
                        {
                            usuario.Username = txtUsername.Text;
                            usuario.Email = txtEmail.Text;
                            usuario.Nombre = txtNombre.Text;
                            usuario.Apellido = txtApellido.Text;
                            usuarioBL.Modificar(usuario, usuario.ID,false);
                        }
                        break;
                    case "Baja":
                        DialogResult eliminar = MessageBox.Show("¿Está seguro que desea darse de baja?", "Eliminación", MessageBoxButtons.YesNo);
                        if (eliminar==DialogResult.Yes)
                        {
                            usuarioBL.Eliminar(usuario.ID, usuario.ID);
                            Logica.SesionBL.ObtenerInstancia().FinalizarSesion();
                        }
                        break;
                    case "Cambiar Contraseña":
                        frmCambiarContrasena frmCambiarContrasena = new frmCambiarContrasena(usuario.ID);
                        frmCambiarContrasena.ShowDialog();
                        usuarioBL.Consultar(usuario.ID);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error.");
            }
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
    }
}
