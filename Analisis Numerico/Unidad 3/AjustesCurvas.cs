using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;



namespace Analisis_Numerico
{
    public partial class AjustesCurvas : Form
    {


        public AjustesCurvas()
        {
            InitializeComponent();

            //AplicarEstilo();
            Form1_Load();
            OcultarCampo();
           
            dataGridView1.CellValueChanged += DataGridViewPuntos_CellValueChanged;
            dataGridView1.UserDeletedRow += DataGridViewPuntos_UserDeletedRow;
        }
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;



        private async void Form1_Load()
        {
            await webViewCurvas.EnsureCoreWebView2Async(null);
            webViewCurvas.Source = new Uri("https://www.geogebra.org/graphing");  // Cargar la aplicación de GeoGebra en el WebView2
        }
        private void buttonSalir_Click(object sender, EventArgs e)
        {
            MenuPrincipal menu = new MenuPrincipal();
            menu.Show();
            this.Hide();
        }

        private void buttonCalcular_Click(object sender, EventArgs e)
        {


            if (PuntosCargados.Count == 0)
            {
                MessageBox.Show("Por favor, ingrese puntos antes de calcular.");
                return;
            }

            string metodoSeleccionado = comboBoxMetodo.SelectedItem.ToString();
            string funcion = string.Empty;
            double r = 0;
            bool esEfectivo = false;

            if (metodoSeleccionado == "Regresión Lineal")
            {
                (funcion, r, esEfectivo) = CalcularRegresionLineal(PuntosCargados);
            }
            else if (metodoSeleccionado == "Regresión Polinomial")
            {
                int grado = int.Parse(textBoxGrado.Text);
                (funcion, r, esEfectivo) = CalcularRegresionPolinomial(grado, PuntosCargados);
            }


            textBoxCoeficiente.Text = $"{r.ToString("F2")}%";
            textBoxEfectividad.Text = esEfectivo ? "El ajuste es aceptable" : "El ajuste no es aceptable";
            // Mostrar la función en el TextBox
            textBoxFuncion.Text = funcion;

            PintarRectaMejorAjuste(funcion);

        }
        private async void PintarRectaMejorAjuste(string funcion)
        {


            // Limpiar la gráfica
            await webViewCurvas.ExecuteScriptAsync("ggbApplet.reset()");
            funcion = textBoxFuncion.Text.Replace(",", ".");

            // Evaluar la función
            await webViewCurvas.ExecuteScriptAsync($"ggbApplet.evalCommand('f(x) = {funcion}')");

            // Recorrer y pintar los puntos cargados
            foreach (var punto in PuntosCargados)
            {
                double x = punto[0];
                double y = punto[1];

                // Reemplazar comas por puntos en x e y
                string xStr = x.ToString().Replace(",", ".");
                string yStr = y.ToString().Replace(",", ".");

                // Agregar el punto a la gráfica
                await webViewCurvas.ExecuteScriptAsync($"ggbApplet.evalCommand('({xStr}, {yStr})')");
            }

        }



        private List<double[]> PuntosCargados = new List<double[]>();

        private void button1_Click(object sender, EventArgs e)
        {
            double x = double.Parse(textBoxX.Text);
            double y = double.Parse(textBoxY.Text);
            PuntosCargados.Add(new double[] { x, y });
            dataGridView1.Rows.Add(x, y);
            // Limpiar los TextBox después de agregar el punto
            textBoxX.Clear();
            textBoxY.Clear();
        }

        private void DataGridViewPuntos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                double x = double.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                double y = double.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());

                // Actualizamos el punto en la lista
                PuntosCargados[e.RowIndex] = new double[] { x, y };
            }


        }

        private void DataGridViewPuntos_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            int rowIndex = e.Row.Index;
            if (rowIndex >= 0 && rowIndex < PuntosCargados.Count)
            {
                PuntosCargados.RemoveAt(rowIndex);
            }
        }

        private void buttonBorraTodos_Click(object sender, EventArgs e)
        {
            //hacer que se borren todos los puntos y s filas del dataGridView
            dataGridView1.Rows.Clear();
            PuntosCargados.Clear();
        }

        private void buttonBorrarUltimo_Click(object sender, EventArgs e)
        {
            //hacer que se borre el último punto
            if (PuntosCargados.Count > 0)
            {
                PuntosCargados.RemoveAt(PuntosCargados.Count - 1);
            }
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
            }
        }

        private void comboBoxMetodo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            OcultarCampo();
            if (comboBoxMetodo.SelectedItem.ToString() == "Regresión Polinomial")
            {
                labelGrado.Visible = true;
                textBoxGrado.Visible = true;
                textBoxGrado.Enabled = true;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //hacer que se borre el punto seleccionado
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                dataGridView1.Rows.RemoveAt(index);
                PuntosCargados.RemoveAt(index);
            }
            //hacer que se actualice el dataGridView

        }






        //REGRESION POLINOMIAL
        private (string, double, bool) CalcularRegresionPolinomial(int grado, List<double[]> PuntosCargados)
        {
            int n = PuntosCargados.Count;
            double[,] matriz = new double[grado + 1, grado + 2];

            // Llenar la matriz con las sumatorias
            for (int i = 0; i <= grado; i++)
            {
                for (int j = 0; j <= grado; j++)
                {
                    matriz[i, j] = SumatoriaDePotencias(PuntosCargados, i + j);
                }

                // Columna derecha (sumatoria de X^i * Y)
                matriz[i, grado + 1] = SumatoriaDeMultiplicacion(PuntosCargados, i);
            }

            // Usar tu método para resolver el sistema con Gauss-Jordan
            double[] coeficientes = ResolverSistemaGaussJordan(matriz);

            // Si el resultado es nulo, mostramos un mensaje de error
            if (coeficientes == null)
            {
                MessageBox.Show("No se pudo obtener una solución única.");
                return (null, 0, false);
            }

            string funcion = string.Empty;

            for (int i = 0; i <= grado; i++)
            {
                double coef = coeficientes[i];

                // Solo incluir términos no nulos
                if (coef != 0)
                {
                    // Agregar el coeficiente con signo
                    if (funcion.Length > 0) // Si ya hay un término, añade el signo correspondiente
                    {
                        funcion += coef > 0 ? " + " : " - ";
                    }
                    else // Si es el primer término, no añade signo
                    {
                        // Si el coeficiente es negativo, se asegura de que se empiece con el signo correcto
                        if (coef < 0)
                        {
                            funcion += "-";
                        }
                    }

                    // Agregar el valor absoluto del coeficiente
                    funcion += Math.Abs(coef).ToString("F4");

                    // Agregar x en todos los términos
                    if (i > 0) // No agregar x para el término constante
                    {
                        funcion += $"x^{i}";
                    }
                }
            }

            // Si no hay términos, la función debe ser solo cero
            if (string.IsNullOrEmpty(funcion))
            {
                funcion = "0"; // O cualquier valor constante que desees
            }




            // Calcular el coeficiente de correlación
            double r = CalcularCoeficienteCorrelacion(PuntosCargados, coeficientes, grado);
            bool esEfectivo = r > 80; // Ajuste aceptable si r > 80%

            return (funcion, r, esEfectivo);
        }


        private double SumatoriaDePotencias(List<double[]> puntos, int potencia)
        {
            double suma = 0;
            foreach (var punto in puntos)
            {
                suma += Math.Pow(punto[0], potencia);
            }
            return suma;
        }

        private double SumatoriaDeMultiplicacion(List<double[]> puntos, int i)
        {
            double suma = 0;
            foreach (var punto in puntos)
            {
                suma += Math.Pow(punto[0], i) * punto[1];
            }
            return suma;
        }


        private double CalcularCoeficienteCorrelacion(List<double[]> puntos, double[] coeficientes, int grado)
        {
            double sumY = puntos.Sum(p => p[1]);
            double promedioY = sumY / puntos.Count;

            double st = 0, sr = 0;

            foreach (var punto in puntos)
            {
                double yCalculado = 0;
                for (int i = 0; i <= grado; i++)
                {
                    yCalculado += coeficientes[i] * Math.Pow(punto[0], i);
                }
                st += Math.Pow(punto[1] - promedioY, 2);
                sr += Math.Pow(punto[1] - yCalculado, 2);
            }

            return Math.Sqrt((st - sr) / st) * 100;
        }



        public double[] ResolverSistemaGaussJordan(double[,] matriz)
        {
            int dimension = matriz.GetLength(0);  // Número de filas (variables)
            int columns = matriz.GetLength(1);    // Número de columnas (coeficientes + término independiente)

            // Transformar la matriz en la forma escalonada
            for (int rowDiag = 0; rowDiag < dimension; rowDiag++)
            {
                double coeficienteDiagonal = matriz[rowDiag, rowDiag];

                // Verificar si el coeficiente diagonal es 0
                if (Math.Abs(coeficienteDiagonal) < 1e-10)
                {
                    bool found = false;
                    for (int row = rowDiag + 1; row < dimension; row++)
                    {
                        if (Math.Abs(matriz[row, rowDiag]) > 1e-10)
                        {
                            for (int col = 0; col < columns; col++)
                            {
                                double temp = matriz[rowDiag, col];
                                matriz[rowDiag, col] = matriz[row, col];
                                matriz[row, col] = temp;
                            }
                            coeficienteDiagonal = matriz[rowDiag, rowDiag];
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        MessageBox.Show("El sistema no tiene solución única o tiene infinitas soluciones.");
                        return null;
                    }
                }

                for (int col = 0; col < columns; col++)
                {
                    matriz[rowDiag, col] /= coeficienteDiagonal;
                }

                for (int row = 0; row < dimension; row++)
                {
                    if (row != rowDiag)
                    {
                        double coeficienteCero = matriz[row, rowDiag];
                        for (int col = 0; col < columns; col++)
                        {
                            matriz[row, col] -= coeficienteCero * matriz[rowDiag, col];
                        }
                    }
                }
            }


            double[] vectorResultado = new double[dimension];
            for (int i = 0; i < dimension; i++)
            {
                vectorResultado[i] = matriz[i, columns - 1];
            }

            return vectorResultado;
        }

        //REGRESION LINEAL
        private (string, double, bool) CalcularRegresionLineal(List<double[]> PuntosCargados)
        {
            double sumX = PuntosCargados.Sum(p => p[0]);
            double sumY = PuntosCargados.Sum(p => p[1]);
            double sumXY = PuntosCargados.Sum(p => p[0] * p[1]);
            double sumX2 = PuntosCargados.Sum(p => p[0] * p[0]);
            double n = PuntosCargados.Count;

            // Cálculo de la pendiente (m) y la intersección (b)
            double m = (n * sumXY - sumX * sumY) / (n * sumX2 - sumX * sumX);
            double b = (sumY - m * sumX) / n;

            // Construir la ecuación de la recta tener en cuenta el signo
            string funcion = $"{m.ToString("F4")}x {(b > 0 ? "+" : "-")} {Math.Abs(b).ToString("F4")}";




            // Cálculo del coeficiente de correlación
            double r = CalcularCoeficienteCorrelacion(PuntosCargados, new double[] { b, m }, 1);
            bool esEfectivo = r > 80; // Ajuste aceptable si r > 80%

            return (funcion, r, esEfectivo);
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


        //hacer que si el metodo es regresion lineal se esconda el grado
        public void OcultarCampo()
        {
            //ocultar el campo de grado
            labelGrado.Visible = false;
            textBoxGrado.Visible = false;
            textBoxGrado.Enabled = false;
        }

        private void dataGridViewPuntos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AjustesCurvas_Load(object sender, EventArgs e)
        {

        }

        private void labelGrado_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}

