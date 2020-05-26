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
        private void BtnCrud(object sender, EventArgs e)
        {
            if (((Button)sender).Name == "btnAlta")
            {
                frmGrupo frm = new frmGrupo(Accion.Alta, new Modelo.Grupo());// esta mal hay que hacer 2 constructores
                frm.ShowDialog();
                dgvGrupos.DataSource = null;
                dgvGrupos.DataSource = grupoBL.Listar();
            }
            if (((Button)sender).Name == "btnBaja")//validar
            {
                grupoBL.Eliminar(((Modelo.Grupo)dgvGrupos.CurrentRow.DataBoundItem).ID);
                dgvGrupos.DataSource = null;
                dgvGrupos.DataSource = grupoBL.Listar();
            }
            if (((Button)sender).Name == "btnModificacion")
            {
                frmGrupo frm = new frmGrupo(Accion.Modificacion, (Modelo.Grupo)dgvGrupos.CurrentRow.DataBoundItem);
                frm.ShowDialog();
                dgvGrupos.DataSource = null;
                dgvGrupos.DataSource = grupoBL.Listar();
            }
            if (((Button)sender).Name == "btnConsulta")
            {
                frmGrupo frm = new frmGrupo(Accion.Consulta, (Modelo.Grupo)dgvGrupos.CurrentRow.DataBoundItem);
                frm.ShowDialog();
                dgvGrupos.DataSource = null;
                dgvGrupos.DataSource = grupoBL.Listar();
            }

        }

    }
}
