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
        private Logica.SesionBL sesionBL;
        private Modelo.Sesion sesion;
        public frmInicio()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            sesion = Modelo.Sesion.ObtenerInstancia();
            sesionBL = Logica.SesionBL.ObtenerInstancia();
            sesionBL.Suscribir(this);
            ListarVistasDisponibles();
        }
        private void ListarVistasDisponibles()
        {
            List<Modelo.Vista> vistasDisponibles = sesionBL.ListarVistasDisponibles(sesion.Usuario.ID);
            if (vistasDisponibles != null)
            {
                flpVistas.Controls.Clear();
                foreach (var vista in vistasDisponibles)
                {
                    var button = new Button();
                    button.Name = vista.ID.ToString();
                    button.Text = vista.Descripcion;
                    button.AutoSize = true;
                    button.Click += VistaClick;

                    button.Padding = new Padding(4);
                    button.ImageAlign = ContentAlignment.TopCenter;
                    button.TextAlign = ContentAlignment.BottomCenter;
                    button.Font = new Font("Lato", 14);
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                    button.BackColor = Color.FromArgb(94, 48, 228);
                    button.Size = new Size(175, 120);
                    button.Image = Image.FromFile(@"..\..\Resources\file-icon.png");

                    flpVistas.Controls.Add(button);
                }
            }
        }

        private void VistaClick(object sender, EventArgs e)
        {
            try
            {
                int vistaId = Convert.ToInt32(((Button)sender).Name);
                switch (((Button)sender).Text)
                {
                    case "Grupos":
                        frmGrupos grupos = new frmGrupos(vistaId);
                        grupos.ShowDialog();
                        // refrescar
                        ListarVistasDisponibles();
                        break;
                    case "Usuarios":
                        frmUsuarios usuarios = new frmUsuarios(vistaId);
                        usuarios.ShowDialog();
                        // refrescar
                        ListarVistasDisponibles();
                        break;
                    case "Informes":
                        frmInformes informes = new frmInformes(vistaId);
                        informes.ShowDialog();
                        break;
                    case "Mis Datos":
                        frmMisDatos datos = new frmMisDatos(vistaId);
                        datos.ShowDialog();
                        break;
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
            sesionBL.FinalizarSesion();
        }

        public void Actualizar(bool isFirst)
        {
            if (isFirst)
            {
                MessageBox.Show("Su sesión se cerrará automaticamente");
            }
            sesionBL.Desuscribir(this);
            this.Dispose();
        }
        private void FrmInicio_FormClosed(object sender, FormClosedEventArgs e)
        {
            sesionBL.FinalizarSesion();
        }
    }
}
