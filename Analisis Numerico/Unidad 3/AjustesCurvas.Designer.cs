namespace Analisis_Numerico
{
    partial class AjustesCurvas
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
            button2 = new Button();
            panelPuntos = new Panel();
            dataGridView1 = new DataGridView();
            Columnx = new DataGridViewTextBoxColumn();
            Columny = new DataGridViewTextBoxColumn();
            button1 = new Button();
            textBoxGrado = new TextBox();
            labelGrado = new Label();
            buttonCalcular = new Button();
            buttonBorrarUltimo = new Button();
            buttonBorraTodos = new Button();
            buttonSalir = new Button();
            labelMetodo = new Label();
            comboBoxMetodo = new ComboBox();
            textBoxTolerancia = new TextBox();
            label2 = new Label();
            textBoxY = new TextBox();
            textBoxX = new TextBox();
            labelPuntos = new Label();
            panel2 = new Panel();
            webViewCurvas = new Microsoft.Web.WebView2.WinForms.WebView2();
            label4 = new Label();
            label3 = new Label();
            textBoxCoeficiente = new TextBox();
            textBoxEfectividad = new TextBox();
            textBoxFuncion = new TextBox();
            label1 = new Label();
            panel1.SuspendLayout();
            panelPuntos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)webViewCurvas).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(148, 180, 193);
            panel1.CausesValidation = false;
            panel1.Controls.Add(button2);
            panel1.Controls.Add(panelPuntos);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(textBoxGrado);
            panel1.Controls.Add(labelGrado);
            panel1.Controls.Add(buttonCalcular);
            panel1.Controls.Add(buttonBorrarUltimo);
            panel1.Controls.Add(buttonBorraTodos);
            panel1.Controls.Add(buttonSalir);
            panel1.Controls.Add(labelMetodo);
            panel1.Controls.Add(comboBoxMetodo);
            panel1.Controls.Add(textBoxTolerancia);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(textBoxY);
            panel1.Controls.Add(textBoxX);
            panel1.Controls.Add(labelPuntos);
            panel1.Location = new Point(32, 24);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(553, 923);
            panel1.TabIndex = 0;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(66, 137, 155);
            button2.Font = new Font("Franklin Gothic Demi Cond", 10F);
            button2.ForeColor = SystemColors.ButtonHighlight;
            button2.Location = new Point(377, 371);
            button2.Margin = new Padding(4, 3, 4, 3);
            button2.Name = "button2";
            button2.Size = new Size(152, 42);
            button2.TabIndex = 18;
            button2.Text = "Borrar Punto";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // panelPuntos
            // 
            panelPuntos.Controls.Add(dataGridView1);
            panelPuntos.Location = new Point(33, 258);
            panelPuntos.Name = "panelPuntos";
            panelPuntos.Size = new Size(289, 364);
            panelPuntos.TabIndex = 17;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.BackgroundColor = Color.FromArgb(148, 180, 193);
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Columnx, Columny });
            dataGridView1.GridColor = Color.FromArgb(148, 180, 193);
            dataGridView1.Location = new Point(0, -4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(327, 371);
            dataGridView1.TabIndex = 17;
            // 
            // Columnx
            // 
            Columnx.HeaderText = "X";
            Columnx.MinimumWidth = 8;
            Columnx.Name = "Columnx";
            Columnx.Width = 115;
            // 
            // Columny
            // 
            Columny.HeaderText = "Y";
            Columny.MinimumWidth = 8;
            Columny.Name = "Columny";
            Columny.Width = 115;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(66, 137, 155);
            button1.Font = new Font("Franklin Gothic Demi Cond", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.Control;
            button1.Location = new Point(404, 17);
            button1.Margin = new Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new Size(127, 50);
            button1.TabIndex = 15;
            button1.Text = "CARGAR";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBoxGrado
            // 
            textBoxGrado.Location = new Point(103, 112);
            textBoxGrado.Margin = new Padding(4, 3, 4, 3);
            textBoxGrado.Name = "textBoxGrado";
            textBoxGrado.Size = new Size(120, 30);
            textBoxGrado.TabIndex = 14;
            textBoxGrado.TextAlign = HorizontalAlignment.Center;
            // 
            // labelGrado
            // 
            labelGrado.AutoSize = true;
            labelGrado.BackColor = Color.Transparent;
            labelGrado.Font = new Font("Franklin Gothic Demi Cond", 10F);
            labelGrado.ForeColor = Color.FromArgb(40, 64, 92);
            labelGrado.Location = new Point(16, 112);
            labelGrado.Margin = new Padding(4, 0, 4, 0);
            labelGrado.Name = "labelGrado";
            labelGrado.Size = new Size(67, 25);
            labelGrado.TabIndex = 13;
            labelGrado.Text = "GRADO";
            labelGrado.Click += labelGrado_Click;
            // 
            // buttonCalcular
            // 
            buttonCalcular.BackColor = Color.FromArgb(66, 137, 155);
            buttonCalcular.Font = new Font("Franklin Gothic Demi Cond", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonCalcular.ForeColor = SystemColors.Control;
            buttonCalcular.Location = new Point(133, 716);
            buttonCalcular.Margin = new Padding(4, 3, 4, 3);
            buttonCalcular.Name = "buttonCalcular";
            buttonCalcular.Size = new Size(319, 70);
            buttonCalcular.TabIndex = 12;
            buttonCalcular.Text = "CALCULAR";
            buttonCalcular.UseVisualStyleBackColor = false;
            buttonCalcular.Click += buttonCalcular_Click;
            // 
            // buttonBorrarUltimo
            // 
            buttonBorrarUltimo.BackColor = Color.FromArgb(66, 137, 155);
            buttonBorrarUltimo.Font = new Font("Franklin Gothic Demi Cond", 10F);
            buttonBorrarUltimo.ForeColor = SystemColors.ButtonHighlight;
            buttonBorrarUltimo.Location = new Point(377, 276);
            buttonBorrarUltimo.Margin = new Padding(4, 3, 4, 3);
            buttonBorrarUltimo.Name = "buttonBorrarUltimo";
            buttonBorrarUltimo.Size = new Size(152, 41);
            buttonBorrarUltimo.TabIndex = 11;
            buttonBorrarUltimo.Text = "Borrar Ultimo";
            buttonBorrarUltimo.UseVisualStyleBackColor = false;
            buttonBorrarUltimo.Click += buttonBorrarUltimo_Click;
            // 
            // buttonBorraTodos
            // 
            buttonBorraTodos.BackColor = Color.FromArgb(66, 137, 155);
            buttonBorraTodos.Font = new Font("Franklin Gothic Demi Cond", 10F);
            buttonBorraTodos.ForeColor = SystemColors.ButtonHighlight;
            buttonBorraTodos.Location = new Point(377, 323);
            buttonBorraTodos.Margin = new Padding(4, 3, 4, 3);
            buttonBorraTodos.Name = "buttonBorraTodos";
            buttonBorraTodos.Size = new Size(152, 42);
            buttonBorraTodos.TabIndex = 10;
            buttonBorraTodos.Text = "Borrar Todos";
            buttonBorraTodos.UseVisualStyleBackColor = false;
            buttonBorraTodos.Click += buttonBorraTodos_Click;
            // 
            // buttonSalir
            // 
            buttonSalir.BackColor = Color.FromArgb(204, 60, 49);
            buttonSalir.Font = new Font("Franklin Gothic Demi Cond", 10F);
            buttonSalir.ForeColor = SystemColors.ButtonHighlight;
            buttonSalir.Location = new Point(16, 810);
            buttonSalir.Margin = new Padding(4, 3, 4, 3);
            buttonSalir.Name = "buttonSalir";
            buttonSalir.Size = new Size(127, 43);
            buttonSalir.TabIndex = 9;
            buttonSalir.Text = "Salir";
            buttonSalir.UseVisualStyleBackColor = false;
            buttonSalir.Click += buttonSalir_Click;
            // 
            // labelMetodo
            // 
            labelMetodo.AutoSize = true;
            labelMetodo.BackColor = Color.Transparent;
            labelMetodo.Font = new Font("Franklin Gothic Demi Cond", 10F);
            labelMetodo.ForeColor = Color.FromArgb(40, 64, 92);
            labelMetodo.Location = new Point(17, 155);
            labelMetodo.Margin = new Padding(4, 0, 4, 0);
            labelMetodo.Name = "labelMetodo";
            labelMetodo.Size = new Size(78, 25);
            labelMetodo.TabIndex = 7;
            labelMetodo.Text = "MÉTODO";
            // 
            // comboBoxMetodo
            // 
            comboBoxMetodo.Font = new Font("Franklin Gothic Demi Cond", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxMetodo.FormattingEnabled = true;
            comboBoxMetodo.Items.AddRange(new object[] { "Regresión Lineal", "Regresión Polinomial" });
            comboBoxMetodo.Location = new Point(103, 155);
            comboBoxMetodo.Margin = new Padding(4, 3, 4, 3);
            comboBoxMetodo.Name = "comboBoxMetodo";
            comboBoxMetodo.Size = new Size(218, 33);
            comboBoxMetodo.TabIndex = 6;
            comboBoxMetodo.SelectedIndexChanged += comboBoxMetodo_SelectedIndexChanged_1;
            // 
            // textBoxTolerancia
            // 
            textBoxTolerancia.Location = new Point(133, 68);
            textBoxTolerancia.Margin = new Padding(4, 3, 4, 3);
            textBoxTolerancia.Name = "textBoxTolerancia";
            textBoxTolerancia.Size = new Size(77, 30);
            textBoxTolerancia.TabIndex = 5;
            textBoxTolerancia.Text = "0,8";
            textBoxTolerancia.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Franklin Gothic Demi Cond", 10F);
            label2.ForeColor = Color.FromArgb(40, 64, 92);
            label2.Location = new Point(17, 70);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(108, 25);
            label2.TabIndex = 4;
            label2.Text = "TOLERANCIA";
            // 
            // textBoxY
            // 
            textBoxY.Location = new Point(314, 22);
            textBoxY.Margin = new Padding(4, 3, 4, 3);
            textBoxY.Name = "textBoxY";
            textBoxY.PlaceholderText = "Y";
            textBoxY.Size = new Size(82, 30);
            textBoxY.TabIndex = 2;
            textBoxY.TextAlign = HorizontalAlignment.Center;
            // 
            // textBoxX
            // 
            textBoxX.BackColor = Color.White;
            textBoxX.ForeColor = Color.Black;
            textBoxX.Location = new Point(224, 22);
            textBoxX.Margin = new Padding(4, 3, 4, 3);
            textBoxX.Name = "textBoxX";
            textBoxX.PlaceholderText = "X";
            textBoxX.Size = new Size(82, 30);
            textBoxX.TabIndex = 1;
            textBoxX.TextAlign = HorizontalAlignment.Center;
            // 
            // labelPuntos
            // 
            labelPuntos.AutoSize = true;
            labelPuntos.Font = new Font("Franklin Gothic Demi Cond", 10F);
            labelPuntos.ForeColor = Color.FromArgb(40, 64, 92);
            labelPuntos.Location = new Point(16, 22);
            labelPuntos.Margin = new Padding(4, 0, 4, 0);
            labelPuntos.Name = "labelPuntos";
            labelPuntos.Size = new Size(194, 25);
            labelPuntos.TabIndex = 0;
            labelPuntos.Text = "INGRESAR PUNTO (X, Y)";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(148, 180, 193);
            panel2.Controls.Add(webViewCurvas);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(textBoxCoeficiente);
            panel2.Controls.Add(textBoxEfectividad);
            panel2.Controls.Add(textBoxFuncion);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(593, 24);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(1053, 923);
            panel2.TabIndex = 1;
            // 
            // webViewCurvas
            // 
            webViewCurvas.AllowExternalDrop = true;
            webViewCurvas.CreationProperties = null;
            webViewCurvas.DefaultBackgroundColor = Color.White;
            webViewCurvas.Location = new Point(-1, 140);
            webViewCurvas.Name = "webViewCurvas";
            webViewCurvas.Size = new Size(1054, 783);
            webViewCurvas.TabIndex = 18;
            webViewCurvas.ZoomFactor = 1D;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Franklin Gothic Demi Cond", 10F);
            label4.ForeColor = Color.FromArgb(40, 64, 92);
            label4.Location = new Point(29, 93);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(205, 25);
            label4.TabIndex = 17;
            label4.Text = "EFECTIVIDAD DEL AJUSTE";
            label4.Click += label4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Franklin Gothic Demi Cond", 10F);
            label3.ForeColor = Color.FromArgb(40, 64, 92);
            label3.Location = new Point(29, 58);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(147, 25);
            label3.TabIndex = 16;
            label3.Text = "CORRELACIÓN (r)";
            // 
            // textBoxCoeficiente
            // 
            textBoxCoeficiente.Location = new Point(255, 53);
            textBoxCoeficiente.Margin = new Padding(4, 3, 4, 3);
            textBoxCoeficiente.Name = "textBoxCoeficiente";
            textBoxCoeficiente.Size = new Size(231, 30);
            textBoxCoeficiente.TabIndex = 15;
            textBoxCoeficiente.TextAlign = HorizontalAlignment.Center;
            // 
            // textBoxEfectividad
            // 
            textBoxEfectividad.Location = new Point(255, 93);
            textBoxEfectividad.Margin = new Padding(4, 3, 4, 3);
            textBoxEfectividad.Name = "textBoxEfectividad";
            textBoxEfectividad.Size = new Size(311, 30);
            textBoxEfectividad.TabIndex = 14;
            textBoxEfectividad.TextAlign = HorizontalAlignment.Center;
            // 
            // textBoxFuncion
            // 
            textBoxFuncion.Location = new Point(255, 17);
            textBoxFuncion.Margin = new Padding(4, 3, 4, 3);
            textBoxFuncion.Name = "textBoxFuncion";
            textBoxFuncion.Size = new Size(783, 30);
            textBoxFuncion.TabIndex = 13;
            textBoxFuncion.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Franklin Gothic Demi Cond", 10F);
            label1.ForeColor = Color.FromArgb(40, 64, 92);
            label1.Location = new Point(29, 22);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(163, 25);
            label1.TabIndex = 13;
            label1.Text = "FUNCIÓN OBTENIDA";
            // 
            // AjustesCurvas
            // 
            AutoScaleDimensions = new SizeF(12F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 64, 92);
            ClientSize = new Size(1670, 964);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Franklin Gothic Heavy", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "AjustesCurvas";
            Text = "AjustesCurvas";
            Load += AjustesCurvas_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelPuntos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)webViewCurvas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label labelPuntos;
        private Button buttonCargarPuntos;
        private TextBox textBoxY;
        private TextBox textBoxX;
        private TableLayoutPanel tableLayoutPanel1;
        private Label labelMetodo;
        private ComboBox comboBoxMetodo;
        private TextBox textBoxTolerancia;
        private Label label2;
        private Button buttonSalir;
        private Button buttonCalcular;
        private Button buttonBorrarUltimo;
        private Button buttonBorraTodos;
        private Label label1;
        private Label label4;
        private Label label3;
        private TextBox textBoxCoeficiente;
        private TextBox textBoxEfectividad;
        private TextBox textBoxFuncion;
        private TextBox textBoxGrado;
        private Label labelGrado;
        private Button button1;
        private Graficador graficador2;
        private Panel panelPuntos;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Columnx;
        private DataGridViewTextBoxColumn Columny;
        private Button button2;
        private Microsoft.Web.WebView2.WinForms.WebView2 webViewCurvas;
    }
}