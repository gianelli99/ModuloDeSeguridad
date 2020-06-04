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

            txtUsername.Text = usuario.Username;
            txtContrasena.Text = usuario.Password;
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
                    case "Modificar":
                        break;
                    case "Baja":
                        break;
                    case "Cambiar Contraseña":
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
