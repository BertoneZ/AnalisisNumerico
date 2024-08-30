namespace Analisis_Numerico
{
    partial class CalculadoraDeRaices
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
            components = new System.ComponentModel.Container();
            BotonCalcular = new Button();
            metodos = new ComboBox();
            maxIter = new TextBox();
            tolerancia = new TextBox();
            funcion = new TextBox();
            Xi = new TextBox();
            labelXi = new Label();
            labelXd = new Label();
            Xd = new TextBox();
            labelIteraciones = new Label();
            labelTolerancia = new Label();
            label3 = new Label();
            label4 = new Label();
            errorProvider1 = new ErrorProvider(components);
            raiz = new TextBox();
            label7 = new Label();
            webview = new Microsoft.Web.WebView2.WinForms.WebView2();
            BotonSalirRaices = new Button();
            iteracionesP = new TextBox();
            maxIteracionesLabel = new Label();
            X = new TextBox();
            labelX = new Label();
            labelDesde = new Label();
            desde = new TextBox();
            hasta = new TextBox();
            labelHasta = new Label();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)webview).BeginInit();
            SuspendLayout();
            // 
            // BotonCalcular
            // 
            BotonCalcular.ForeColor = Color.Teal;
            BotonCalcular.Location = new Point(52, 783);
            BotonCalcular.Margin = new Padding(4, 2, 4, 2);
            BotonCalcular.Name = "BotonCalcular";
            BotonCalcular.Size = new Size(136, 61);
            BotonCalcular.TabIndex = 0;
            BotonCalcular.Text = "Calcular";
            BotonCalcular.UseVisualStyleBackColor = true;
            // 
            // metodos
            // 
            metodos.AutoCompleteMode = AutoCompleteMode.Suggest;
            metodos.AutoCompleteSource = AutoCompleteSource.ListItems;
            metodos.FormattingEnabled = true;
            metodos.Items.AddRange(new object[] { "Biseccion", "Regla Falsa", "Newton-Raphson", "Secante" });
            metodos.Location = new Point(52, 182);
            metodos.Margin = new Padding(4, 2, 4, 2);
            metodos.Name = "metodos";
            metodos.Size = new Size(321, 35);
            metodos.TabIndex = 1;
            // 
            // maxIter
            // 
            maxIter.Location = new Point(52, 268);
            maxIter.Margin = new Padding(4, 2, 4, 2);
            maxIter.Name = "maxIter";
            maxIter.Size = new Size(321, 35);
            maxIter.TabIndex = 4;
            maxIter.Text = "100";
       
            // 
            // tolerancia
            // 
            tolerancia.BorderStyle = BorderStyle.FixedSingle;
            tolerancia.Location = new Point(52, 344);
            tolerancia.Margin = new Padding(4, 2, 4, 2);
            tolerancia.Name = "tolerancia";
            tolerancia.Size = new Size(321, 35);
            tolerancia.TabIndex = 5;
            tolerancia.Text = " 0,0001";
            // 
            // funcion
            // 
            funcion.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            funcion.ForeColor = SystemColors.InfoText;
            funcion.Location = new Point(52, 109);
            funcion.Margin = new Padding(4, 2, 4, 2);
            funcion.Name = "funcion";
            funcion.Size = new Size(321, 35);
            funcion.TabIndex = 6;
            // 
            // Xi
            // 
            Xi.CausesValidation = false;
            Xi.Location = new Point(52, 533);
            Xi.Margin = new Padding(4, 2, 4, 2);
            Xi.Name = "Xi";
            Xi.Size = new Size(250, 35);
            Xi.TabIndex = 7;
            // 
            // labelXi
            // 
            labelXi.AutoSize = true;
            labelXi.Location = new Point(52, 494);
            labelXi.Margin = new Padding(4, 0, 4, 0);
            labelXi.Name = "labelXi";
            labelXi.Size = new Size(119, 27);
            labelXi.TabIndex = 10;
            labelXi.Text = "Ingrese Xi";
            // 
            // labelXd
            // 
            labelXd.AutoSize = true;
            labelXd.Location = new Point(52, 585);
            labelXd.Margin = new Padding(4, 0, 4, 0);
            labelXd.Name = "labelXd";
            labelXd.Size = new Size(128, 27);
            labelXd.TabIndex = 11;
            labelXd.Text = "Ingrese Xd";
            // 
            // Xd
            // 
            Xd.Location = new Point(52, 623);
            Xd.Margin = new Padding(4, 2, 4, 2);
            Xd.Name = "Xd";
            Xd.Size = new Size(250, 35);
            Xd.TabIndex = 12;
            // 
            // labelIteraciones
            // 
            labelIteraciones.AutoSize = true;
            labelIteraciones.Location = new Point(52, 238);
            labelIteraciones.Margin = new Padding(4, 0, 4, 0);
            labelIteraciones.Name = "labelIteraciones";
            labelIteraciones.Size = new Size(128, 27);
            labelIteraciones.TabIndex = 13;
            labelIteraciones.Text = "Iteraciones";
            // 
            // labelTolerancia
            // 
            labelTolerancia.AutoSize = true;
            labelTolerancia.Location = new Point(52, 316);
            labelTolerancia.Margin = new Padding(4, 0, 4, 0);
            labelTolerancia.Name = "labelTolerancia";
            labelTolerancia.Size = new Size(120, 27);
            labelTolerancia.TabIndex = 14;
            labelTolerancia.Text = "Tolerancia";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(52, 80);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(99, 27);
            label3.TabIndex = 15;
            label3.Text = "Función";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(52, 153);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(91, 27);
            label4.TabIndex = 16;
            label4.Text = "Método";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // raiz
            // 
            raiz.Location = new Point(52, 713);
            raiz.Margin = new Padding(4, 2, 4, 2);
            raiz.Name = "raiz";
            raiz.Size = new Size(136, 35);
            raiz.TabIndex = 17;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(52, 683);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(89, 27);
            label7.TabIndex = 18;
            label7.Text = "Raiz Xr";
            // 
            // webview
            // 
            webview.AllowExternalDrop = true;
            webview.CreationProperties = null;
            webview.DefaultBackgroundColor = Color.White;
            webview.Location = new Point(459, 54);
            webview.Margin = new Padding(4, 2, 4, 2);
            webview.Name = "webview";
            webview.Size = new Size(1166, 877);
            webview.TabIndex = 19;
            webview.ZoomFactor = 1D;
            // 
            // BotonSalirRaices
            // 
            BotonSalirRaices.Location = new Point(52, 860);
            BotonSalirRaices.Margin = new Padding(5, 2, 5, 2);
            BotonSalirRaices.Name = "BotonSalirRaices";
            BotonSalirRaices.Size = new Size(136, 59);
            BotonSalirRaices.TabIndex = 22;
            BotonSalirRaices.Text = "Salir";
            BotonSalirRaices.UseVisualStyleBackColor = true;
            // 
            // iteracionesP
            // 
            iteracionesP.Location = new Point(245, 712);
            iteracionesP.Margin = new Padding(4, 2, 4, 2);
            iteracionesP.Name = "iteracionesP";
            iteracionesP.Size = new Size(128, 35);
            iteracionesP.TabIndex = 23;
            // 
            // maxIteracionesLabel
            // 
            maxIteracionesLabel.AutoSize = true;
            maxIteracionesLabel.Location = new Point(245, 683);
            maxIteracionesLabel.Margin = new Padding(4, 0, 4, 0);
            maxIteracionesLabel.Name = "maxIteracionesLabel";
            maxIteracionesLabel.Size = new Size(128, 27);
            maxIteracionesLabel.TabIndex = 24;
            maxIteracionesLabel.Text = "Iteraciones";
            // 
            // X
            // 
            X.Location = new Point(52, 448);
            X.Margin = new Padding(4, 2, 4, 2);
            X.Name = "X";
            X.Size = new Size(321, 35);
            X.TabIndex = 25;
            // 
            // labelX
            // 
            labelX.AutoSize = true;
            labelX.Location = new Point(52, 411);
            labelX.Margin = new Padding(4, 0, 4, 0);
            labelX.Name = "labelX";
            labelX.Size = new Size(114, 27);
            labelX.TabIndex = 26;
            labelX.Text = "Ingrese X";
            // 
            // labelDesde
            // 
            labelDesde.AutoSize = true;
            labelDesde.Location = new Point(52, 494);
            labelDesde.Margin = new Padding(4, 0, 4, 0);
            labelDesde.Name = "labelDesde";
            labelDesde.Size = new Size(170, 27);
            labelDesde.TabIndex = 27;
            labelDesde.Text = "Graficar desde";
            // 
            // desde
            // 
            desde.Location = new Point(52, 533);
            desde.Margin = new Padding(4, 2, 4, 2);
            desde.Name = "desde";
            desde.Size = new Size(321, 35);
            desde.TabIndex = 28;
            // 
            // hasta
            // 
            hasta.Location = new Point(52, 623);
            hasta.Margin = new Padding(4, 2, 4, 2);
            hasta.Name = "hasta";
            hasta.Size = new Size(321, 35);
            hasta.TabIndex = 29;
            // 
            // labelHasta
            // 
            labelHasta.AutoSize = true;
            labelHasta.Location = new Point(52, 585);
            labelHasta.Margin = new Padding(4, 0, 4, 0);
            labelHasta.Name = "labelHasta";
            labelHasta.Size = new Size(163, 27);
            labelHasta.TabIndex = 30;
            labelHasta.Text = "Graficar hasta";
            // 
            // CalculadoraDeRaices
            // 
            AcceptButton = BotonCalcular;
            AutoScaleDimensions = new SizeF(14F, 27F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Teal;
            ClientSize = new Size(1638, 943);
            Controls.Add(labelHasta);
            Controls.Add(hasta);
            Controls.Add(desde);
            Controls.Add(labelDesde);
            Controls.Add(labelX);
            Controls.Add(X);
            Controls.Add(maxIteracionesLabel);
            Controls.Add(iteracionesP);
            Controls.Add(BotonSalirRaices);
            Controls.Add(webview);
            Controls.Add(label7);
            Controls.Add(raiz);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(labelTolerancia);
            Controls.Add(labelIteraciones);
            Controls.Add(Xd);
            Controls.Add(labelXd);
            Controls.Add(labelXi);
            Controls.Add(Xi);
            Controls.Add(funcion);
            Controls.Add(tolerancia);
            Controls.Add(maxIter);
            Controls.Add(metodos);
            Controls.Add(BotonCalcular);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.White;
            KeyPreview = true;
            Margin = new Padding(4, 2, 4, 2);
            Name = "CalculadoraDeRaices";
            Text = "Calculadora de Raices";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)webview).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BotonCalcular;
        private ComboBox metodos;
        private TextBox maxIter;
        private TextBox tolerancia;
        private TextBox funcion;
        private TextBox Xi;
        private Label labelXi;
        private Label labelXd;
        private TextBox Xd;
        private Label labelIteraciones;
        private Label labelTolerancia;
        private Label label3;
        private Label label4;
        private ErrorProvider errorProvider1;
        private Label label7;
        private TextBox raiz;
        private Microsoft.Web.WebView2.WinForms.WebView2 webview;
        private Button BotonSalirRaices;
        private TextBox iteracionesP;
        private Label maxIteracionesLabel;
        private TextBox X;
        private Label labelX;
        private Label labelHasta;
        private TextBox hasta;
        private TextBox desde;
        private Label labelDesde;
    }
}