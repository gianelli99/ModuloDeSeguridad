namespace ModuloDeSeguridad.Vista
{
    partial class frmInicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.flpVistas = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.tmTiempoSesion = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // flpVistas
            // 
            this.flpVistas.Dock = System.Windows.Forms.DockStyle.Left;
            this.flpVistas.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpVistas.Location = new System.Drawing.Point(0, 0);
            this.flpVistas.Name = "flpVistas";
            this.flpVistas.Size = new System.Drawing.Size(166, 450);
            this.flpVistas.TabIndex = 3;
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Location = new System.Drawing.Point(678, 401);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(89, 23);
            this.btnCerrarSesion.TabIndex = 4;
            this.btnCerrarSesion.Text = "Cerrar Sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.BtnCerrarSesion_Click);
            // 
            // tmTiempoSesion
            // 
            this.tmTiempoSesion.Tick += new System.EventHandler(this.TmTiempoSesion_Tick);
            // 
            // frmInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 450);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.flpVistas);
            this.Name = "frmInicio";
            this.Text = "Inicio";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpVistas;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Timer tmTiempoSesion;
    }
}

