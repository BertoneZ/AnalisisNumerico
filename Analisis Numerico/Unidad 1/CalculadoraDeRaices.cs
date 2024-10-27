using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Text;
using Calculus;
using Microsoft.Web.WebView2.Wpf;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection.Emit;
namespace Analisis_Numerico
{
    using Microsoft.Web.WebView2.WinForms;
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using static System.Runtime.InteropServices.JavaScript.JSType;

    public partial class CalculadoraDeRaices : Form
    {
        private Color fondo = Color.FromArgb(44, 62, 80); // Fondo oscuro
        private Color boton = Color.FromArgb(231, 76, 60); // Botón
        private Color textoBoton = Color.FromArgb(255, 255, 255); // Texto del botón
        private Color texto = Color.FromArgb(28, 28, 28); // Texto
        private Color borde = Color.FromArgb(52, 73, 94); // Bordes

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        public Calculo analizadorFunciones = new Calculo();

        public CalculadoraDeRaices()
        {
            InitializeComponent();
            AplicarEstilo();
            OcultarCampos();
            metodos.SelectedIndexChanged += metodos_SelectedIndexChanged;
            BotonCalcular.Click += button1_Click;
            BotonSalirRaices.Click += BotonSalirRaices_Click;
            this.FormBorderStyle = FormBorderStyle.None; // Quitar el borde de la ventana
            this.Padding = new Padding(2);
            this.Size = new Size(800, 600);

        }

        public void AplicarEstilo()
        {
            this.BackColor = fondo;
            funcion.ForeColor = texto;
            Xi.ForeColor = texto;
            Xd.ForeColor = texto;
            maxIter.ForeColor = texto;
            tolerancia.ForeColor = texto;
            raiz.ForeColor = texto;
            MaximizeBox = true;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.CenterToScreen();

            this.BackColor = borde;
            Panel tituloBarra = new Panel();
            tituloBarra.Dock = DockStyle.Top;
            tituloBarra.Height = 50;
            tituloBarra.BackColor = fondo;

            Label tituloEtiqueta = new Label();
            tituloEtiqueta.Text = "Calculadora de Raíces - Análisis Numérico";
            tituloEtiqueta.ForeColor = textoBoton;
            tituloEtiqueta.Dock = DockStyle.Left;
            tituloEtiqueta.TextAlign = ContentAlignment.MiddleLeft;
            tituloEtiqueta.AutoSize = true;

            Button botonCerrar = new Button();
            botonCerrar.Text = "X";
            botonCerrar.Dock = DockStyle.Right;
            botonCerrar.Width = 50;
            botonCerrar.ForeColor = textoBoton;
            botonCerrar.BackColor = Color.FromArgb(231, 76, 60);
            botonCerrar.FlatStyle = FlatStyle.Flat;
            botonCerrar.FlatAppearance.BorderSize = 0;

            botonCerrar.Click += new EventHandler((sender, e) =>
            {
                MenuPrincipal menu = new MenuPrincipal();
                menu.Show();
                this.Hide();
            });

            tituloBarra.Controls.Add(tituloEtiqueta);
            tituloBarra.Controls.Add(botonCerrar);


            Button botonMaximizar = new Button();
            botonMaximizar.Text = "□";
            botonMaximizar.Dock = DockStyle.Right;
            botonMaximizar.Width = 50;
            botonMaximizar.ForeColor = textoBoton;
            botonMaximizar.BackColor = fondo;
            botonMaximizar.FlatStyle = FlatStyle.Flat;
            botonMaximizar.FlatAppearance.BorderSize = 0;

            botonMaximizar.Click += (s, e) =>
            {
                this.WindowState = this.WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
            };

            botonMaximizar.Click += (s, e) =>
            {
                webview.Size = new Size(this.Width - 500, this.Height - 100);
            };

            Button botonMinimizar = new Button();
            botonMinimizar.Text = "-";
            botonMinimizar.Dock = DockStyle.Right;
            botonMinimizar.Width = 50;
            botonMinimizar.ForeColor = textoBoton; //esto 
            botonMinimizar.BackColor = fondo;
            botonMinimizar.FlatStyle = FlatStyle.Flat;
            botonMinimizar.FlatAppearance.BorderSize = 0;
            botonMinimizar.Click += (s, e) => this.WindowState = FormWindowState.Minimized;


            tituloBarra.Controls.Add(tituloEtiqueta);
            tituloBarra.Controls.Add(botonMinimizar);
            tituloBarra.Controls.Add(botonMaximizar);
            tituloBarra.Controls.Add(botonCerrar);

            this.Controls.Add(tituloBarra);
            tituloBarra.MouseDown += tituloBarra_MouseDown;
            tituloBarra.MouseMove += tituloBarra_MouseMove;
            tituloBarra.MouseUp += tituloBarra_MouseUp;

            // Aplicar estilo a los botones
            BotonCalcular.BackColor = boton;
            BotonCalcular.ForeColor = textoBoton;
            BotonCalcular.FlatStyle = FlatStyle.Flat;
            BotonCalcular.Size = new Size(130, 60);
            BotonCalcular.FlatAppearance.BorderSize = 0;
            BotonCalcular.MouseEnter += (s, e) => BotonCalcular.BackColor = Color.FromArgb(204, 60, 49); // Efecto hover
            BotonCalcular.MouseLeave += (s, e) => BotonCalcular.BackColor = boton;

            BotonSalirRaices.BackColor = boton;
            BotonSalirRaices.ForeColor = textoBoton;
            BotonSalirRaices.FlatStyle = FlatStyle.Flat;
            BotonSalirRaices.Size = new Size(130, 60);
            BotonSalirRaices.FlatAppearance.BorderSize = 0;
            BotonSalirRaices.MouseEnter += (s, e) => BotonSalirRaices.BackColor = Color.FromArgb(204, 60, 49); // Efecto hover
            BotonSalirRaices.MouseLeave += (s, e) => BotonSalirRaices.BackColor = boton;

        }
        private void tituloBarra_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void tituloBarra_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(diff));
            }
        }

        private void tituloBarra_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        public void OcultarCampos()
        {
            // Ocultar todos los campos inicialmente
            Xi.Visible = false;
            Xd.Visible = false;
            maxIter.Visible = false;
            tolerancia.Visible = false;
            labelXi.Visible = false;
            labelXd.Visible = false;
            labelIteraciones.Visible = false;
            labelTolerancia.Visible = false;
            X.Visible = false;
            labelX.Visible = false;
            desde.Visible = false;
            hasta.Visible = false;
            labelDesde.Visible = false;
            labelHasta.Visible = false;
        }

        public void button1_Click(object sender, EventArgs e)
        {
            //hacer que salga error si los campos estan vacios
            if (funcion.Text == "" || maxIter.Text == "" || tolerancia.Text == "")
            {

                errorProvider1.SetError(funcion, "Por favor, llene todos los campos");
                return;
            }
            // Evaluar la sintaxis de la función
            if (!analizadorFunciones.Sintaxis(funcion.Text, 'x'))
            {
                MessageBox.Show("La función tiene un error de sintaxis.");
                return;
            }

            // Obtener los datos ingresados
            string func = funcion.Text;
            int maxIteraciones = int.Parse(maxIter.Text);
            double tole = double.Parse(tolerancia.Text);

            // Verificar si se seleccionó un método
            if (metodos.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un método de cálculo.");
                return;
            }
            double resultado = double.NaN;

            if (metodos.SelectedIndex == 0 || metodos.SelectedIndex == 1)
            {
                if (Xi.Text == "" || Xd.Text == "")
                {
                    errorProvider1.SetError(Xi, "Por favor, llene todos los campos");
                    errorProvider1.SetError(Xd, "Por favor, llene todos los campos");
                    return;
                }
                double xiCerrado = double.Parse(Xi.Text);
                double xdCerrado = double.Parse(Xd.Text);
                resultado = MetodosCerrados(func, xiCerrado, xdCerrado, maxIteraciones, tole);
                string funcionEscapada = Uri.EscapeDataString(func);
                string geogebraUrl = $"https://www.geogebra.org/graphing?command=Function({funcionEscapada}, {xiCerrado}, {xdCerrado})";
                webview.Source = new Uri(geogebraUrl);
            }
            if (metodos.SelectedIndex == 2)
            {
                if (X.Text == "" || desde.Text == " " || hasta.Text == "")
                {
                    errorProvider1.SetError(X, "Por favor, llene todos los campos");
                    errorProvider1.SetError(desde, "Por favor, llene todos los campos");
                    errorProvider1.SetError(hasta, "Por favor, llene todos los campos");
                    return;
                }
                double x = double.Parse(X.Text);
                double Desde = double.Parse(desde.Text);
                double Hasta = double.Parse(hasta.Text);
                resultado = MetodoTangente(func, x, maxIteraciones, tole);
                string funcionEscapada = Uri.EscapeDataString(func);
                string geogebraUrl = $"https://www.geogebra.org/graphing?command=Function({funcionEscapada}, {Desde}, {Hasta})";
                webview.Source = new Uri(geogebraUrl);
            }
            if (metodos.SelectedIndex == 3)
            {
                if (Xi.Text == "" || Xd.Text == "")
                {
                    errorProvider1.SetError(Xi, "Por favor, llene todos los campos");
                    errorProvider1.SetError(Xd, "Por favor, llene todos los campos");
                    return;
                }
                double xi = double.Parse(Xi.Text);
                double xd = double.Parse(Xd.Text);
                resultado = MetodoSecante(func, xi, xd, maxIteraciones, tole);
                string FuncionEscapada = Uri.EscapeDataString(func);
                string GeogebraUrl = $"https://www.geogebra.org/graphing?command=Function({FuncionEscapada}, {xi}, {xd})";
                webview.Source = new Uri(GeogebraUrl);
            }
            raiz.Text = resultado.ToString();
        }
        //public double MetodosCerrados(string func, double xiCerrado, double xdCerrado, int maxIteraciones, double tole)
        //{
        //    double fxi = analizadorFunciones.EvaluaFx(xiCerrado);
        //    double fxd = analizadorFunciones.EvaluaFx(xdCerrado);
        //    int iteraciones = 0;
        //    if (fxi * fxd > 0)
        //    {
        //        MessageBox.Show("Vuelva a ingresar xi y xd. No hay raíz en el intervalo.");
        //        return double.NaN;
        //    }

        //    if (fxi == 0)
        //    {
        //        return xiCerrado; // xiCerrado es raíz
        //    }

        //    if (fxd == 0)
        //    {
        //        return xdCerrado; // xdCerrado es raíz
        //    }

        //    double xrAnterior = 0;
        //    double xr = 0;
        //    double error = double.MaxValue;

        //    for (int i = 0; i < maxIteraciones; i++)
        //    {
        //        iteraciones = i;
        //        xr = CalcularXr(func, xiCerrado, xdCerrado, metodos.SelectedIndex);
        //        error = Math.Abs((xr - xrAnterior) / xr);

        //        if (Math.Abs(analizadorFunciones.EvaluaFx(xr)) < tole || error < tole)
        //        {
        //            iteracionesP.Text = iteraciones.ToString();
        //            return xr; // xr es raíz
        //        }

        //        if (fxi * analizadorFunciones.EvaluaFx(xr) > 0)
        //        {
        //            xiCerrado = xr;
        //        }
        //        else
        //        {
        //            xdCerrado = xr;
        //        }
        //        iteracionesP.Text = iteraciones.ToString();
        //        xrAnterior = xr;
        //        textBoxError.Text = error.ToString();
        //    }
        //    MessageBox.Show($"El método no converge dentro de {maxIteraciones} iteraciones");


        //    return xr; // Devuelve xr después de iteraciones
        //}

        public double MetodosCerrados(string func, double xiCerrado, double xdCerrado, int maxIteraciones, double tole)
        {
            double fxi = analizadorFunciones.EvaluaFx(xiCerrado);
            double fxd = analizadorFunciones.EvaluaFx(xdCerrado);
            int iteraciones = 0;

            // Verificar si hay raíz en el intervalo inicial
            if (fxi * fxd > 0)
            {
                MessageBox.Show("Vuelva a ingresar xi y xd. No hay raíz en el intervalo.");
                return double.NaN;
            }

            if (fxi == 0)
            {
                return xiCerrado; // xiCerrado es raíz
            }

            if (fxd == 0)
            {
                return xdCerrado; // xdCerrado es raíz
            }

            double xrAnterior = 0;
            double xr = 0;
            double error = double.MaxValue;

            for (int i = 0; i < maxIteraciones; i++)
            {
                iteraciones = i;
                xr = CalcularXr(func, xiCerrado, xdCerrado, metodos.SelectedIndex);
                error = Math.Abs((xr - xrAnterior) / xr);

                // Verificar si el error es suficientemente pequeño
                if (Math.Abs(analizadorFunciones.EvaluaFx(xr)) < tole || error < tole)
                {
                    iteracionesP.Text = iteraciones.ToString();
                    return xr; // xr es raíz
                }

                // Verificar si hay un comportamiento brusco cerca de la raíz
                if (Math.Abs(xr - xrAnterior) < 1e-10) // Umbral para detectar cambios muy pequeños
                {
                    MessageBox.Show("La función presenta un comportamiento casi constante o un brusco empinamiento cerca de la raíz. No se puede determinar la raíz con precisión.");
                    return double.NaN;
                }

                if (fxi * analizadorFunciones.EvaluaFx(xr) > 0)
                {
                    xiCerrado = xr;
                }
                else
                {
                    xdCerrado = xr;
                }

                iteracionesP.Text = iteraciones.ToString();
                xrAnterior = xr;
                textBoxError.Text = error.ToString();
            }

            // Si se supera el número máximo de iteraciones
            MessageBox.Show($"El método no converge dentro de {maxIteraciones} iteraciones.");
            return double.NaN; // Devuelve NaN para indicar no convergencia
        }



        public double CalcularXr(string func, double xiCerrado, double xdCerrado, int metodo)
        {
            double xr = 0;

            double fxi = analizadorFunciones.EvaluaFx(xiCerrado);
            double fxd = analizadorFunciones.EvaluaFx(xdCerrado);


            switch (metodo)
            {
                case 0: // Bisección
                    xr = (xiCerrado + xdCerrado) / 2.0;
                    break;
                case 1: // Regla Falsa
                    xr = (fxd * xiCerrado - fxi * xdCerrado) / (fxd - fxi);
                    break;
            }

            return xr;
        }
        public double MetodoTangente(string func, double x, int maxIteraciones, double tole)
        {
            double xr = x;
            double error = double.MaxValue;
            int iteraciones = 0;
            for (int i = 1; i < maxIteraciones; i++)
            {
                iteraciones = i;
                double fx = analizadorFunciones.EvaluaFx(xr);
                double derivada = analizadorFunciones.Dx(xr);
                double xrNuevo = xr - (fx / derivada);
                error = Math.Abs((xrNuevo - xr) / xrNuevo);

                if (Math.Abs(fx) < tole || error < tole)
                {
                    iteracionesP.Text = iteraciones.ToString();

                    return xrNuevo;
                }
                if (double.IsNaN(derivada))
                {
                    MessageBox.Show("El método diverge. No se encuentra raíz.");
                    return double.NaN;
                }
                textBoxError.Text = error.ToString();
                xr = xrNuevo;
            }
            MessageBox.Show($"El método no converge dentro de {maxIteraciones} iteraciones");
            iteracionesP.Text = iteraciones.ToString();
            textBoxError.Text = error.ToString();
            return xr;
        }


        public double MetodoSecante(string func, double xi, double xd, int maxIteraciones, double tole)
        {
            double xr = 0;
            double error = double.MaxValue;
            int iteraciones = 0;
            for (int i = 0; i < maxIteraciones; i++)
            {
                iteraciones = i;
                double fxi = analizadorFunciones.EvaluaFx(xi);
                double fxd = analizadorFunciones.EvaluaFx(xd);

                xr = (fxd * xi - fxi * xd) / (fxd - fxi);

                //if (double.IsNaN(xr))
                //{
                //    MessageBox.Show("El método diverge. No se encuentra raíz.");
                //    return double.NaN;
                //}

                error = Math.Abs((xr - xd) / xr);

                if (Math.Abs(analizadorFunciones.EvaluaFx(xr)) < tole || error < tole)
                {
                    iteracionesP.Text = iteraciones.ToString();

                    return xr;
                }

                xi = xd;
                xd = xr;
                textBoxError.Text = error.ToString();
                iteracionesP.Text = iteraciones.ToString();
            }

            MessageBox.Show($"El método no converge dentro de {maxIteraciones} iteraciones");
            iteracionesP.Text = iteraciones.ToString();
            textBoxError.Text = error.ToString();

            return xr;
        }

        private void metodos_SelectedIndexChanged(object sender, EventArgs e)
        {
            OcultarCampos(); // Ocultar todos los campos

            switch (metodos.SelectedIndex)
            {
                case 2: // Método de la Tangente
                    labelIteraciones.Visible = true;
                    maxIter.Visible = true;
                    labelTolerancia.Visible = true;
                    tolerancia.Visible = true;
                    X.Visible = true;
                    labelX.Visible = true;
                    labelX.Text = "Ingrese X";

                    desde.Visible = true;
                    hasta.Visible = true;
                    labelDesde.Visible = true;
                    labelHasta.Visible = true;
                    desde.Enabled = true;
                    hasta.Enabled = true;
                    break;
                default: // Otros métodos
                    Xi.Visible = true;
                    Xi.Enabled = true;
                    Xd.Visible = true;
                    Xd.Enabled = true;
                    labelXi.Visible = true;
                    labelXd.Visible = true;
                    labelXi.Text = "Ingrese Xi";
                    labelXd.Text = "Ingrese Xd";
                    labelIteraciones.Visible = true;
                    maxIter.Visible = true;
                    labelTolerancia.Visible = true;
                    tolerancia.Visible = true;
                    X.Visible = false;
                    labelX.Visible = false;
                    desde.Visible = false;
                    hasta.Visible = false;
                    labelDesde.Visible = false;
                    labelHasta.Visible = false;
                    desde.Enabled = false;
                    hasta.Enabled = false;
                    break;

            }
        }
        private void BotonSalirRaices_Click(object sender, EventArgs e)
        {
            MenuPrincipal menu = new MenuPrincipal();
            menu.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BotonCalcular_Click(object sender, EventArgs e)
        {

        }
    }
}



