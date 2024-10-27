namespace Analisis_Numerico.Unidad_4
{
    partial class IntegracionNumerica
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
            labelFuncion2 = new Label();
            textBoxFUNCION2 = new TextBox();
            IntegracionWeb = new Microsoft.Web.WebView2.WinForms.WebView2();
            labelInt = new Label();
            labelArea = new Label();
            label3 = new Label();
            label2 = new Label();
            labelXi = new Label();
            labelFuncion = new Label();
            BotonSalir = new Button();
            BotonCalcular = new Button();
            comboBox = new ComboBox();
            textBoxAREA = new TextBox();
            textBoxINT = new TextBox();
            textBoxXD = new TextBox();
            textBoxXI = new TextBox();
            textBoxFUNCION = new TextBox();
            comboOperacion = new ComboBox();
            labelAreas = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)IntegracionWeb).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(148, 180, 193);
            panel1.Controls.Add(labelAreas);
            panel1.Controls.Add(comboOperacion);
            panel1.Controls.Add(labelFuncion2);
            panel1.Controls.Add(textBoxFUNCION2);
            panel1.Controls.Add(IntegracionWeb);
            panel1.Controls.Add(labelInt);
            panel1.Controls.Add(labelArea);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(labelXi);
            panel1.Controls.Add(labelFuncion);
            panel1.Controls.Add(BotonSalir);
            panel1.Controls.Add(BotonCalcular);
            panel1.Controls.Add(comboBox);
            panel1.Controls.Add(textBoxAREA);
            panel1.Controls.Add(textBoxINT);
            panel1.Controls.Add(textBoxXD);
            panel1.Controls.Add(textBoxXI);
            panel1.Controls.Add(textBoxFUNCION);
            panel1.Location = new Point(28, 33);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1460, 778);
            panel1.TabIndex = 0;
            // 
            // labelFuncion2
            // 
            labelFuncion2.AutoSize = true;
            labelFuncion2.ForeColor = Color.FromArgb(40, 64, 92);
            labelFuncion2.Location = new Point(37, 112);
            labelFuncion2.Name = "labelFuncion2";
            labelFuncion2.Size = new Size(66, 30);
            labelFuncion2.TabIndex = 16;
            labelFuncion2.Text = "G(X) =";
            labelFuncion2.Click += labelFuncion2_Click;
            // 
            // textBoxFUNCION2
            // 
            textBoxFUNCION2.BackColor = Color.FloralWhite;
            textBoxFUNCION2.Location = new Point(102, 109);
            textBoxFUNCION2.Margin = new Padding(3, 2, 3, 2);
            textBoxFUNCION2.Name = "textBoxFUNCION2";
            textBoxFUNCION2.Size = new Size(426, 35);
            textBoxFUNCION2.TabIndex = 15;
            // 
            // IntegracionWeb
            // 
            IntegracionWeb.AllowExternalDrop = true;
            IntegracionWeb.CreationProperties = null;
            IntegracionWeb.DefaultBackgroundColor = Color.White;
            IntegracionWeb.Location = new Point(592, 3);
            IntegracionWeb.Name = "IntegracionWeb";
            IntegracionWeb.Size = new Size(865, 772);
            IntegracionWeb.TabIndex = 14;
            IntegracionWeb.ZoomFactor = 1D;
            // 
            // labelInt
            // 
            labelInt.AutoSize = true;
            labelInt.ForeColor = Color.FromArgb(40, 64, 92);
            labelInt.Location = new Point(197, 234);
            labelInt.Name = "labelInt";
            labelInt.Size = new Size(160, 30);
            labelInt.TabIndex = 13;
            labelInt.Text = "Subintervalos (n)";
            // 
            // labelArea
            // 
            labelArea.AutoSize = true;
            labelArea.ForeColor = Color.FromArgb(40, 64, 92);
            labelArea.Location = new Point(61, 463);
            labelArea.Name = "labelArea";
            labelArea.Size = new Size(61, 30);
            labelArea.TabIndex = 12;
            labelArea.Text = "ÁREA";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.FromArgb(40, 64, 92);
            label3.Location = new Point(100, 356);
            label3.Name = "label3";
            label3.Size = new Size(91, 30);
            label3.TabIndex = 11;
            label3.Text = "MÉTODO";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.FromArgb(40, 64, 92);
            label2.Location = new Point(346, 170);
            label2.Name = "label2";
            label2.Size = new Size(41, 30);
            label2.TabIndex = 10;
            label2.Text = "Xd:";
            // 
            // labelXi
            // 
            labelXi.AutoSize = true;
            labelXi.ForeColor = Color.FromArgb(40, 64, 92);
            labelXi.Location = new Point(61, 165);
            labelXi.Name = "labelXi";
            labelXi.Size = new Size(35, 30);
            labelXi.TabIndex = 9;
            labelXi.Text = "Xi:";
            labelXi.Click += labelXi_Click;
            // 
            // labelFuncion
            // 
            labelFuncion.AutoSize = true;
            labelFuncion.ForeColor = Color.FromArgb(40, 64, 92);
            labelFuncion.Location = new Point(41, 61);
            labelFuncion.Name = "labelFuncion";
            labelFuncion.Size = new Size(62, 30);
            labelFuncion.TabIndex = 8;
            labelFuncion.Text = "F(X) =";
            // 
            // BotonSalir
            // 
            BotonSalir.BackColor = Color.OrangeRed;
            BotonSalir.ForeColor = SystemColors.ButtonHighlight;
            BotonSalir.Location = new Point(24, 721);
            BotonSalir.Margin = new Padding(3, 2, 3, 2);
            BotonSalir.Name = "BotonSalir";
            BotonSalir.Size = new Size(124, 41);
            BotonSalir.TabIndex = 7;
            BotonSalir.Text = "SALIR";
            BotonSalir.UseVisualStyleBackColor = false;
            BotonSalir.Click += BotonSalir_Click_1;
            // 
            // BotonCalcular
            // 
            BotonCalcular.BackColor = Color.FromArgb(66, 137, 155);
            BotonCalcular.ForeColor = Color.White;
            BotonCalcular.Location = new Point(132, 606);
            BotonCalcular.Margin = new Padding(3, 2, 3, 2);
            BotonCalcular.Name = "BotonCalcular";
            BotonCalcular.Size = new Size(360, 64);
            BotonCalcular.TabIndex = 6;
            BotonCalcular.Text = "CALCULAR";
            BotonCalcular.UseVisualStyleBackColor = false;
            BotonCalcular.Click += BotonCalcular_Click;
            // 
            // comboBox
            // 
            comboBox.BackColor = Color.FloralWhite;
            comboBox.FormattingEnabled = true;
            comboBox.Items.AddRange(new object[] { "Trapecios Simple", "Trapecios Múltiples", "Simpson 1/3 Simple", "Simpson 1/3 Múltiple", "Simpson 3/8 ", "Simpson 1/3 Múltiple y Simpson 3/8", "Área entre funciones" });
            comboBox.Location = new Point(197, 356);
            comboBox.Margin = new Padding(3, 2, 3, 2);
            comboBox.Name = "comboBox";
            comboBox.Size = new Size(360, 38);
            comboBox.TabIndex = 5;
            // 
            // textBoxAREA
            // 
            textBoxAREA.BackColor = Color.FloralWhite;
            textBoxAREA.Location = new Point(128, 460);
            textBoxAREA.Margin = new Padding(3, 2, 3, 2);
            textBoxAREA.Name = "textBoxAREA";
            textBoxAREA.ReadOnly = true;
            textBoxAREA.Size = new Size(165, 35);
            textBoxAREA.TabIndex = 4;
            // 
            // textBoxINT
            // 
            textBoxINT.BackColor = Color.FloralWhite;
            textBoxINT.Location = new Point(363, 234);
            textBoxINT.Margin = new Padding(3, 2, 3, 2);
            textBoxINT.Name = "textBoxINT";
            textBoxINT.Size = new Size(165, 35);
            textBoxINT.TabIndex = 3;
            // 
            // textBoxXD
            // 
            textBoxXD.BackColor = Color.FloralWhite;
            textBoxXD.Location = new Point(393, 167);
            textBoxXD.Margin = new Padding(3, 2, 3, 2);
            textBoxXD.Name = "textBoxXD";
            textBoxXD.Size = new Size(135, 35);
            textBoxXD.TabIndex = 2;
            // 
            // textBoxXI
            // 
            textBoxXI.BackColor = Color.FloralWhite;
            textBoxXI.Location = new Point(102, 165);
            textBoxXI.Margin = new Padding(3, 2, 3, 2);
            textBoxXI.Name = "textBoxXI";
            textBoxXI.Size = new Size(122, 35);
            textBoxXI.TabIndex = 1;
            // 
            // textBoxFUNCION
            // 
            textBoxFUNCION.BackColor = Color.FloralWhite;
            textBoxFUNCION.Location = new Point(102, 58);
            textBoxFUNCION.Margin = new Padding(3, 2, 3, 2);
            textBoxFUNCION.Name = "textBoxFUNCION";
            textBoxFUNCION.Size = new Size(426, 35);
            textBoxFUNCION.TabIndex = 0;
            // 
            // comboOperacion
            // 
            comboOperacion.BackColor = Color.FloralWhite;
            comboOperacion.FormattingEnabled = true;
            comboOperacion.Items.AddRange(new object[] { "", "Área entre funciones" });
            comboOperacion.Location = new Point(175, 290);
            comboOperacion.Margin = new Padding(3, 2, 3, 2);
            comboOperacion.Name = "comboOperacion";
            comboOperacion.Size = new Size(151, 38);
            comboOperacion.TabIndex = 17;
            // 
            // labelAreas
            // 
            labelAreas.AutoSize = true;
            labelAreas.ForeColor = Color.FromArgb(40, 64, 92);
            labelAreas.Location = new Point(35, 290);
            labelAreas.Name = "labelAreas";
            labelAreas.Size = new Size(134, 30);
            labelAreas.TabIndex = 18;
            labelAreas.Text = "ENTRE AREAS";
            // 
            // IntegracionNumerica
            // 
            AutoScaleDimensions = new SizeF(11F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 64, 92);
            ClientSize = new Size(1526, 839);
            Controls.Add(panel1);
            Font = new Font("Franklin Gothic Medium Cond", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(40, 64, 92);
            Margin = new Padding(3, 2, 3, 2);
            Name = "IntegracionNumerica";
            Text = "IntegracionNumerica";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)IntegracionWeb).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox textBoxXI;
        private TextBox textBoxFUNCION;
        private TextBox textBoxXD;
        private TextBox textBoxINT;
        private TextBox textBoxAREA;
        private Button BotonCalcular;
        private ComboBox comboBox;
        private Label labelFuncion;
        private Button BotonSalir;
        private Label labelInt;
        private Label labelArea;
        private Label label3;
        private Label label2;
        private Label labelXi;
        private Microsoft.Web.WebView2.WinForms.WebView2 IntegracionWeb;
        private TextBox textBoxFUNCION2;
        private Label labelFuncion2;
        private Label labelAreas;
        private ComboBox comboOperacion;
    }
}