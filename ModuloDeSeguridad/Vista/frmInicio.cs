using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModuloDeSeguridad
{
    public partial class frmInicio : Form
    {
        public frmInicio()
        {
            InitializeComponent();
            Datos.IUsuarioDAO daoUsuario = new Datos.UsuarioDAO_SqlServer();
            List<Modelo.Vista> vistasDisponibles = daoUsuario.ListarVistasDisponibles(1);
            if ((vistasDisponibles.FindAll(x => x.Descripcion == "GestionarGrupos")).Count> 0)
            {
                btnGrupos.Enabled = true;
            }
            else
            {
                btnGrupos.Enabled = false;
            }
        }

        private void BtnGrupos_Click(object sender, EventArgs e)
        {
            // buscar las acciones de este usuario en esta vista
            //var formGrupos = new Vista.frmGrupos(1,2);
            //formGrupos.ShowDialog();
        }
    }
}
