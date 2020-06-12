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
        private Logica.InformeBL informeBL;
        private List<Modelo.Usuario> usuarios;
        private List<Modelo.Grupo> grupos;
        private Logica.TipoInforme tipoInforme;
        public frmInformes(int vistaId)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            usuarioBL = new Logica.UsuarioBL();
            informeBL = new Logica.InformeBL();
            Logica.SesionBL.ObtenerInstancia().Suscribir(this);
            usuarios = informeBL.ListarUsuarios();
            grupos = informeBL.ListarGrupos();
            rdbTodos.Checked = true;
            tipoInforme = Logica.TipoInforme.Todos;
            var accionesDisponibles = usuarioBL.ListarAccionesDisponibles(Modelo.Sesion.ObtenerInstancia().Usuario.ID, vistaId);
            foreach (var accion in accionesDisponibles)
            {
                var button = new Button();
                button.Name = "btn" + accion.Descripcion;
                button.Text = accion.Descripcion;
                button.AutoSize = true;
                button.Click += BtnAccion;


                button.Padding = new Padding(10,0,10,0);
                button.Margin = new Padding(4);
                button.ImageAlign = ContentAlignment.MiddleLeft;
                button.TextAlign = ContentAlignment.MiddleRight;
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.BackColor = Color.FromArgb(94, 48, 228);
                button.Size = new Size(125, 40);
                button.Image = Image.FromFile(@"..\..\Resources\" + accion.IconName);


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
                        if (dtpFechaInicio.Value>dtpFechaFin.Value)
                        {
                            MessageBox.Show("La fecha de inicio no puede ser mayor a la de fin.");
                            return;
                        }
                        switch (tipoInforme)
                        {
                            case Logica.TipoInforme.Todos:
                                informeBL.GenerarInforme(dtpFechaInicio.Value, dtpFechaFin.Value);
                                break;
                            case Logica.TipoInforme.Usuario:

                                informeBL.GenerarInforme(tipoInforme,((Modelo.Usuario)cmbTipo.SelectedItem).ID, dtpFechaInicio.Value, dtpFechaFin.Value);
                                break;
                            case Logica.TipoInforme.Grupo:
                                informeBL.GenerarInforme(tipoInforme, ((Modelo.Grupo)cmbTipo.SelectedItem).ID, dtpFechaInicio.Value, dtpFechaFin.Value);
                                break;
                            default:
                                break;
                        }
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
        private void RdbCheckedChanged(object sender, EventArgs e)
        {
            switch (((RadioButton)sender).Text)
            {
                case "Todos":
                    cmbTipo.DataSource = null;
                    tipoInforme = Logica.TipoInforme.Todos;
                    break;
                case "Usuario":
                    cmbTipo.DataSource = null;
                    cmbTipo.DataSource = usuarios;
                    cmbTipo.DisplayMember = "Username";
                    tipoInforme = Logica.TipoInforme.Usuario;
                    break;
                case "Grupo":
                    cmbTipo.DataSource = null;
                    cmbTipo.DataSource = grupos;
                    cmbTipo.DisplayMember = "Descripcion";
                    tipoInforme = Logica.TipoInforme.Grupo;
                    break;
                default:
                    break;
            }
        }
    }
}
