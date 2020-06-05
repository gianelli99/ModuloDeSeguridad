namespace ModuloDeSeguridad.Vista
{
    partial class frmIniciarSesion
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
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.llblOlvidasteTuContrasena = new System.Windows.Forms.LinkLabel();
            this.btnIniciarSesion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(77, 49);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(100, 20);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.Text = "GianElli99";
            // 
            // txtContrasena
            // 
            this.txtContrasena.Location = new System.Drawing.Point(77, 75);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.Size = new System.Drawing.Size(100, 20);
            this.txtContrasena.TabIndex = 1;
            this.txtContrasena.Text = "abc123";
            this.txtContrasena.UseSystemPasswordChar = true;
            // 
            // llblOlvidasteTuContrasena
            // 
            this.llblOlvidasteTuContrasena.AutoSize = true;
            this.llblOlvidasteTuContrasena.Location = new System.Drawing.Point(62, 151);
            this.llblOlvidasteTuContrasena.Name = "llblOlvidasteTuContrasena";
            this.llblOlvidasteTuContrasena.Size = new System.Drawing.Size(131, 13);
            this.llblOlvidasteTuContrasena.TabIndex = 2;
            this.llblOlvidasteTuContrasena.TabStop = true;
            this.llblOlvidasteTuContrasena.Text = "¿Olvidaste tu contraseña?";
            this.llblOlvidasteTuContrasena.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LlblOlvidasteTuContrasena_LinkClicked);
            // 
            // btnIniciarSesion
            // 
            this.btnIniciarSesion.Location = new System.Drawing.Point(77, 125);
            this.btnIniciarSesion.Name = "btnIniciarSesion";
            this.btnIniciarSesion.Size = new System.Drawing.Size(100, 23);
            this.btnIniciarSesion.TabIndex = 3;
            this.btnIniciarSesion.Text = "Iniciar Sesión";
            this.btnIniciarSesion.UseVisualStyleBackColor = true;
            this.btnIniciarSesion.Click += new System.EventHandler(this.BtnIniciarSesion_Click);
            // 
            // frmIniciarSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 233);
            this.Controls.Add(this.btnIniciarSesion);
            this.Controls.Add(this.llblOlvidasteTuContrasena);
            this.Controls.Add(this.txtContrasena);
            this.Controls.Add(this.txtUsername);
            this.Name = "frmIniciarSesion";
            this.Text = "frmIniciarSesion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.LinkLabel llblOlvidasteTuContrasena;
        private System.Windows.Forms.Button btnIniciarSesion;
    }
}