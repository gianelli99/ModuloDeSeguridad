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
    public partial class frmUsuarios : Form
    {
        private Logica.UsuarioBL usuarioBL;
        private List<Modelo.Usuario> usuarios;
        private Modelo.Usuario user;
        public frmUsuarios()
        {
            InitializeComponent();
            usuarioBL = new Logica.UsuarioBL();
            var accionesDisponibles = usuarioBL.ListarAccionesDisponibles(1, 1);
            foreach (var accion in accionesDisponibles)
            {
                var button = new Button();
                button.Name = "btn" + accion.Descripcion;
                button.Text = accion.Descripcion;
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
                switch (((Button)sender).Name)
                {
                    case "btnAlta":
                        frmUsuario frm = new frmUsuario();
                        DialogResult result = frm.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            dgvUsuarios.DataSource = null;
                            dgvUsuarios.DataSource = usuarioBL.Listar();
                        }
                        break;
                    case "btnBaja":
                        if (TieneElementoSeleccionado())
                        {
                            var grupo = (Modelo.Grupo)dgvUsuarios.CurrentRow.DataBoundItem;

                            DialogResult resultado = MessageBox.Show("Desea eliminar el grupo " + grupo.Descripcion, "Confirmación", MessageBoxButtons.YesNo);
                            if (resultado == DialogResult.Yes)
                            {
                                try
                                {
                                    usuarioBL.Eliminar(grupo.ID);
                                    dgvUsuarios.DataSource = null;
                                    dgvUsuarios.DataSource = usuarioBL.Listar();
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
                          //  frmUsuario frmMod = new frmUsuario(Accion.Modificacion, (Modelo.Grupo)dgvUsuarios.CurrentRow.DataBoundItem);
                           // DialogResult resultMod = frmMod.ShowDialog();
                         //   if (resultMod == DialogResult.OK)
                            {
                                dgvUsuarios.DataSource = null;
                                dgvUsuarios.DataSource = usuarioBL.Listar();
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
    }
}
