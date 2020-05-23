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
        public frmGrupos(int idUser, int idVista)
        {
            InitializeComponent();
            Datos.IUsuarioDAO daoUsuario = new Datos.UsuarioDAO();
            List<Modelo.Accion> accionesDisponibles = daoUsuario.ListarAccionesDisponibles(idUser,idVista);
            if (accionesDisponibles != null)
            {
                if (accionesDisponibles.FindIndex(x => x.Descripcion == "Alta") != -1)
                {
                    btnAgregar.Enabled = true;
                }
                else
                {
                    btnAgregar.Enabled = false;
                }

                if (accionesDisponibles.FindIndex(x => x.Descripcion == "Baja") != -1)
                {
                    btnEliminar.Enabled = true;
                }
                else
                {
                    btnEliminar.Enabled = false;
                }

                if (accionesDisponibles.FindIndex(x => x.Descripcion == "Modificacion") != -1)
                {
                    btnModificar.Enabled = true;
                }
                else
                {
                    btnModificar.Enabled = false;
                }

                if (accionesDisponibles.FindIndex(x => x.Descripcion == "Consultar") != -1)
                {
                    btnConsultar.Enabled = true;
                }
                else
                {
                    btnConsultar.Enabled = false;
                }
            }
        }
    }
}
