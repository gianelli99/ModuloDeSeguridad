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
            CheckForIllegalCrossThreadCalls = false;
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

                button.Padding = new Padding(10, 0, 10, 0);
                button.Margin = new Padding(4);
                button.ImageAlign = ContentAlignment.MiddleLeft;
                button.TextAlign = ContentAlignment.MiddleRight;
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.BackColor = Color.FromArgb(94, 48, 228);
                button.Size = new Size(button.Size.Width,40);
                button.Image = Image.FromFile(@"..\..\Resources\" + accion.IconName);
                button.TextImageRelation = TextImageRelation.ImageBeforeText;
                flpAcciones.Controls.Add(button);
            }
            foreach (var grupo in usuario.Grupos)
            {
                var label = new Label();
                label.AutoSize = true;
                label.Margin = new Padding(0, 2, 0, 2);
                label.Name = grupo.ID.ToString();
                label.Text = " → " + grupo.Descripcion;
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

        public void Actualizar(bool isFirst)
        {
            if (isFirst)
            {
                MessageBox.Show("Su sesión se cerrará automaticamente");
            }
            Logica.SesionBL.ObtenerInstancia().Desuscribir(this);
            this.Dispose();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Actualizar(false);
        }
    }
}
