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
    public partial class frmInicio : Form
    {
        private Modelo.Sesion sesion;
        private Logica.SesionBL sesionBL;
        public frmInicio(Modelo.Sesion miSesion)
        {
            InitializeComponent();
            sesion = miSesion;
            sesionBL = new Logica.SesionBL();
            List<Modelo.Vista> vistasDisponibles = sesionBL.ListarVistasDisponibles(sesion.Usuario.ID);
            if (vistasDisponibles != null)
            {
                foreach (var vista in vistasDisponibles)
                {
                    var button = new Button();
                    button.Name = vista.ID.ToString();
                    button.Text = vista.Descripcion;
                    button.AutoSize = true;
                    button.Click += VistaClick;
                    flpVistas.Controls.Add(button);
                }
            }
        }

        private void VistaClick(object sender, EventArgs e)
        {
            try
            {
                switch (((Button)sender).Text)
                {
                    default:
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error");
                return;
            }
        }
    }
}
