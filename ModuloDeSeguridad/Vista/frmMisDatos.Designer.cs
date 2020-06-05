namespace ModuloDeSeguridad.Vista
{
    partial class frmMisDatos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flpAcciones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.flpGrupos = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // flpAcciones
            // 
            this.flpAcciones.Location = new System.Drawing.Point(12, 183);
            this.flpAcciones.Name = "flpAcciones";
            this.flpAcciones.Size = new System.Drawing.Size(419, 70);
            this.flpAcciones.TabIndex = 0;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(462, 230);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(12, 90);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(177, 20);
            this.txtApellido.TabIndex = 20;
            this.txtApellido.Text = "Apellido";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(12, 64);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(177, 20);
            this.txtNombre.TabIndex = 19;
            this.txtNombre.Text = "Nombre";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(12, 38);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(177, 20);
            this.txtEmail.TabIndex = 18;
            this.txtEmail.Text = "Email";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(12, 12);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(177, 20);
            this.txtUsername.TabIndex = 16;
            this.txtUsername.Text = "Username";
            // 
            // flpGrupos
            // 
            this.flpGrupos.Location = new System.Drawing.Point(195, 55);
            this.flpGrupos.Name = "flpGrupos";
            this.flpGrupos.Size = new System.Drawing.Size(200, 122);
            this.flpGrupos.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(195, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Grupos";
            // 
            // frmMisDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 265);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flpGrupos);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.flpAcciones);
            this.Name = "frmMisDatos";
            this.Text = "frmMisDatos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpAcciones;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.FlowLayoutPanel flpGrupos;
        private System.Windows.Forms.Label label1;
    }
}