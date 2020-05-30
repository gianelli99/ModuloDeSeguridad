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
    public partial class frmUsuario : Form
    {
        private Accion accion;
        private Logica.UsuarioBL usuarioBL;
        private Modelo.Usuario user;
        private List<Modelo.Grupo> gruposAll;
        private List<CheckBox> checkBoxes;
        public frmUsuario()
        {
            InitializeComponent();
            accion = Accion.Alta;
            user = new Modelo.Usuario();
            usuarioBL = new Logica.UsuarioBL();
            gruposAll = usuarioBL.ListarGrupos();
            foreach (var cbGrupo in ListarCheckBoxesGrupos(gruposAll))
            {
                flpGrupos.Controls.Add(cbGrupo);
            }
        }
        public frmUsuario(Accion miAccion, int id)
        {
            InitializeComponent();
            usuarioBL = new Logica.UsuarioBL();
            accion = miAccion;
            user = usuarioBL.Consultar(id);
            txtUsername.Text = user.Username;
            txtContrasena.UseSystemPasswordChar = true;
            txtConfirmarContrasena.UseSystemPasswordChar = true;
            txtContrasena.Text = user.Password;
            txtConfirmarContrasena.Text = user.Password;
            txtContrasena.Enabled = false;
            txtConfirmarContrasena.Enabled = false;
            txtEmail.Text = user.Email;
            txtNombre.Text = user.Nombre;
            txtApellido.Text = user.Apellido;
            rdbActivo.Checked = user.Estado ? true : false;
            gruposAll = usuarioBL.ListarGrupos();
            foreach (var cbGrupo in ListarCheckBoxesGrupos(gruposAll))
            {
                flpGrupos.Controls.Add(cbGrupo);
            }
            btnAceptar.Enabled = Accion.Consulta == accion ? false : true;
        }
        private List<CheckBox> ListarCheckBoxesGrupos(List<Modelo.Grupo> grupos)
        {
            checkBoxes = new List<CheckBox>();
            foreach (var grupo in grupos)
            {
                var checkb = new CheckBox();
                checkb.Name = grupo.ID.ToString();
                checkb.Text = grupo.Descripcion;
                if (accion != Accion.Alta)
                {
                    checkb.Checked = user.Grupos.Find(x => x.ID == grupo.ID) != null ? true : false;
                }
                else
                {
                    checkb.Checked = false;
                }
                checkb.Width = 140;
                checkBoxes.Add(checkb);
            }
            return checkBoxes;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtUsername.Text)   ||
                String.IsNullOrWhiteSpace(txtContrasena.Text) ||
                String.IsNullOrWhiteSpace(txtEmail.Text) ||
                String.IsNullOrWhiteSpace(txtNombre.Text) ||
                String.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("Debe completar todos los campos");
                return;
            }
            if (txtContrasena.Text != txtConfirmarContrasena.Text)
            {
                MessageBox.Show("Las contraseñas deben ser iguales");
                return;
            }
            user.Grupos = new List<Modelo.Grupo>();
            foreach (var cb in checkBoxes)
            {
                if (cb.Checked)
                {
                    user.Grupos.Add(gruposAll.Find(x => x.ID.ToString() == cb.Name));
                }
            }
            user.Username = txtUsername.Text;
            user.Password = txtContrasena.Text;
            user.Email = txtEmail.Text;
            user.Nombre = txtNombre.Text;
            user.Apellido = txtApellido.Text;
            user.Estado = rdbActivo.Checked ? true : false;
            try
            {
                if (accion == Accion.Alta)
                {
                    usuarioBL.Insertar(user);
                }
                else
                {
                    usuarioBL.Modificar(user);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}
