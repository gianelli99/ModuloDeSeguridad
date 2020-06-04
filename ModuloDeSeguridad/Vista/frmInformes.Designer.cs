namespace ModuloDeSeguridad.Vista
{
    partial class frmInformes
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
            this.dgvInforme = new System.Windows.Forms.DataGridView();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.rdbTiempoInicio = new System.Windows.Forms.RadioButton();
            this.rdbTiempoCierre = new System.Windows.Forms.RadioButton();
            this.rdbTiempoSesion = new System.Windows.Forms.RadioButton();
            this.btnUsuario = new System.Windows.Forms.RadioButton();
            this.rdbGrupo = new System.Windows.Forms.RadioButton();
            this.gbTipo = new System.Windows.Forms.GroupBox();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.gbFiltros = new System.Windows.Forms.GroupBox();
            this.flpAcciones = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInforme)).BeginInit();
            this.gbTipo.SuspendLayout();
            this.gbFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvInforme
            // 
            this.dgvInforme.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInforme.Location = new System.Drawing.Point(12, 183);
            this.dgvInforme.Name = "dgvInforme";
            this.dgvInforme.Size = new System.Drawing.Size(519, 201);
            this.dgvInforme.TabIndex = 0;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(461, 463);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(70, 23);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // rdbTiempoInicio
            // 
            this.rdbTiempoInicio.AutoSize = true;
            this.rdbTiempoInicio.Location = new System.Drawing.Point(7, 19);
            this.rdbTiempoInicio.Name = "rdbTiempoInicio";
            this.rdbTiempoInicio.Size = new System.Drawing.Size(88, 17);
            this.rdbTiempoInicio.TabIndex = 3;
            this.rdbTiempoInicio.TabStop = true;
            this.rdbTiempoInicio.Text = "Tiempo Inicio";
            this.rdbTiempoInicio.UseVisualStyleBackColor = true;
            // 
            // rdbTiempoCierre
            // 
            this.rdbTiempoCierre.AutoSize = true;
            this.rdbTiempoCierre.Location = new System.Drawing.Point(98, 19);
            this.rdbTiempoCierre.Name = "rdbTiempoCierre";
            this.rdbTiempoCierre.Size = new System.Drawing.Size(90, 17);
            this.rdbTiempoCierre.TabIndex = 4;
            this.rdbTiempoCierre.TabStop = true;
            this.rdbTiempoCierre.Text = "Tiempo Cierre";
            this.rdbTiempoCierre.UseVisualStyleBackColor = true;
            // 
            // rdbTiempoSesion
            // 
            this.rdbTiempoSesion.AutoSize = true;
            this.rdbTiempoSesion.Location = new System.Drawing.Point(189, 19);
            this.rdbTiempoSesion.Name = "rdbTiempoSesion";
            this.rdbTiempoSesion.Size = new System.Drawing.Size(110, 17);
            this.rdbTiempoSesion.TabIndex = 5;
            this.rdbTiempoSesion.TabStop = true;
            this.rdbTiempoSesion.Text = "Tiempo de Sesión";
            this.rdbTiempoSesion.UseVisualStyleBackColor = true;
            // 
            // btnUsuario
            // 
            this.btnUsuario.AutoSize = true;
            this.btnUsuario.Location = new System.Drawing.Point(15, 24);
            this.btnUsuario.Name = "btnUsuario";
            this.btnUsuario.Size = new System.Drawing.Size(61, 17);
            this.btnUsuario.TabIndex = 6;
            this.btnUsuario.TabStop = true;
            this.btnUsuario.Text = "Usuario";
            this.btnUsuario.UseVisualStyleBackColor = true;
            // 
            // rdbGrupo
            // 
            this.rdbGrupo.AutoSize = true;
            this.rdbGrupo.Location = new System.Drawing.Point(106, 24);
            this.rdbGrupo.Name = "rdbGrupo";
            this.rdbGrupo.Size = new System.Drawing.Size(54, 17);
            this.rdbGrupo.TabIndex = 7;
            this.rdbGrupo.TabStop = true;
            this.rdbGrupo.Text = "Grupo";
            this.rdbGrupo.UseVisualStyleBackColor = true;
            // 
            // gbTipo
            // 
            this.gbTipo.Controls.Add(this.rdbTiempoSesion);
            this.gbTipo.Controls.Add(this.dtpFechaFin);
            this.gbTipo.Controls.Add(this.rdbTiempoInicio);
            this.gbTipo.Controls.Add(this.rdbTiempoCierre);
            this.gbTipo.Controls.Add(this.dtpFechaInicio);
            this.gbTipo.Location = new System.Drawing.Point(12, 101);
            this.gbTipo.Name = "gbTipo";
            this.gbTipo.Size = new System.Drawing.Size(406, 76);
            this.gbTipo.TabIndex = 8;
            this.gbTipo.TabStop = false;
            this.gbTipo.Text = "Tipo de Informe";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Location = new System.Drawing.Point(209, 42);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(181, 20);
            this.dtpFechaFin.TabIndex = 10;
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Location = new System.Drawing.Point(10, 42);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(178, 20);
            this.dtpFechaInicio.TabIndex = 9;
            // 
            // cmbTipo
            // 
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(7, 47);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(168, 21);
            this.cmbTipo.TabIndex = 8;
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.cmbTipo);
            this.gbFiltros.Controls.Add(this.btnUsuario);
            this.gbFiltros.Controls.Add(this.rdbGrupo);
            this.gbFiltros.Location = new System.Drawing.Point(12, 12);
            this.gbFiltros.Name = "gbFiltros";
            this.gbFiltros.Size = new System.Drawing.Size(185, 83);
            this.gbFiltros.TabIndex = 11;
            this.gbFiltros.TabStop = false;
            this.gbFiltros.Text = "Filtros";
            // 
            // flpAcciones
            // 
            this.flpAcciones.Location = new System.Drawing.Point(12, 390);
            this.flpAcciones.Name = "flpAcciones";
            this.flpAcciones.Size = new System.Drawing.Size(519, 65);
            this.flpAcciones.TabIndex = 12;
            // 
            // frmInformes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 500);
            this.Controls.Add(this.flpAcciones);
            this.Controls.Add(this.gbFiltros);
            this.Controls.Add(this.gbTipo);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.dgvInforme);
            this.Name = "frmInformes";
            this.Text = "frmInformes";
            ((System.ComponentModel.ISupportInitialize)(this.dgvInforme)).EndInit();
            this.gbTipo.ResumeLayout(false);
            this.gbTipo.PerformLayout();
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInforme;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.RadioButton rdbTiempoInicio;
        private System.Windows.Forms.RadioButton rdbTiempoCierre;
        private System.Windows.Forms.RadioButton rdbTiempoSesion;
        private System.Windows.Forms.RadioButton btnUsuario;
        private System.Windows.Forms.RadioButton rdbGrupo;
        private System.Windows.Forms.GroupBox gbTipo;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.GroupBox gbFiltros;
        private System.Windows.Forms.FlowLayoutPanel flpAcciones;
    }
}