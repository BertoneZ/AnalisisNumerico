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

namespace Analisis_Numerico.Unidad_2
{
    public partial class SistemaDeEcuaciones : Form
    {
        private Color fondo = Color.FromArgb(44, 62, 80); // Fondo oscuro
        private Color boton = Color.FromArgb(231, 76, 60); // Botón
        private Color textoBoton = Color.FromArgb(255, 255, 255); // Texto del botón
        private Color texto = Color.FromArgb(28, 28, 28); // Texto
        private Color borde = Color.FromArgb(52, 73, 94); // Bordes

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private TextBox[] solTextBoxes;
        private TextBox[,] matrixTextBoxes;  // Matriz de TextBox para ingresar coeficientes
        private TextBox[] resultTextBoxes;
        private Label[] resultLabels;
        // Declare the field at the class level

        private int rows, columns;
        public SistemaDeEcuaciones()
        {
            InitializeComponent();
            AplicarEstilo();
            OcultarCampos();
            botonGenerar.Click += botonGenerar_Click;
            BotonSalir.Click += BotonSalir_Click;

            this.FormBorderStyle = FormBorderStyle.None; // Quitar el borde de la ventana
            this.Padding = new Padding(2);
            this.Size = new Size(800, 600);
        }
        public void OcultarCampos()
        {
            ToleranciaLabel.Visible = false;
            texboxTolerancia.Visible = false;
            IteracionesLabel.Visible = false;
            textBoxIteraciones.Visible = false;


            texboxTolerancia.Enabled = false;

            textBoxIteraciones.Enabled = false;
        }

        private void botonGenerar_Click(object sender, EventArgs e)
        {

            try
            {
                rows = int.Parse(textBoxRows.Text); // Número de ecuaciones (filas)
                columns = rows; // Número de variables (columnas)

                int pointX = 30;
                int pointY = 40;
                int spacingX = 100; // Espacio horizontal entre TextBoxes
                int spacingY = 40; // Espacio vertical entre TextBoxes
                int resultSpacingX = 20;
                int spacingSol = 190; // Espacio entre las soluciones

                panel2.Controls.Clear(); // Limpiar el panel antes de agregar nuevos controles
                matrixTextBoxes = new TextBox[rows, columns]; // Inicializar la matriz de TextBoxes para coeficientes
                resultTextBoxes = new TextBox[rows]; // Inicializar el arreglo de TextBoxes para los resultados

                // Crear los TextBoxes para los coeficientes y términos independientes
                for (int row = 0; row < rows; row++)
                {
                    // Crear TextBoxes para los coeficientes
                    for (int col = 0; col < columns; col++)
                    {
                        TextBox a = new TextBox();
                        a.Text = "0"; // Valor por defecto
                        a.Size = new Size(80, 25); // Ajustar tamaño de cada TextBox
                        a.Location = new Point(pointX + col * spacingX, pointY + row * spacingY); // Posicionar TextBoxes
                        panel2.Controls.Add(a);
                        matrixTextBoxes[row, col] = a; // Guardar cada TextBox en la matriz
                    }

                    // Crear el Label "=" antes del TextBox del término independiente
                    Label equalsLabel = new Label();
                    equalsLabel.Text = "=";
                    equalsLabel.ForeColor = Color.White;
                    equalsLabel.Size = new Size(20, 25);
                    equalsLabel.Location = new Point(pointX + columns * spacingX + resultSpacingX - 20, pointY + row * spacingY);
                    panel2.Controls.Add(equalsLabel);

                    // Crear TextBox para el término independiente (resultado)
                    TextBox result = new TextBox();
                    result.Text = "0"; // Valor por defecto
                    result.Size = new Size(80, 25); // Ajustar tamaño del TextBox
                    result.Location = new Point(pointX + columns * spacingX + resultSpacingX + 20, pointY + row * spacingY); // Ajustar la posición del TextBox del término independiente
                    panel2.Controls.Add(result);
                    resultTextBoxes[row] = result;
                }
                // Inside the botonGenerar_Click method, remove the field declaration and just initialize the array
                solTextBoxes = new TextBox[columns];
                for (int i = 0; i < columns; i++)
                {
                    TextBox solutionBox = new TextBox();
                    solutionBox.Text = ""; // Vacío inicialmente
                    solutionBox.Size = new Size(160, 25);
                    solutionBox.Location = new Point(pointX + i * spacingSol, pointY + rows * spacingY + 50); // Debajo de los demás TextBoxes
                    panel2.Controls.Add(solutionBox);
                    solTextBoxes[i] = solutionBox;
                }

                panel2.Show(); // Mostrar el panel con los TextBoxes
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private double[] SolveGaussJordan(double[,] matrix)
        {
            int dimension = matrix.GetLength(0);  // Número de filas (variables)
            int columns = matrix.GetLength(1);    // Número de columnas (coeficientes + término independiente)

            // Paso 1: Transformar la matriz en la forma escalonada
            for (int rowDiag = 0; rowDiag < dimension; rowDiag++)
            {
                // Paso 2.a: Obtener el coeficiente de la diagonal principal
                double coeficienteDiagonal = matrix[rowDiag, rowDiag];

                // Verificar si el coeficiente diagonal es 0 y si es así, buscar una fila con un coeficiente no nulo
                if (Math.Abs(coeficienteDiagonal) < 1e-10) // Considerar una tolerancia para evitar divisiones por cero
                {
                    bool found = false;
                    for (int row = rowDiag + 1; row < dimension; row++)
                    {
                        if (Math.Abs(matrix[row, rowDiag]) > 1e-10) // Buscar un coeficiente no nulo
                        {
                            // Intercambiar filas
                            for (int col = 0; col < columns; col++)
                            {
                                double temp = matrix[rowDiag, col];
                                matrix[rowDiag, col] = matrix[row, col];
                                matrix[row, col] = temp;
                            }
                            coeficienteDiagonal = matrix[rowDiag, rowDiag];
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        // Si no se encuentra una fila adecuada, el sistema es singular o tiene infinitas soluciones
                        MessageBox.Show("El sistema no tiene solución única o tiene infinitas soluciones.");
                        return null;
                    }
                }

                // Paso 2.b: Normalizar la fila del pivote
                for (int col = 0; col < columns; col++)
                {
                    matrix[rowDiag, col] /= coeficienteDiagonal;
                }

                // Paso 2.c: Hacer ceros en la columna del pivote para las demás filas
                for (int row = 0; row < dimension; row++)
                {
                    if (row != rowDiag)
                    {
                        double coeficienteCero = matrix[row, rowDiag];
                        for (int col = 0; col < columns; col++)
                        {
                            matrix[row, col] -= coeficienteCero * matrix[rowDiag, col];
                        }
                    }
                }
            }

            // Paso 3: Extraer los resultados
            double[] vectorResultado = new double[dimension];
            for (int i = 0; i < dimension; i++)
            {
                vectorResultado[i] = matrix[i, columns - 1]; // Última columna son los resultados
            }

            return vectorResultado;
        }

        private void botonCalcular_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Inicializar la matriz aumentada (coeficientes + término independiente)
                double[,] matrix = new double[rows, columns + 1]; // Matriz aumentada con espacio para el término independiente

                // Obtener los valores ingresados en los TextBoxes
                for (int row = 0; row < rows; row++)
                {
                    // Obtener los coeficientes de cada fila
                    for (int col = 0; col < columns; col++)
                    {
                        double value;
                        if (double.TryParse(matrixTextBoxes[row, col].Text, out value))
                        {
                            matrix[row, col] = value; // Guardar el valor en la matriz aumentada
                        }
                        else
                        {
                            MessageBox.Show($"Valor inválido en la posición ({row + 1}, {col + 1})");
                            return;
                        }
                    }

                    // Guardar el término independiente en la última columna de la matriz aumentada
                    double result;
                    if (double.TryParse(resultTextBoxes[row].Text, out result))
                    {
                        matrix[row, columns] = result; // La última columna es para el término independiente
                    }
                    else
                    {
                        MessageBox.Show($"Valor inválido en el resultado de la fila {row + 1}");
                        return;
                    }
                }

                // Seleccionar el método
                string selectedMethod = comboBoxMethod.SelectedItem.ToString();
                double[] solution = null;

                if (selectedMethod == "Gauss-Jordan")
                {
                    solution = SolveGaussJordan(matrix);
                }
                else if (selectedMethod == "Gauss-Seidel")
                {
                    solution = SolveGaussSeidel(matrix);
                }

                if (solution != null)
                {
                    for (int i = 0; i < solution.Length; i++)
                    {
                        string variableName = $"x{i + 1}"; // Nombre de la variable (x1, x2, x3, ...)
                        solTextBoxes[i].Text = $"{variableName} = {solution[i].ToString("F8")}";
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private double[] SolveGaussSeidel(double[,] matrix)
        {
            //int dimension = matrix.GetLength(0);  // Número de filas (variables)
            //double[] x = new double[dimension];   // Vector inicial de soluciones
            //double[] previousX = new double[dimension];  // Para comparar las soluciones previas
            //int maxIterations = int.Parse(textBoxIteraciones.Text);
            //double tolerance = double.Parse(texboxTolerancia.Text);
            //double[] errorRelativo = new double[dimension];  // Vector para almacenar errores relativos

            //bool hasConverged = true;
            //for (int iter = 0; iter < maxIterations; iter++)
            //{
            //    for (int i = 0; i < dimension; i++)
            //    {
            //        previousX[i] = x[i];  // Guardar el valor previo
            //    }

            //    for (int i = 0; i < dimension; i++)
            //    {
            //        if (matrix[i, i] == 0)
            //        {
            //            // Buscar fila con coeficiente no cero en la columna i
            //            for (int k = i + 1; k < dimension; k++)
            //            {
            //                if (matrix[k, i] != 0)
            //                {
            //                    // Intercambiar filas i y k
            //                    for (int j = 0; j <= dimension; j++)
            //                    {
            //                        double temp = matrix[i, j];
            //                        matrix[i, j] = matrix[k, j];
            //                        matrix[k, j] = temp;
            //                    }
            //                    break;
            //                }
            //            }
            //        }
            //    }

            //    // Iterar sobre cada ecuación
            //    for (int i = 0; i < dimension; i++)
            //    {
            //        double sum = matrix[i, dimension]; // Término independiente

            //        // Resta de los coeficientes conocidos
            //        for (int j = 0; j < dimension; j++)
            //        {
            //            if (i != j)
            //            {
            //                sum -= matrix[i, j] * x[j];
            //            }
            //        }

            //        // Actualizar la variable
            //        x[i] = sum / matrix[i, i];
            //    }

            //    // Comprobar si las soluciones convergen y calcular error relativo

            //    for (int i = 0; i < dimension; i++)
            //    {
            //        // Calcular error relativo solo si x[i] no es 0 para evitar división por 0
            //        if (x[i] != 0)
            //        {
            //            errorRelativo[i] = Math.Abs((x[i] - previousX[i]) / x[i]);
            //        }
            //        else
            //        {
            //            errorRelativo[i] = 0;
            //        }

            //        if (errorRelativo[i] > tolerance)  // Comparar error relativo con la tolerancia
            //        {
            //            hasConverged = false;
            //        }
            //    }

            //    if (hasConverged)
            //    {
            //        break;
            //    }
            //}
            //if (!hasConverged)
            //{
            //    MessageBox.Show("El sistema no ha convergido dentro del número máximo de iteraciones permitidas.", "Convergencia no alcanzada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}

            //return x;

            //ESTE ES EL CODIGO QUE USE PARA EL TP (EL CODIGO QUE APARECE ABAJO, EL DE ARRIBA ES UN CODIGO DE SALVACION)
            int dimension = matrix.GetLength(0);  // Número de filas (variables)
            double[] x = new double[dimension];   // Vector inicial de soluciones
            double[] previousX = new double[dimension];  // Para comparar las soluciones previas
            int maxIterations = int.Parse(textBoxIteraciones.Text);
            double tolerance = double.Parse(texboxTolerancia.Text);
            double[] errorRelativo = new double[dimension];  // Vector para almacenar errores relativos

            // Realizar pivotaje para evitar ceros en la diagonal principal
            for (int i = 0; i < dimension; i++)
            {
                if (matrix[i, i] == 0)
                {
                    bool swapped = false;

                    // Buscar fila con coeficiente no cero en la columna i
                    for (int k = i + 1; k < dimension; k++)
                    {
                        if (matrix[k, i] != 0)
                        {
                            // Intercambiar filas i y k
                            for (int j = 0; j <= dimension; j++)
                            {
                                double temp = matrix[i, j];
                                matrix[i, j] = matrix[k, j];
                                matrix[k, j] = temp;
                            }
                            swapped = true;
                            break;
                        }
                    }

                    // Si no se pudo intercambiar, mostrar mensaje de error y terminar
                    if (!swapped)
                    {
                        MessageBox.Show($"No se pudo hacer pivotaje en la fila {i + 1}. La matriz es singular o mal definida.", "Error de Pivotaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
                }
            }

            bool hasConverged = false;
            for (int iter = 0; iter < maxIterations; iter++)
            {
                // Guardar el valor previo para el cálculo del error
                for (int i = 0; i < dimension; i++)
                {
                    previousX[i] = x[i];
                }

                // Iterar sobre cada ecuación
                for (int i = 0; i < dimension; i++)
                {
                    double sum = matrix[i, dimension]; // Término independiente

                    // Resta de los coeficientes conocidos
                    for (int j = 0; j < dimension; j++)
                    {
                        if (i != j)
                        {
                            sum -= matrix[i, j] * x[j];
                        }
                    }

                    // Verificar si el coeficiente en la diagonal es cero después del pivotaje
                    if (matrix[i, i] == 0)
                    {
                        MessageBox.Show($"Coeficiente cero en la diagonal en la fila {i + 1} después del pivotaje. No se puede resolver el sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }

                    // Actualizar la variable con el valor más reciente
                    x[i] = sum / matrix[i, i];
                }

                // Comprobar si las soluciones convergen y calcular error relativo
                hasConverged = true;
                for (int i = 0; i < dimension; i++)
                {
                    // Calcular error relativo
                    double absDifference = Math.Abs(x[i] - previousX[i]);
                    double absCurrent = Math.Abs(x[i]);

                    if (absCurrent > 1e-10)  // Para evitar problemas con números muy pequeños
                    {
                        errorRelativo[i] = absDifference / absCurrent;
                    }
                    else
                    {
                        errorRelativo[i] = absDifference;  // Evitar división por cero
                    }

                    // Comprobar si el error relativo está dentro de la tolerancia
                    if (errorRelativo[i] > tolerance)
                    {
                        hasConverged = false;
                    }
                }

                // Si se cumple la condición de tolerancia, se considera que ha convergido
                if (hasConverged)
                {
                    break;
                }
            }

            // Si no ha convergido después del número máximo de iteraciones, mostrar un mensaje de advertencia
            if (!hasConverged)
            {
                MessageBox.Show("El sistema no ha convergido dentro del número máximo de iteraciones permitidas.", "Convergencia no alcanzada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return x;
        }

        private void BotonSalir_Click(object sender, EventArgs e)
        {
            MenuPrincipal menu = new MenuPrincipal();
            menu.Show();
            this.Hide();
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
        public void AplicarEstilo()
        {
            this.BackColor = fondo;

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
            tituloEtiqueta.Text = "Sistema de Ecuaciones - Análisis Numérico";
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

            botonCalcular.BackColor = boton;
            botonCalcular.ForeColor = textoBoton;
            botonCalcular.FlatStyle = FlatStyle.Flat;
            botonCalcular.Size = new Size(120, 50);
            botonCalcular.FlatAppearance.BorderSize = 0;
            botonCalcular.MouseEnter += (s, e) => botonCalcular.BackColor = Color.FromArgb(204, 60, 49); // Efecto hover
            botonCalcular.MouseLeave += (s, e) => botonCalcular.BackColor = boton;

            BotonSalir.BackColor = boton;
            BotonSalir.ForeColor = textoBoton;
            BotonSalir.FlatStyle = FlatStyle.Flat;
            BotonSalir.Size = new Size(120, 50);
            BotonSalir.FlatAppearance.BorderSize = 0;
            BotonSalir.MouseEnter += (s, e) => BotonSalir.BackColor = Color.FromArgb(204, 60, 49); // Efecto hover
            BotonSalir.MouseLeave += (s, e) => BotonSalir.BackColor = boton;

            botonGenerar.BackColor = boton;
            botonGenerar.ForeColor = textoBoton;
            botonGenerar.FlatStyle = FlatStyle.Flat;
            botonGenerar.Size = new Size(150, 50);
            botonGenerar.FlatAppearance.BorderSize = 0;
            botonGenerar.MouseEnter += (s, e) => botonGenerar.BackColor = Color.FromArgb(204, 60, 49); // Efecto hover
            botonGenerar.MouseLeave += (s, e) => botonGenerar.BackColor = boton;

        }

        private void comboBoxMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            OcultarCampos();

            if (comboBoxMethod.SelectedIndex == 1)
            {
                ToleranciaLabel.Visible = true;
                texboxTolerancia.Visible = true;
                IteracionesLabel.Visible = true;
                textBoxIteraciones.Visible = true;


                texboxTolerancia.Enabled = true;

                textBoxIteraciones.Enabled = true;
            }
            else
            {
                ToleranciaLabel.Visible = false;
                texboxTolerancia.Visible = false;
                IteracionesLabel.Visible = false;
                textBoxIteraciones.Visible = false;


                texboxTolerancia.Enabled = false;

                textBoxIteraciones.Enabled = false;
            }





        }

    }
}

