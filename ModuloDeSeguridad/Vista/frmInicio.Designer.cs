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
            this.flpVistas = new System.Windows.Forms.FlowLayoutPanel();
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
            // frmInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 450);
            this.Controls.Add(this.flpVistas);
            this.Name = "frmInicio";
            this.Text = "Inicio";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpVistas;
    }
}

