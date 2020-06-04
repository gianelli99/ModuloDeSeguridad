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
    public partial class frmUsuarios : Form, Logica.Interfaces.ISesionObserver
    {
        private Logica.UsuarioBL usuarioBL;
        private List<Modelo.Usuario> usuarios;
        public frmUsuarios(int vistaId)
        {
            InitializeComponent();
            Logica.SesionBL.ObtenerInstancia().Suscribir(this);
            usuarioBL = new Logica.UsuarioBL();
            var accionesDisponibles = usuarioBL.ListarAccionesDisponibles(Modelo.Sesion.ObtenerInstancia().Usuario.ID, vistaId);
            foreach (var accion in accionesDisponibles)
            {
                var button = new Button();
                button.Name = "btn" + accion.Descripcion;
                button.Text = accion.Descripcion;
                button.AutoSize = true;
                button.Click += BtnCrud;
                flpCrud.Controls.Add(button);
            }
            usuarios = usuarioBL.Listar();
            dgvUsuarios.DataSource = usuarios;
            dgvUsuarios.Columns["Password"].Visible = false;
        }
        private void BtnCrud(object sender, EventArgs e)
        {
            try
            {
                switch (((Button)sender).Text)
                {
                    case "Alta":
                        frmUsuario frm = new frmUsuario();
                        DialogResult result = frm.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            dgvUsuarios.DataSource = null;
                            dgvUsuarios.DataSource = usuarioBL.Listar();
                            dgvUsuarios.Columns["Password"].Visible = false;
                        }
                        break;
                    case "Baja":
                        if (TieneElementoSeleccionado())
                        {
                            var usuario = (Modelo.Usuario)dgvUsuarios.CurrentRow.DataBoundItem;

                            if (usuario.ID == Modelo.Sesion.ObtenerInstancia().Usuario.ID)
                            {
                                MessageBox.Show("No puede eliminarse a si mismo..Ingrese a \"Mis Datos\"");
                                return;
                            }

                            DialogResult resultado = MessageBox.Show("Desea eliminar el usuario " + usuario.Username, "Confirmación", MessageBoxButtons.YesNo);
                            if (resultado == DialogResult.Yes)
                            {
                                try
                                {
                                    usuarioBL.Eliminar(usuario.ID,  1);//Modelo.Sesion.ObtenerInstancia().ID);
                                    dgvUsuarios.DataSource = null;
                                    dgvUsuarios.DataSource = usuarioBL.Listar();
                                    dgvUsuarios.Columns["Password"].Visible = false;
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                    return;
                                }
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Debe seleccionar un Grupo para eliminarlo");
                            return;
                        }
                        break;
                    case "Modificacion":
                        if (TieneElementoSeleccionado())
                        {
                            var usuario = (Modelo.Usuario)dgvUsuarios.CurrentRow.DataBoundItem;
                            if (usuario.ID == Modelo.Sesion.ObtenerInstancia().Usuario.ID)
                            {
                                MessageBox.Show("No puede modificarse a si mismo. Ingrese a \"Mis Datos\"");
                                return;
                            }
                            frmUsuario frmMod = new frmUsuario(Accion.Modificacion, ((Modelo.Usuario)dgvUsuarios.CurrentRow.DataBoundItem).ID);
                            DialogResult resultMod = frmMod.ShowDialog();
                            if (resultMod == DialogResult.OK)
                            {
                                dgvUsuarios.DataSource = null;
                                dgvUsuarios.DataSource = usuarioBL.Listar();
                                dgvUsuarios.Columns["Password"].Visible = false;
                            }
                        }
                        break;
                    case "Consulta":
                        if (TieneElementoSeleccionado())
                        {
                            frmUsuario frmConsulta = new frmUsuario(Accion.Consulta, ((Modelo.Usuario)dgvUsuarios.CurrentRow.DataBoundItem).ID);
                            frmConsulta.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Debe seleccionar un Grupo para consultarlo");
                            return;
                        }
                        break;
                    case "Cambiar Contraseña":
                        if (TieneElementoSeleccionado())
                        {
                            frmCambiarContrasena frmConsulta = new frmCambiarContrasena(((Modelo.Usuario)dgvUsuarios.CurrentRow.DataBoundItem).ID);
                            frmConsulta.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Debe seleccionar un Grupo para consultarlo");
                            return;
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio un error, intente otra vez");
            }
        }
        private bool TieneElementoSeleccionado()
        {
            return dgvUsuarios.CurrentRow != null ? true : false;
        }
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = usuarioBL.Listar(usuarios, txtBuscar.Text);
            dgvUsuarios.Columns["Password"].Visible = false;
        }

        public void Actualizar()
        {
            Logica.SesionBL.ObtenerInstancia().Desuscribir(this);
            this.Dispose();
        }
    }
}
