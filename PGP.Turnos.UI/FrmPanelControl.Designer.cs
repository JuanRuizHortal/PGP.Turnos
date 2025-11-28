namespace PGP.Turnos.UI
{
    partial class FrmPanelControl
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
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
        ///  Método necesario para admitir el Diseñador. No se puede modificar
        ///  el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            grpSeleccion = new GroupBox();
            cmbMes = new ComboBox();
            lblMes = new Label();
            cmbUnidad = new ComboBox();
            lblSelUnidad = new Label();
            cmbArea = new ComboBox();
            lblSelArea = new Label();
            grpCarteleras = new GroupBox();
            btnCartelerasPorTurno = new Button();
            btnCartelerasAlfabetico = new Button();
            grpImpresion = new GroupBox();
            btnImprimirCarteleraPorTurno = new Button();
            btnImprimirCarteleraAlfabetico = new Button();
            grpOtros = new GroupBox();
            btnPresenciasSemanales = new Button();
            btnSustituciones = new Button();
            btnProlongarTurno = new Button();
            btnAñadirTurnos = new Button();
            btnSalir = new Button();
            grpSeleccion.SuspendLayout();
            grpCarteleras.SuspendLayout();
            grpImpresion.SuspendLayout();
            grpOtros.SuspendLayout();
            SuspendLayout();
            // 
            // grpSeleccion
            // 
            grpSeleccion.Controls.Add(cmbMes);
            grpSeleccion.Controls.Add(lblMes);
            grpSeleccion.Controls.Add(cmbUnidad);
            grpSeleccion.Controls.Add(lblSelUnidad);
            grpSeleccion.Controls.Add(cmbArea);
            grpSeleccion.Controls.Add(lblSelArea);
            grpSeleccion.Location = new Point(12, 12);
            grpSeleccion.Name = "grpSeleccion";
            grpSeleccion.Size = new Size(760, 80);
            grpSeleccion.TabIndex = 0;
            grpSeleccion.TabStop = false;
            grpSeleccion.Text = "Selección";
            // 
            // cmbMes
            // 
            cmbMes.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMes.FormattingEnabled = true;
            cmbMes.Location = new Point(540, 34);
            cmbMes.Name = "cmbMes";
            cmbMes.Size = new Size(200, 23);
            cmbMes.TabIndex = 5;
            // 
            // lblMes
            // 
            lblMes.AutoSize = true;
            lblMes.Location = new Point(500, 37);
            lblMes.Name = "lblMes";
            lblMes.Size = new Size(32, 15);
            lblMes.TabIndex = 4;
            lblMes.Text = "Mes:";
            // 
            // cmbUnidad
            // 
            cmbUnidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUnidad.FormattingEnabled = true;
            cmbUnidad.Location = new Point(280, 34);
            cmbUnidad.Name = "cmbUnidad";
            cmbUnidad.Size = new Size(200, 23);
            cmbUnidad.TabIndex = 3;
            // 
            // lblSelUnidad
            // 
            lblSelUnidad.AutoSize = true;
            lblSelUnidad.Location = new Point(230, 37);
            lblSelUnidad.Name = "lblSelUnidad";
            lblSelUnidad.Size = new Size(48, 15);
            lblSelUnidad.TabIndex = 2;
            lblSelUnidad.Text = "Unidad:";
            // 
            // cmbArea
            // 
            cmbArea.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbArea.FormattingEnabled = true;
            cmbArea.Location = new Point(60, 34);
            cmbArea.Name = "cmbArea";
            cmbArea.Size = new Size(150, 23);
            cmbArea.TabIndex = 1;
            // 
            // lblSelArea
            // 
            lblSelArea.AutoSize = true;
            lblSelArea.Location = new Point(10, 37);
            lblSelArea.Name = "lblSelArea";
            lblSelArea.Size = new Size(34, 15);
            lblSelArea.TabIndex = 0;
            lblSelArea.Text = "Área:";
            // 
            // grpCarteleras
            // 
            grpCarteleras.Controls.Add(btnCartelerasPorTurno);
            grpCarteleras.Controls.Add(btnCartelerasAlfabetico);
            grpCarteleras.Location = new Point(12, 98);
            grpCarteleras.Name = "grpCarteleras";
            grpCarteleras.Size = new Size(370, 80);
            grpCarteleras.TabIndex = 1;
            grpCarteleras.TabStop = false;
            grpCarteleras.Text = "Carteleras";
            // 
            // btnCartelerasPorTurno
            // 
            btnCartelerasPorTurno.Location = new Point(190, 30);
            btnCartelerasPorTurno.Name = "btnCartelerasPorTurno";
            btnCartelerasPorTurno.Size = new Size(160, 30);
            btnCartelerasPorTurno.TabIndex = 1;
            btnCartelerasPorTurno.Text = "Editar por orden de turno";
            btnCartelerasPorTurno.UseVisualStyleBackColor = true;
            btnCartelerasPorTurno.Click += btnCartelerasPorTurno_Click;
            // 
            // btnCartelerasAlfabetico
            // 
            btnCartelerasAlfabetico.Location = new Point(10, 30);
            btnCartelerasAlfabetico.Name = "btnCartelerasAlfabetico";
            btnCartelerasAlfabetico.Size = new Size(170, 30);
            btnCartelerasAlfabetico.TabIndex = 0;
            btnCartelerasAlfabetico.Text = "Editar por orden alfabético";
            btnCartelerasAlfabetico.UseVisualStyleBackColor = true;
            btnCartelerasAlfabetico.Click += btnCartelerasAlfabetico_Click;
            // 
            // grpImpresion
            // 
            grpImpresion.Controls.Add(btnImprimirCarteleraPorTurno);
            grpImpresion.Controls.Add(btnImprimirCarteleraAlfabetico);
            grpImpresion.Location = new Point(402, 98);
            grpImpresion.Name = "grpImpresion";
            grpImpresion.Size = new Size(370, 80);
            grpImpresion.TabIndex = 2;
            grpImpresion.TabStop = false;
            grpImpresion.Text = "Impresión de carteleras";
            // 
            // btnImprimirCarteleraPorTurno
            // 
            btnImprimirCarteleraPorTurno.Location = new Point(190, 30);
            btnImprimirCarteleraPorTurno.Name = "btnImprimirCarteleraPorTurno";
            btnImprimirCarteleraPorTurno.Size = new Size(160, 30);
            btnImprimirCarteleraPorTurno.TabIndex = 1;
            btnImprimirCarteleraPorTurno.Text = "Imprimir por turno";
            btnImprimirCarteleraPorTurno.UseVisualStyleBackColor = true;
            btnImprimirCarteleraPorTurno.Click += btnImprimirCarteleraPorTurno_Click;
            // 
            // btnImprimirCarteleraAlfabetico
            // 
            btnImprimirCarteleraAlfabetico.Location = new Point(10, 30);
            btnImprimirCarteleraAlfabetico.Name = "btnImprimirCarteleraAlfabetico";
            btnImprimirCarteleraAlfabetico.Size = new Size(170, 30);
            btnImprimirCarteleraAlfabetico.TabIndex = 0;
            btnImprimirCarteleraAlfabetico.Text = "Imprimir alfabéticamente";
            btnImprimirCarteleraAlfabetico.UseVisualStyleBackColor = true;
            btnImprimirCarteleraAlfabetico.Click += btnImprimirCarteleraAlfabetico_Click;
            // 
            // grpOtros
            // 
            grpOtros.Controls.Add(btnPresenciasSemanales);
            grpOtros.Controls.Add(btnSustituciones);
            grpOtros.Controls.Add(btnProlongarTurno);
            grpOtros.Controls.Add(btnAñadirTurnos);
            grpOtros.Location = new Point(12, 184);
            grpOtros.Name = "grpOtros";
            grpOtros.Size = new Size(760, 90);
            grpOtros.TabIndex = 3;
            grpOtros.TabStop = false;
            grpOtros.Text = "Otras operaciones";
            // 
            // btnPresenciasSemanales
            // 
            btnPresenciasSemanales.Location = new Point(570, 34);
            btnPresenciasSemanales.Name = "btnPresenciasSemanales";
            btnPresenciasSemanales.Size = new Size(170, 30);
            btnPresenciasSemanales.TabIndex = 3;
            btnPresenciasSemanales.Text = "Presencias semanales";
            btnPresenciasSemanales.UseVisualStyleBackColor = true;
            btnPresenciasSemanales.Click += btnPresenciasSemanales_Click;
            // 
            // btnSustituciones
            // 
            btnSustituciones.Location = new Point(390, 34);
            btnSustituciones.Name = "btnSustituciones";
            btnSustituciones.Size = new Size(170, 30);
            btnSustituciones.TabIndex = 2;
            btnSustituciones.Text = "Sustituciones";
            btnSustituciones.UseVisualStyleBackColor = true;
            btnSustituciones.Click += btnSustituciones_Click;
            // 
            // btnProlongarTurno
            // 
            btnProlongarTurno.Location = new Point(200, 34);
            btnProlongarTurno.Name = "btnProlongarTurno";
            btnProlongarTurno.Size = new Size(180, 30);
            btnProlongarTurno.TabIndex = 1;
            btnProlongarTurno.Text = "Prolongar turno / ver prog.";
            btnProlongarTurno.UseVisualStyleBackColor = true;
            btnProlongarTurno.Click += btnProlongarTurno_Click;
            // 
            // btnAñadirTurnos
            // 
            btnAñadirTurnos.Location = new Point(10, 34);
            btnAñadirTurnos.Name = "btnAñadirTurnos";
            btnAñadirTurnos.Size = new Size(180, 30);
            btnAñadirTurnos.TabIndex = 0;
            btnAñadirTurnos.Text = "Añadir y modificar turnos";
            btnAñadirTurnos.UseVisualStyleBackColor = true;
            btnAñadirTurnos.Click += btnAñadirTurnos_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(697, 288);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 30);
            btnSalir.TabIndex = 4;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // FrmPanelControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1008, 729);
            Controls.Add(btnSalir);
            Controls.Add(grpOtros);
            Controls.Add(grpImpresion);
            Controls.Add(grpCarteleras);
            Controls.Add(grpSeleccion);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmPanelControl";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Programa de turnos Panel de Control";
            Load += FrmPanelControl_Load;
            grpSeleccion.ResumeLayout(false);
            grpSeleccion.PerformLayout();
            grpCarteleras.ResumeLayout(false);
            grpImpresion.ResumeLayout(false);
            grpOtros.ResumeLayout(false);
            ResumeLayout(false);


        }

        #endregion

        private System.Windows.Forms.GroupBox grpSeleccion;
        private System.Windows.Forms.ComboBox cmbMes;
        private System.Windows.Forms.Label lblMes;
        private System.Windows.Forms.ComboBox cmbUnidad;
        private System.Windows.Forms.Label lblSelUnidad;
        private System.Windows.Forms.ComboBox cmbArea;
        private System.Windows.Forms.Label lblSelArea;
        private System.Windows.Forms.GroupBox grpCarteleras;
        private System.Windows.Forms.Button btnCartelerasPorTurno;
        private System.Windows.Forms.Button btnCartelerasAlfabetico;
        private System.Windows.Forms.GroupBox grpImpresion;
        private System.Windows.Forms.Button btnImprimirCarteleraPorTurno;
        private System.Windows.Forms.Button btnImprimirCarteleraAlfabetico;
        private System.Windows.Forms.GroupBox grpOtros;
        private System.Windows.Forms.Button btnPresenciasSemanales;
        private System.Windows.Forms.Button btnSustituciones;
        private System.Windows.Forms.Button btnProlongarTurno;
        private System.Windows.Forms.Button btnAñadirTurnos;
        private System.Windows.Forms.Button btnSalir;
    }
}

