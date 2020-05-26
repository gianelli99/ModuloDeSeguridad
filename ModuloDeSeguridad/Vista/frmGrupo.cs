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
    public partial class frmGrupo : Form
    {
        private Accion accion;
        private Logica.GrupoBL grupoBL;
        private Modelo.Grupo grupo;
        public frmGrupo(Accion miAccion, Modelo.Grupo miGrupo)
        {
            InitializeComponent();
            accion = miAccion;
            grupo = miGrupo;
            grupoBL = new Logica.GrupoBL();
            List<Modelo.Permiso> permisos;
            if (accion == Accion.Alta)
            {
                permisos = grupoBL.ListarPermisos(1);
            }
            else
            {
                permisos = grupoBL.ListarPermisos(grupo.ID);
            }
            
            foreach (var permiso in permisos)
            {
                var checkb = new CheckBox();
                checkb.Name = permiso.ID.ToString();
                checkb.Text = permiso.ObtenerNombre();
                
                checkb.Width = 260;
                if (accion == Accion.Alta)
                {
                    checkb.Checked = false;
                }
                else
                {
                    checkb.Checked = permiso.TienePermiso;
                }
                flpPermisos.Controls.Add(checkb);
            }
            if (accion != Accion.Alta)
            {
                txtCodigo.Text = grupo.Codigo;
                txtDescripcion.Text = grupo.Descripcion;
            }

        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            grupo.Codigo = txtCodigo.Text;
            grupo.Descripcion = txtDescripcion.Text;
            grupo.Estado = true;
            grupoBL.Insertar(grupo);
            this.Close();
        }
    }
}
