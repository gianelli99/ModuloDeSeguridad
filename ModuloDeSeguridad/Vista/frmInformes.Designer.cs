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
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnUsuario = new System.Windows.Forms.RadioButton();
            this.rdbGrupo = new System.Windows.Forms.RadioButton();
            this.gbTipo = new System.Windows.Forms.GroupBox();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.gbFiltros = new System.Windows.Forms.GroupBox();
            this.flpAcciones = new System.Windows.Forms.FlowLayoutPanel();
            this.rdbTodos = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gbTipo.SuspendLayout();
            this.gbFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(348, 254);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(70, 23);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
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
            this.btnUsuario.CheckedChanged += new System.EventHandler(this.RdbCheckedChanged);
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
            this.rdbGrupo.CheckedChanged += new System.EventHandler(this.RdbCheckedChanged);
            // 
            // gbTipo
            // 
            this.gbTipo.Controls.Add(this.label2);
            this.gbTipo.Controls.Add(this.label1);
            this.gbTipo.Controls.Add(this.dtpFechaFin);
            this.gbTipo.Controls.Add(this.dtpFechaInicio);
            this.gbTipo.Location = new System.Drawing.Point(12, 101);
            this.gbTipo.Name = "gbTipo";
            this.gbTipo.Size = new System.Drawing.Size(406, 76);
            this.gbTipo.TabIndex = 8;
            this.gbTipo.TabStop = false;
            this.gbTipo.Text = "Fechas";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Location = new System.Drawing.Point(209, 41);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(181, 20);
            this.dtpFechaFin.TabIndex = 10;
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Location = new System.Drawing.Point(7, 41);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(178, 20);
            this.dtpFechaInicio.TabIndex = 9;
            // 
            // cmbTipo
            // 
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(7, 46);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(168, 21);
            this.cmbTipo.TabIndex = 8;
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.rdbTodos);
            this.gbFiltros.Controls.Add(this.cmbTipo);
            this.gbFiltros.Controls.Add(this.btnUsuario);
            this.gbFiltros.Controls.Add(this.rdbGrupo);
            this.gbFiltros.Location = new System.Drawing.Point(12, 12);
            this.gbFiltros.Name = "gbFiltros";
            this.gbFiltros.Size = new System.Drawing.Size(295, 83);
            this.gbFiltros.TabIndex = 11;
            this.gbFiltros.TabStop = false;
            this.gbFiltros.Text = "Filtros";
            // 
            // flpAcciones
            // 
            this.flpAcciones.Location = new System.Drawing.Point(12, 183);
            this.flpAcciones.Name = "flpAcciones";
            this.flpAcciones.Size = new System.Drawing.Size(406, 65);
            this.flpAcciones.TabIndex = 12;
            // 
            // rdbTodos
            // 
            this.rdbTodos.AutoSize = true;
            this.rdbTodos.Location = new System.Drawing.Point(209, 24);
            this.rdbTodos.Name = "rdbTodos";
            this.rdbTodos.Size = new System.Drawing.Size(55, 17);
            this.rdbTodos.TabIndex = 9;
            this.rdbTodos.TabStop = true;
            this.rdbTodos.Text = "Todos";
            this.rdbTodos.UseVisualStyleBackColor = true;
            this.rdbTodos.CheckedChanged += new System.EventHandler(this.RdbCheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Fecha Inicio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(219, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Fecha Fin";
            // 
            // frmInformes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 287);
            this.Controls.Add(this.flpAcciones);
            this.Controls.Add(this.gbFiltros);
            this.Controls.Add(this.gbTipo);
            this.Controls.Add(this.btnCerrar);
            this.Name = "frmInformes";
            this.Text = "frmInformes";
            this.gbTipo.ResumeLayout(false);
            this.gbTipo.PerformLayout();
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.RadioButton btnUsuario;
        private System.Windows.Forms.RadioButton rdbGrupo;
        private System.Windows.Forms.GroupBox gbTipo;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.GroupBox gbFiltros;
        private System.Windows.Forms.FlowLayoutPanel flpAcciones;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdbTodos;
    }
}