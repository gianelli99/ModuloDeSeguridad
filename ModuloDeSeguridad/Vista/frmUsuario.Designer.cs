namespace ModuloDeSeguridad.Vista
{
    partial class frmUsuario
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
            this.pnDatos = new System.Windows.Forms.Panel();
            this.txtConfirmarContrasena = new System.Windows.Forms.TextBox();
            this.flpGrupos = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.pnDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnDatos
            // 
            this.pnDatos.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnDatos.Controls.Add(this.txtConfirmarContrasena);
            this.pnDatos.Controls.Add(this.flpGrupos);
            this.pnDatos.Controls.Add(this.label4);
            this.pnDatos.Controls.Add(this.txtApellido);
            this.pnDatos.Controls.Add(this.txtNombre);
            this.pnDatos.Controls.Add(this.txtEmail);
            this.pnDatos.Controls.Add(this.btnCancelar);
            this.pnDatos.Controls.Add(this.txtContrasena);
            this.pnDatos.Controls.Add(this.txtUsername);
            this.pnDatos.Controls.Add(this.btnAceptar);
            this.pnDatos.Location = new System.Drawing.Point(181, 9);
            this.pnDatos.Margin = new System.Windows.Forms.Padding(0);
            this.pnDatos.Name = "pnDatos";
            this.pnDatos.Size = new System.Drawing.Size(213, 512);
            this.pnDatos.TabIndex = 12;
            // 
            // txtConfirmarContrasena
            // 
            this.txtConfirmarContrasena.Location = new System.Drawing.Point(15, 148);
            this.txtConfirmarContrasena.Name = "txtConfirmarContrasena";
            this.txtConfirmarContrasena.Size = new System.Drawing.Size(177, 20);
            this.txtConfirmarContrasena.TabIndex = 15;
            this.txtConfirmarContrasena.Text = "Repetir Contraseña";
            // 
            // flpGrupos
            // 
            this.flpGrupos.AutoScroll = true;
            this.flpGrupos.Location = new System.Drawing.Point(15, 200);
            this.flpGrupos.Name = "flpGrupos";
            this.flpGrupos.Size = new System.Drawing.Size(180, 272);
            this.flpGrupos.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Grupos";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(15, 96);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(177, 20);
            this.txtApellido.TabIndex = 12;
            this.txtApellido.Text = "Apellido";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(15, 70);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(177, 20);
            this.txtNombre.TabIndex = 11;
            this.txtNombre.Text = "Nombre";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(15, 44);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(177, 20);
            this.txtEmail.TabIndex = 10;
            this.txtEmail.Text = "Email";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(106, 478);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // txtContrasena
            // 
            this.txtContrasena.Location = new System.Drawing.Point(15, 122);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.Size = new System.Drawing.Size(177, 20);
            this.txtContrasena.TabIndex = 3;
            this.txtContrasena.Text = "Contraseña";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(15, 18);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(177, 20);
            this.txtUsername.TabIndex = 1;
            this.txtUsername.Text = "Username";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(25, 478);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 8;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // frmUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 548);
            this.Controls.Add(this.pnDatos);
            this.Name = "frmUsuario";
            this.Text = "frmUsuario";
            this.pnDatos.ResumeLayout(false);
            this.pnDatos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnDatos;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.FlowLayoutPanel flpGrupos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtConfirmarContrasena;
    }
}