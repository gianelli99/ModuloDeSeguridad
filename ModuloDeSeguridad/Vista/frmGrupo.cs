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
        private Logica.GrupoBL grupoBL;
        public frmGrupo()
        {
            InitializeComponent();
            grupoBL = new Logica.GrupoBL();
            var permisos = grupoBL.ListarPermisos(1);
            foreach (var permiso in permisos)
            {
                var checkb = new Button();
                checkb.Name = permiso.ID.ToString();
                checkb.Text = permiso.Vista.Descripcion + @"/" + permiso.Accion.Descripcion;
                checkb.Width = 200;
                flpPermisos.Controls.Add(checkb);
            }
        }
    }
}
