
using System.Runtime.CompilerServices;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Analisis_Numerico.Unidad_2;
using Analisis_Numerico.Unidad_4;
namespace Analisis_Numerico
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void InitializeCustomComponents()
        {
            // Estilo y apariencia general
            this.Text = "Menú Principal - Análisis Numérico";
            this.BackColor = Color.FromArgb(44, 62, 80);
            this.FormBorderStyle = FormBorderStyle.None; // Quitar el borde de la ventana
            this.Padding = new Padding(2); // Añadir un padding para el borde personalizado
            //this.AutoSize = true; // Tamaño personalizado
            this.Size = new Size(1000, 900); // Tamaño personalizado
            this.CenterToScreen();
            this.MaximizeBox = true;

            this.StartPosition = FormStartPosition.CenterScreen;

            // Crear un Panel para actuar como la barra de título
            Panel tituloBarra = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50,
                BackColor = Color.FromArgb(52, 73, 94) // Color del fondo de la barra de título
            };
            Label tituloEtiqueta = new Label
            {
                Text = "Menú Principal - Análisis Numérico",
                ForeColor = Color.White,
                Dock = DockStyle.Left,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(5, 0, 0, 0),
                Font = new Font("Arial", 10, FontStyle.Bold),
                AutoSize = true
            };
            Button botonCerrar = new Button
            {
                Text = "X",
                Dock = DockStyle.Right,
                Width = 50,
                ForeColor = Color.White,
                BackColor = Color.FromArgb(231, 76, 60),
                FlatStyle = FlatStyle.Flat
            };
            botonCerrar.FlatAppearance.BorderSize = 0;
            botonCerrar.Click += (s, e) =>
            {
                Application.Exit();
            }; // Cerrar la ventana al hacer clic
            Button botonMaximizar = new Button
            {
                Text = "□",
                Dock = DockStyle.Right,
                Width = 50,
                ForeColor = Color.White,
                BackColor = Color.FromArgb(52, 73, 94),
                FlatStyle = FlatStyle.Flat
            };
            botonMaximizar.FlatAppearance.BorderSize = 0;
            botonMaximizar.Click += (s, e) =>
            {
                this.WindowState = this.WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
            };
            Button botonMinimizar = new Button
            {
                Text = "-",
                Dock = DockStyle.Right,
                Width = 50,
                ForeColor = Color.White,
                BackColor = Color.FromArgb(52, 73, 94),
                FlatStyle = FlatStyle.Flat
            };
            botonMinimizar.FlatAppearance.BorderSize = 0;
            botonMinimizar.Click += (s, e) => this.WindowState = FormWindowState.Minimized;

            // Agregar los botones al panel de la barra de título
            tituloBarra.Controls.Add(tituloEtiqueta);
            tituloBarra.Controls.Add(botonMinimizar);
            tituloBarra.Controls.Add(botonMaximizar);
            tituloBarra.Controls.Add(botonCerrar);

            // Agregar la barra de título personalizada al formulario
            this.Controls.Add(tituloBarra);

            // Conectar eventos para mover la ventana
            tituloBarra.MouseDown += tituloBarra_MouseDown;
            tituloBarra.MouseMove += tituloBarra_MouseMove;
            tituloBarra.MouseUp += tituloBarra_MouseUp;

            // Layout y configuración de botones
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,

            };
            this.Controls.Add(tableLayoutPanel);

            // Configurar las proporciones de las filas
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F)); // Espacio superior
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F)); // Espacio para el título
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 80F)); // Espacio para los botones
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 80F)); // Espacio inferior

            // Título del formulario
            Label titleLabel = new Label
            {
                Text = "Menú Principal",
                Font = new Font("Arial", 26, FontStyle.Bold),
                ForeColor = Color.FromArgb(236, 240, 241),
                AutoSize = true,
                Anchor = AnchorStyles.None
            };
            tableLayoutPanel.Controls.Add(titleLabel, 1, 1);



            // Panel para botones
            FlowLayoutPanel buttonPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Anchor = AnchorStyles.None
            };
            tableLayoutPanel.Controls.Add(buttonPanel, 4, 2);

            // Botón de Calculadora de Raíces
            Button btnCalculadora = new Button
            {
                Text = "Calculadora de Raíces",
                Font = new Font("Arial", 12, FontStyle.Regular),
                Size = new Size(900, 100),
                BackColor = Color.FromArgb(231, 76, 60),
                ForeColor = Color.FromArgb(255, 255, 255),
                FlatStyle = FlatStyle.Flat
            };
            btnCalculadora.FlatAppearance.BorderSize = 0;
            btnCalculadora.Click += (sender, e) =>
            {
                CalculadoraDeRaices calculadoraRaices = new CalculadoraDeRaices();
                calculadoraRaices.Show();
                this.Hide();
            };
            buttonPanel.Controls.Add(btnCalculadora);

            // Botón de Sistema de Ecuaciones
            Button btnEcuaciones = new Button
            {
                Text = "Sistema de Ecuaciones",
                Font = new Font("Arial", 12, FontStyle.Regular),
                Size = new Size(900, 100),
                BackColor = Color.FromArgb(231, 76, 60),
                ForeColor = Color.FromArgb(255, 255, 255),
                FlatStyle = FlatStyle.Flat
            };
            btnEcuaciones.FlatAppearance.BorderSize = 0;
            btnEcuaciones.Click += (sender, e) =>
            {
                SistemaDeEcuaciones SistemaDeEcuaciones = new SistemaDeEcuaciones();
                SistemaDeEcuaciones.Show();
                this.Hide();
            };
            buttonPanel.Controls.Add(btnCalculadora);
            buttonPanel.Controls.Add(btnEcuaciones);

            // Botón de Ajustes de Curvas
            Button btnCurvas = new Button
            {
                Text = "Ajustes de Curvas",
                Font = new Font("Arial", 12, FontStyle.Regular),
                Size = new Size(900, 100),
                BackColor = Color.FromArgb(231, 76, 60),
                ForeColor = Color.FromArgb(255, 255, 255),
                FlatStyle = FlatStyle.Flat
            };
            btnCurvas.FlatAppearance.BorderSize = 0;
            btnCurvas.Click += (sender, e) =>
            {
                AjustesCurvas ajusteDeCurvas = new AjustesCurvas();
                ajusteDeCurvas.Show();
                this.Hide();
            };
            buttonPanel.Controls.Add(btnCurvas);

            // Botón de Integración Numérica
            Button btnIntegracion = new Button
            {
                Text = "Integración Numérica",
                Font = new Font("Arial", 12, FontStyle.Regular),
                Size = new Size(900, 100),
                BackColor = Color.FromArgb(231, 76, 60),
                ForeColor = Color.FromArgb(255, 255, 255),
                FlatStyle = FlatStyle.Flat
            };
            btnIntegracion.FlatAppearance.BorderSize = 0;
            btnIntegracion.Click += (sender, e) =>
            {
                IntegracionNumerica integracionNumerica = new IntegracionNumerica();
                integracionNumerica.Show();
                this.Hide();
            };
            buttonPanel.Controls.Add(btnIntegracion);

            // Botón de Salir
            Button btnSalir = new Button
            {
                Text = "Salir",
                Font = new Font("Arial", 12, FontStyle.Regular),
                Size = new Size(900, 100),
                BackColor = Color.FromArgb(100, 195, 230),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.Click += (sender, e) =>
            {
                Application.Exit();
            };
            buttonPanel.Controls.Add(btnSalir);
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

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}








