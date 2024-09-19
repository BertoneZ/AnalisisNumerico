namespace Analisis_Numerico.Unidad_2
{
    partial class SistemaDeEcuaciones
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
            panel1 = new Panel();
            label1 = new Label();
            IteracionesLabel = new Label();
            ToleranciaLabel = new Label();
            textBoxIteraciones = new TextBox();
            texboxTolerancia = new TextBox();
            metodoLabel = new Label();
            comboBoxMethod = new ComboBox();
            BotonSalir = new Button();
            botonCalcular = new Button();
            botonGenerar = new Button();
            panel2 = new Panel();
            textBoxRows = new TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(IteracionesLabel);
            panel1.Controls.Add(ToleranciaLabel);
            panel1.Controls.Add(textBoxIteraciones);
            panel1.Controls.Add(texboxTolerancia);
            panel1.Controls.Add(metodoLabel);
            panel1.Controls.Add(comboBoxMethod);
            panel1.Controls.Add(BotonSalir);
            panel1.Controls.Add(botonCalcular);
            panel1.Controls.Add(botonGenerar);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(textBoxRows);
            panel1.Location = new Point(53, 63);
            panel1.Name = "panel1";
            panel1.Size = new Size(1473, 620);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(82, 18);
            label1.Name = "label1";
            label1.Size = new Size(154, 25);
            label1.TabIndex = 13;
            label1.Text = "Ingrese el tamaño";
            // 
            // IteracionesLabel
            // 
            IteracionesLabel.AutoSize = true;
            IteracionesLabel.ForeColor = Color.White;
            IteracionesLabel.Location = new Point(82, 313);
            IteracionesLabel.Name = "IteracionesLabel";
            IteracionesLabel.Size = new Size(97, 25);
            IteracionesLabel.TabIndex = 12;
            IteracionesLabel.Text = "Iteraciones";
            // 
            // ToleranciaLabel
            // 
            ToleranciaLabel.AutoSize = true;
            ToleranciaLabel.ForeColor = Color.White;
            ToleranciaLabel.Location = new Point(82, 227);
            ToleranciaLabel.Name = "ToleranciaLabel";
            ToleranciaLabel.Size = new Size(89, 25);
            ToleranciaLabel.TabIndex = 11;
            ToleranciaLabel.Text = "Tolerancia";
            // 
            // textBoxIteraciones
            // 
            textBoxIteraciones.Location = new Point(82, 341);
            textBoxIteraciones.Name = "textBoxIteraciones";
            textBoxIteraciones.PlaceholderText = "Ingrese las filas";
            textBoxIteraciones.Size = new Size(185, 31);
            textBoxIteraciones.TabIndex = 9;
            textBoxIteraciones.Text = "100";
            // 
            // texboxTolerancia
            // 
            texboxTolerancia.Location = new Point(82, 255);
            texboxTolerancia.Name = "texboxTolerancia";
            texboxTolerancia.PlaceholderText = "Ingrese las filas";
            texboxTolerancia.Size = new Size(185, 31);
            texboxTolerancia.TabIndex = 8;
            texboxTolerancia.Text = "0,0001";
            // 
            // metodoLabel
            // 
            metodoLabel.AutoSize = true;
            metodoLabel.ForeColor = Color.White;
            metodoLabel.Location = new Point(82, 105);
            metodoLabel.Name = "metodoLabel";
            metodoLabel.Size = new Size(188, 25);
            metodoLabel.TabIndex = 7;
            metodoLabel.Text = "Seleccione un metodo";
            // 
            // comboBoxMethod
            // 
            comboBoxMethod.AccessibleRole = AccessibleRole.MenuPopup;
            comboBoxMethod.FormattingEnabled = true;
            comboBoxMethod.Items.AddRange(new object[] { "Gauss-Jordan", "Gauss-Seidel" });
            comboBoxMethod.Location = new Point(82, 133);
            comboBoxMethod.Name = "comboBoxMethod";
            comboBoxMethod.Size = new Size(182, 33);
            comboBoxMethod.TabIndex = 6;
            comboBoxMethod.SelectedIndexChanged += comboBoxMethod_SelectedIndexChanged;
            // 
            // BotonSalir
            // 
            BotonSalir.Location = new Point(322, 420);
            BotonSalir.Name = "BotonSalir";
            BotonSalir.Size = new Size(112, 34);
            BotonSalir.TabIndex = 3;
            BotonSalir.Text = "Salir";
            BotonSalir.UseVisualStyleBackColor = true;
            // 
            // botonCalcular
            // 
            botonCalcular.Location = new Point(82, 420);
            botonCalcular.Name = "botonCalcular";
            botonCalcular.Size = new Size(112, 34);
            botonCalcular.TabIndex = 4;
            botonCalcular.Text = "Calcular";
            botonCalcular.UseVisualStyleBackColor = true;
            botonCalcular.Click += botonCalcular_Click_1;
            // 
            // botonGenerar
            // 
            botonGenerar.Location = new Point(291, 43);
            botonGenerar.Name = "botonGenerar";
            botonGenerar.Size = new Size(143, 34);
            botonGenerar.TabIndex = 5;
            botonGenerar.Text = "Generar Matriz";
            botonGenerar.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Location = new Point(508, 6);
            panel2.Name = "panel2";
            panel2.Size = new Size(938, 491);
            panel2.TabIndex = 0;
            // 
            // textBoxRows
            // 
            textBoxRows.Location = new Point(82, 46);
            textBoxRows.Name = "textBoxRows";
            textBoxRows.PlaceholderText = "Ingrese las filas";
            textBoxRows.Size = new Size(154, 31);
            textBoxRows.TabIndex = 0;
            // 
            // SistemaDeEcuaciones
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1533, 579);
            Controls.Add(panel1);
            Name = "SistemaDeEcuaciones";
            Text = "SistemaDeEcuaciones";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
       
        private TextBox textBoxRows;
        private Button BotonSalir;
        private Button botonGenerar;
        private Button botonCalcular;
        private ComboBox comboBoxMethod;
        private Label metodoLabel;
        private TextBox textBoxIteraciones;
        private TextBox texboxTolerancia;
        private Label ToleranciaLabel;
        private Label IteracionesLabel;
        private TextBox solutionTextBoxes;
        private Label label1;
    }
}