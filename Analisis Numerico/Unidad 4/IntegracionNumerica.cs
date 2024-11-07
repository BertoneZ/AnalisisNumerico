using Calculus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.Web.WebView2.WinForms;
using Microsoft.Web.WebView2.Wpf;
using System.IO;
using System.Text.RegularExpressions;



namespace Analisis_Numerico.Unidad_4
{
    public partial class IntegracionNumerica : Form
    {

        public IntegracionNumerica()
        {
            InitializeComponent();
            Form1_Load();
            OcultarCampos();
            // Llamada a la función que oculta los campos de la segunda función
            comboOperacion.SelectedItem = "No";
            comboOperacion.SelectedIndexChanged += new EventHandler(comboOperacion_SelectedItem);

        }

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private async void Form1_Load()
        {
            await IntegracionWeb.EnsureCoreWebView2Async(null);
            IntegracionWeb.Source = new Uri("https://www.geogebra.org/graphing");  // Cargar la aplicación de GeoGebra en el WebView2
        }


        private void BotonCalcular_Click(object sender, EventArgs e)
        {
          
            double xi = double.Parse(textBoxXI.Text);
            double xd = double.Parse(textBoxXD.Text);
           
             

            string funcion1 = textBoxFUNCION.Text;
            string funcion2 = textBoxFUNCION2.Text;
            double resultado = 0.0;
            int n = 1;
            if (comboBox.SelectedIndex == 1 || comboBox.SelectedIndex == 3 || comboBox.SelectedIndex == 5)
            {
                n = int.Parse(textBoxINT.Text);
            }

            if (!string.IsNullOrEmpty(funcion2) && comboOperacion.SelectedItem.ToString() == "Si")
            {
                // Calcula la función diferencia entre las dos funciones

                string funcionDiferencia = $"({funcion1}) - ({funcion2})";

                // Utilizar la función diferencia para calcular el área
                switch (comboBox.SelectedIndex)
                {
                    case 0:
                        resultado = CalcularIntegralTrapecioSimple(funcionDiferencia, xi, xd);
                        break;
                    case 1:
                        resultado = CalcularIntegralTrapeciosMultiple(funcionDiferencia, xi, xd, n);
                        break;
                    case 2:
                        resultado = CalcularIntegralSimpson1_3Simple(funcionDiferencia, xi, xd);
                        break;
                    case 3:
                        resultado = CalcularIntegralSimpson1_3Multiple(funcionDiferencia, xi, xd, n);
                        break;
                    case 4:
                        resultado = CalcularIntegralSimpson3_8Simple(funcionDiferencia, xi, xd);
                        break;
                    case 5:
                        resultado = CalcularIntegralSimpson3_8Multiple(funcionDiferencia, xi, xd, n);
                        break;

                    default:
                        MessageBox.Show("Por favor, seleccione un método de integración válido.");
                        return;
                }
            }
            else
            {
                // Si solo hay una función o no se selecciona calcular el área entre funciones
                string funcionFinal = !string.IsNullOrEmpty(funcion2) ? $"({funcion1}) {comboBox.SelectedItem.ToString()} ({funcion2})" : funcion1;

                switch (comboBox.SelectedIndex)
                {
                    case 0:
                        resultado = CalcularIntegralTrapecioSimple(funcionFinal, xi, xd);
                        break;
                    case 1:
                        resultado = CalcularIntegralTrapeciosMultiple(funcionFinal, xi, xd, n);
                        break;
                    case 2:
                        resultado = CalcularIntegralSimpson1_3Simple(funcionFinal, xi, xd);
                        break;
                    case 3:
                        resultado = CalcularIntegralSimpson1_3Multiple(funcionFinal, xi, xd, n);
                        break;
                    case 4:
                        resultado = CalcularIntegralSimpson3_8Simple(funcionFinal, xi, xd);
                        break;
                    case 5:
                        resultado = CalcularIntegralSimpson3_8Multiple(funcionFinal, xi, xd, n);
                        break;
                    default:
                        MessageBox.Show("Por favor, seleccione un método de integración válido.");
                        return;
                }
            }
            // Asignar el resultado al TextBox con 4 decimales
            textBoxAREA.Text = resultado.ToString("0.00000");

            PintarFuncion();
        }




        //trapecios simple
        public double CalcularIntegralTrapecioSimple(string funcion, double xi, double xd)
        {
            // Crear una instancia de la clase que evalúa la función
            Calculo Function = new Calculo();




            if (funcion.Contains("ln"))
            {
                funcion = funcion.Replace("ln", "log");
            }




            // Verificar si la función es válida y tiene 'x' como variable
            if (Function.Sintaxis(funcion, 'x'))
            {
                // Evaluar la función en los puntos xi (a) y xd (b)
                double fXi = Function.EvaluaFx(xi); // f(a)
                double fXd = Function.EvaluaFx(xd); // f(b)

                // Calcular el valor de la integral con el método del trapecio
                return ((fXi + fXd) * (xd - xi)) / 2;
            }
            else
            {
                // Si la función no es válida
                throw new ArgumentException("Función mal ingresada");
            }



        }



        //trapecios multiples
        public double CalcularIntegralTrapeciosMultiple(string funcion, double xi, double xd, int n)
        {
            // Crear una instancia de la clase que evalúa la función
            Calculo Function = new Calculo();

            // Verificar si la función es válida y tiene 'x' como variable
            //hacer que acepte logaritmos naturales ln 
            if (funcion.Contains("ln"))
            {
                funcion = funcion.Replace("ln", "log");
            }



            if (Function.Sintaxis(funcion, 'x'))
            {
                //si la funcion tiene un logaritmo natural, cambiar la funcion para que sea compatible con la clase Calculo

                // Calcular el tamaño del subintervalo
                double h = (xd - xi) / n;
                double sum = 0.0;

                // Sumar los valores de la función en los puntos intermedios
                for (int i = 1; i < n; i++)
                {
                    double xi_actual = xi + i * h;
                    sum += Function.EvaluaFx(xi_actual);
                }

                // Calcular la integral usando la fórmula de trapecios múltiples
                double resultado = (h / 2) * (Function.EvaluaFx(xi) + 2 * sum + Function.EvaluaFx(xd));
                return resultado;
            }
            else
            {
                // Si la función no es válida
                throw new ArgumentException("Función mal ingresada");
            }
        }

        //simpson 1/3 simple
        public double CalcularIntegralSimpson1_3Simple(string funcion, double xi, double xd)
        {
            // Crear una instancia de la clase que evalúa la función
            Calculo Function = new Calculo();

            if (funcion.Contains("ln"))
            {
                funcion = funcion.Replace("ln", "log");
            }

            // Verificar si la función es válida y tiene 'x' como variable
            if (Function.Sintaxis(funcion, 'x'))
            {
                // Calcular el valor de h
                double h = (xd - xi) / 2;

                // Calcular los valores de la función en los puntos xi, xi+h y xd
                double fXi = Function.EvaluaFx(xi); // f(a)
                double fXih = Function.EvaluaFx(xi + h); // f(a+h)
                double fXd = Function.EvaluaFx(xd); // f(b)

                // Calcular el valor de la integral con la regla de Simpson 1/3
                return (h / 3) * (fXi + 4 * fXih + fXd);
            }
            else
            {
                // Si la función no es válida
                throw new ArgumentException("Función mal ingresada");
            }
        }

        // simpson 1/3 multiple
        public double CalcularIntegralSimpson1_3Multiple(string funcion, double xi, double xd, int n)
        {
            Calculo Funcion = new Calculo();

            if (funcion.Contains("ln"))
            {
                funcion = funcion.Replace("ln", "log");
            }

            if (Funcion.Sintaxis(funcion, 'x'))
            {
                double h = (xd - xi) / n;
                double sumPares = 0.0;
                double sumImpares = 0.0;
                for (int i = 1; i < n; i++)
                {
                    double xi_actual = xi + i * h;
                    if (i % 2 == 0)
                    {
                        sumPares += Funcion.EvaluaFx(xi_actual);
                    }
                    else
                    {
                        sumImpares += Funcion.EvaluaFx(xi_actual);
                    }
                }
                return (h / 3) * (Funcion.EvaluaFx(xi) + 2 * sumPares + 4 * sumImpares + Funcion.EvaluaFx(xd));
            }
            else
            {
                throw new ArgumentException("Función mal ingresada");
            }
        }

        //simoson 3/8 simple
        public double CalcularIntegralSimpson3_8Simple(string funcion, double xi, double xd)
        {
            Calculo Funcion = new Calculo();

            if (funcion.Contains("ln"))
            {
                funcion = funcion.Replace("ln", "log");
            }


            if (Funcion.Sintaxis(funcion, 'x'))
            {
                double h = (xd - xi) / 3;
                return (3 * h / 8) * (Funcion.EvaluaFx(xi) + 3 * Funcion.EvaluaFx(xi + h) + 3 * Funcion.EvaluaFx(xi + 2 * h) + Funcion.EvaluaFx(xd));
            }
            else
            {
                throw new ArgumentException("Función mal ingresada");
            }
        }

        //simpson 1/3 multiple y 3/8 multiple
        public double CalcularIntegralSimpson3_8Multiple(string funcion, double xi, double xd, int n)
        {
            Calculo Funcion = new Calculo();
            if (funcion.Contains("ln"))
            {
                funcion = funcion.Replace("ln", "log");
            }

            if (Funcion.Sintaxis(funcion, 'x'))
            {
                double h = (xd - xi) / n;
                double sumPares = 0.0;
                double sumImpares = 0.0;
                double resultado = 0.0;
                bool simpson38 = false;
                for (int i = 1; i < n; i++)
                {
                    if (n % 2 != 0 && !simpson38)
                    {
                        double nuevoXi = xi + h * (n - 3);

                        resultado = CalcularIntegralSimpson3_8Simple(funcion, nuevoXi, xd);
                        n = n - 3;
                        xd = nuevoXi;
                        simpson38 = true;
                    }
                    if (i % 2 == 0)
                    {
                        sumPares += Funcion.EvaluaFx(xi + i * h);
                    }
                    else
                    {
                        sumImpares += Funcion.EvaluaFx(xi + i * h);
                    }


                }
                double resultadoSimpson13 = (h / 3) * (Funcion.EvaluaFx(xi) + 2 * sumPares + 4 * sumImpares + Funcion.EvaluaFx(xd));

                if (simpson38)
                {
                    return resultado += resultadoSimpson13;
                }
                else
                {
                    return resultadoSimpson13;
                }

                //si simpson 3/8 se hizo, a ese resultado sumarle el resultado de simpson 1/3 multiple, sino devolver simpson 1/3 multiple

            }
            else
            {
                throw new ArgumentException("Función mal ingresada");
            }


        }

        private async void PintarFuncion()
        {

            // Reiniciar el applet de GeoGebra
            await IntegracionWeb.ExecuteScriptAsync("ggbApplet.reset()");

            // Obtener los valores de xi y xd
            double xi = double.Parse(textBoxXI.Text);
            double xd = double.Parse(textBoxXD.Text);

            // Obtener la cantidad de particiones n
            int n = 1;
            if (comboBox.SelectedIndex == 1 || comboBox.SelectedIndex == 3 || comboBox.SelectedIndex == 5)
            {
                n = int.Parse(textBoxINT.Text);
            }

            // Obtener el valor de h
            double h = (xd - xi) / n;

            // Obtener las funciones ingresadas
            string funcion1 = textBoxFUNCION.Text.Replace(",", ".");  // Asegúrate de que el formato sea compatible con GeoGebra
            string funcion2 = textBoxFUNCION2.Text.Replace(",", "."); // Segunda función

            // Dibujar la primera función f(x) en GeoGebra
            string colorFuncion = "violeta";
            await IntegracionWeb.ExecuteScriptAsync($"ggbApplet.evalCommand('f(x) = {funcion1}')");
            await IntegracionWeb.ExecuteScriptAsync($"ggbApplet.evalCommand('SetColor(f, {colorFuncion})')");



            if (!string.IsNullOrEmpty(funcion2))
            {
                // Si hay una segunda función, la dibujamos
                string colorFuncion2 = "magenta";
                await IntegracionWeb.ExecuteScriptAsync($"ggbApplet.evalCommand('g(x) = {funcion2}')");
                await IntegracionWeb.ExecuteScriptAsync($"ggbApplet.evalCommand('SetColor(g, {colorFuncion2})')");

                // Pintar el área entre las funciones f(x) y g(x)
                for (int i = 0; i < n; i++)
                {
                    double x0 = xi + i * (xd - xi) / n;
                    double x1 = xi + (i + 1) * (xd - xi) / n;

                    // La integral entre las dos funciones f(x) y g(x)
                    string color = (i % 2 == 0) ? "rojo" : "naranja";
                    await IntegracionWeb.ExecuteScriptAsync($"ggbApplet.evalCommand('Area{i + 1} = IntegralBetween(f, g, {x0.ToString().Replace(",", ".")}, {x1.ToString().Replace(",", ".")})')");
                    await IntegracionWeb.ExecuteScriptAsync($"ggbApplet.evalCommand('ShowLabel(Area{i + 1}, false)')");
                    await IntegracionWeb.ExecuteScriptAsync($"ggbApplet.evalCommand('SetColor(Area{i + 1}, {color})')");


                    await Task.Delay(100);
                }
            }
            else
            {
                // Si solo hay una función, se sombrea el área bajo la curva de f(x)
                for (int i = 0; i < n; i++)
                {
                    double x0 = xi + i * (xd - xi) / n;
                    double x1 = xi + (i + 1) * (xd - xi) / n;
                    string color = (i % 2 == 0) ? "rojo" : "naranja";

                    await IntegracionWeb.ExecuteScriptAsync($"ggbApplet.evalCommand('Area{i + 1} = Integral(f, {x0.ToString().Replace(",", ".")}, {x1.ToString().Replace(",", ".")})')");
                    await IntegracionWeb.ExecuteScriptAsync($"ggbApplet.evalCommand('SetColor(Area{i + 1}, {color} )')");
                    await IntegracionWeb.ExecuteScriptAsync($"ggbApplet.evalCommand('ShowLabel(Area{i + 1},false)')");
                    await Task.Delay(100);
                }
            }


        }

     
        private void OcultarCampos()
        {
            textBoxFUNCION2.Visible = false;
            textBoxFUNCION2.Enabled = false;
            labelFuncion2.Visible = false;
        }

        //Hacer que si el comboOperacion es "Si" se habilite el textBoxFuncion2, sino se deshabilite
        private void comboOperacion_SelectedItem(object sender, EventArgs e)
        {
            OcultarCampos();
            if (comboOperacion.SelectedItem.ToString() == "Si")
            {

                textBoxFUNCION2.Enabled = true;
                textBoxFUNCION2.Visible = true;
                labelFuncion2.Visible = true;
            }
            else
            {
                textBoxFUNCION2.Enabled = false;
                textBoxFUNCION2.Visible = false;
                labelFuncion2.Visible = false;
            }
        }


        private void BotonSalir_Click(object sender, EventArgs e)
        {
            MenuPrincipal menu = new MenuPrincipal();
            menu.Show();
            this.Hide();
        }
    }
}


