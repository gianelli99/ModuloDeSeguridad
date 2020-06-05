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
    public partial class frmGrupo : Form, Logica.Interfaces.ISesionObserver
    {
        private Accion accion;
        private Logica.GrupoBL grupoBL;
        private Modelo.Grupo grupo;
        private List<Modelo.Permiso> permisos;
        List<CheckBox> checkBoxes;

        public frmGrupo()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            FrmGrupo_Resize(this, EventArgs.Empty);
            Logica.SesionBL.ObtenerInstancia().Suscribir(this);
            accion = Accion.Alta;
            grupo = new Modelo.Grupo();
            grupoBL = new Logica.GrupoBL();
            permisos = grupoBL.ListarPermisos();
            foreach (var cb in ListarCheckBoxesPermisos(permisos))
            {
                flpPermisos.Controls.Add(cb);
            }
        }
        public frmGrupo(Accion miAccion, int id)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            FrmGrupo_Resize(this, EventArgs.Empty);
            Logica.SesionBL.ObtenerInstancia().Suscribir(this);
            grupoBL = new Logica.GrupoBL();
            accion = miAccion;
            grupo = grupoBL.Consultar(id);
            permisos = grupoBL.ListarPermisos(grupo.ID);
            foreach (var cb in ListarCheckBoxesPermisos(permisos))
            {
                flpPermisos.Controls.Add(cb);
            }
            txtCodigo.Text = grupo.Codigo;
            txtDescripcion.Text = grupo.Descripcion;
           
            if (accion == Accion.Consulta)
            {
                btnAceptar.Enabled = false;
            }
        }
        private List<CheckBox> ListarCheckBoxesPermisos(List<Modelo.Permiso> permisos)
        {
            checkBoxes = new List<CheckBox>();
            foreach (var permiso in permisos)
            {
                var checkb = new CheckBox();
                if (!(accion == Accion.Alta))
                {
                    checkb.Name = permiso.ID.ToString();
                }
                else// es alta
                {
                    checkb.Name = permiso.ObtenerNombre();
                }
                checkb.Text = permiso.ObtenerNombre();
                checkb.Width = 180;
                checkb.Checked = permiso.TienePermiso;
                checkBoxes.Add(checkb);
            }
            checkBoxes = checkBoxes.OrderBy(x => x.Text).ToList();
            return checkBoxes;
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtCodigo.Text) ||
                String.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Debe completar todos los campos");
                return;
            }

            foreach (var cb in checkBoxes)
            {
                if (checkBoxes.Count>0)
                {
                    Modelo.Permiso permiso;
                    if (accion == Accion.Alta)
                    {
                        permiso = permisos.Find(x => x.ObtenerNombre() == cb.Name);
                    }
                    else
                    {
                        permiso = permisos.Find(x => x.ID.ToString() == cb.Name);
                    }
                    permiso.TienePermiso = cb.Checked ? true : false;
                }
            }
            grupo.Codigo = txtCodigo.Text;
            grupo.Descripcion = txtDescripcion.Text;
            grupo.Estado = true;

            try
            {
                if (accion == Accion.Alta)
                {
                    grupoBL.Insertar(grupo, permisos);
                }
                else
                {
                    grupoBL.Modificar(grupo, permisos);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            Logica.SesionBL.ObtenerInstancia().Desuscribir(this);
            this.DialogResult = DialogResult.OK;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Actualizar(false);
        }

        private void FrmGrupo_Resize(object sender, EventArgs e)
        {
            pnDatos.Location =new Point( (this.ClientRectangle.Size.Width-pnDatos.Size.Width) / 2,(this.ClientRectangle.Size.Height - pnDatos.Size.Height)/2);
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
    }
}
