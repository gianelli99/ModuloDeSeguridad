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
    public partial class frmInicio : Form, Logica.Interfaces.ISesionObserver
    {
        private Modelo.Sesion sesion;
        private Logica.SesionBL sesionBL;
        public frmInicio(Modelo.Sesion miSesion)
        {
            InitializeComponent();
            tmTiempoSesion.Interval= 7200000;
            tmTiempoSesion.Start();
            sesion = miSesion;
            sesionBL = Logica.SesionBL.ObtenerInstancia();
            sesionBL.Suscribir(this);
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

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        public void Actualizar()
        {
            sesionBL.Desuscribir(this);
            this.Dispose();
        }

        private void TmTiempoSesion_Tick(object sender, EventArgs e)
        {
            tmTiempoSesion.Dispose();
            sesionBL.FinalizarSesion();
        }
    }
}
