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
    public partial class frmGrupos : Form
    {
        private Logica.GrupoBL grupoBL;
        private List<Modelo.Grupo> grupos;
        private Modelo.Usuario user;
        public frmGrupos()
        {
            InitializeComponent();
            grupoBL = new Logica.GrupoBL();
            var accionesDisponibles = grupoBL.ListarAccionesDisponibles(1,1);
            foreach (var accion in accionesDisponibles)
            {
                var button = new Button();
                button.Name = "btn" + accion.Descripcion;
                button.Text = accion.Descripcion;
                button.Click += BtnCrud;
                flpCrud.Controls.Add(button);
            }
            grupos = grupoBL.Listar();
            dgvGrupos.DataSource = grupos;
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            dgvGrupos.DataSource = null;
            dgvGrupos.DataSource = grupoBL.Listar(grupos, txtBuscar.Text);
        }
        private bool TieneElementoSeleccionado()
        {
            return dgvGrupos.CurrentRow != null ? true : false;
        }
        private void BtnCrud(object sender, EventArgs e)
        {
            try
            {
                switch (((Button)sender).Name)
                {
                    case "btnAlta":
                        frmGrupo frm = new frmGrupo();
                        DialogResult result = frm.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            dgvGrupos.DataSource = null;
                            dgvGrupos.DataSource = grupoBL.Listar();
                        }
                        break;
                    case "btnBaja":
                        if (TieneElementoSeleccionado())
                        {
                            var grupo = (Modelo.Grupo)dgvGrupos.CurrentRow.DataBoundItem;

                            DialogResult resultado = MessageBox.Show("Desea eliminar el grupo " + grupo.Descripcion, "Confirmación", MessageBoxButtons.YesNo);
                            if (resultado == DialogResult.Yes)
                            {
                                try
                                {
                                    grupoBL.Eliminar(grupo.ID);
                                    dgvGrupos.DataSource = null;
                                    dgvGrupos.DataSource = grupoBL.Listar();
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
                            frmGrupo frmMod = new frmGrupo(Accion.Modificacion, (Modelo.Grupo)dgvGrupos.CurrentRow.DataBoundItem);
                            DialogResult resultMod = frmMod.ShowDialog();
                            if (resultMod == DialogResult.OK)
                            {
                                dgvGrupos.DataSource = null;
                                dgvGrupos.DataSource = grupoBL.Listar();
                            }
                        }
                        break;
                    case "btnConsulta":
                        if (TieneElementoSeleccionado())
                        {
                            frmGrupo frmConsulta = new frmGrupo(Accion.Consulta, (Modelo.Grupo)dgvGrupos.CurrentRow.DataBoundItem);
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
    }
}
