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
    public partial class frmInformes : Form, Logica.Interfaces.ISesionObserver
    {
        private Logica.UsuarioBL usuarioBL;
        public frmInformes(int vistaId)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            usuarioBL = new Logica.UsuarioBL();
            Logica.SesionBL.ObtenerInstancia().Suscribir(this);
            
            var accionesDisponibles = usuarioBL.ListarAccionesDisponibles(Modelo.Sesion.ObtenerInstancia().Usuario.ID, vistaId);
            foreach (var accion in accionesDisponibles)
            {
                var button = new Button();
                button.Name = "btn" + accion.Descripcion;
                button.Text = accion.Descripcion;
                button.AutoSize = true;
                button.Click += BtnAccion;
                flpAcciones.Controls.Add(button);
            }
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

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Actualizar(false);
        }
        private void BtnAccion(object sender, EventArgs e)
        {
            try
            {
                switch (((Button)sender).Text)
                {
                    case "Alta"://aca se hace el informe
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error.");
            }
        }
    }
}
