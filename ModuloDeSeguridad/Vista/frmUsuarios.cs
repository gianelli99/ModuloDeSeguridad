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
            CheckForIllegalCrossThreadCalls = false;
            Logica.SesionBL.ObtenerInstancia().Suscribir(this);
            usuarioBL = new Logica.UsuarioBL();
            var accionesDisponibles = usuarioBL.ListarAccionesDisponibles(Modelo.Sesion.ObtenerInstancia().Usuario.ID, vistaId);
            foreach (var accion in accionesDisponibles)
            {
                var button = new Button();
                button.Name = "btn" + accion.Descripcion;
                button.Text = accion.Descripcion.Length > 12 ? accion.Descripcion.Substring(0,12) : accion.Descripcion;
                button.Click += BtnCrud;
                button.Padding = new Padding(4);
                button.ImageAlign = ContentAlignment.TopCenter;
                button.TextAlign = ContentAlignment.BottomCenter;
                button.FlatStyle = FlatStyle.Flat;
                button.AutoEllipsis = true;
                button.FlatAppearance.BorderSize = 0;
                button.BackColor = Color.FromArgb(94, 48, 228);
                button.Size = new Size(135, 72);
                button.Image = Image.FromFile(@"..\..\Resources\" + accion.IconName);
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
                switch (((Button)sender).Name)
                {
                    case "btnAlta":
                        frmUsuario frm = new frmUsuario();
                        DialogResult result = frm.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            dgvUsuarios.DataSource = null;
                            dgvUsuarios.DataSource = usuarioBL.Listar();
                            dgvUsuarios.Columns["Password"].Visible = false;
                        }
                        break;
                    case "btnBaja":
                        if (TieneElementoSeleccionado())
                        {
                            var usuario = (Modelo.Usuario)dgvUsuarios.CurrentRow.DataBoundItem;

                            if (usuario.ID == Modelo.Sesion.ObtenerInstancia().Usuario.ID)
                            {
                                MessageBox.Show("Para realizar esta acción ingrese a \"Mis Datos\"");
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
                    case "btnModificacion":
                        if (TieneElementoSeleccionado())
                        {
                            var usuario = (Modelo.Usuario)dgvUsuarios.CurrentRow.DataBoundItem;
                            if (usuario.ID == Modelo.Sesion.ObtenerInstancia().Usuario.ID)
                            {
                                MessageBox.Show("Para realizar esta acción ingrese a \"Mis Datos\"");
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
                    case "btnConsulta":
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
                    case "btnCambiar Contraseña":
                        if (TieneElementoSeleccionado())
                        {
                            var usuario = (Modelo.Usuario)dgvUsuarios.CurrentRow.DataBoundItem;
                            if (usuario.ID == Modelo.Sesion.ObtenerInstancia().Usuario.ID)
                            {
                                MessageBox.Show("Para realizar esta acción ingrese a \"Mis Datos\"");
                                return;
                            }
                            frmCambiarContrasena frmConsulta = new frmCambiarContrasena(((Modelo.Usuario)dgvUsuarios.CurrentRow.DataBoundItem).ID, false);
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
            Actualizar(false);
        }
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = usuarioBL.Listar(usuarios, txtBuscar.Text);
            dgvUsuarios.Columns["Password"].Visible = false;
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

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
