using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Wordle
{
    public partial class MainWindow : Window
    {
        // Creamos las instancias de clase y las variables necesarias para que sean accesibles desde cualquier método del Main.
        public Gestor gestor = new Gestor();
        public Estadistica estadistica = new Estadistica();
        public Estadisticas est;
        Grid g;
        Button botonEnviar, botonRendirse, botonPista;
        TextBox[,] letras;
        public int numLetras;
        int numIntento;
        string palabraGenerada = "";
        int auxiliarStop = 0;
        public MainWindow()
        {
            InitializeComponent();
            estadistica.LeerDatos(); // Llamamos al método de la clase estadistica LeerDatos() para que nada más inicializar, lea el documento txt y cargue los datos.
            est = new Estadisticas(estadistica);
        }

        private void Estadisticas(object sender, RoutedEventArgs e)
        {
            Estadisticas estadisticas = new Estadisticas(estadistica);
            estadisticas.Show();
        }
        private void Tienda(object sender, RoutedEventArgs e)
        {
            Tienda tienda = new Tienda(estadistica);
            tienda.Show();
        }

        private void CrearGrid(object sender, RoutedEventArgs e)
        {
            if (estadistica.Vidas > 0) // Si el jugador tiene suficientes vidas, podrá jugar.
            {
                numLetras = int.Parse(tbNumLetras.Text); // Convertimos el entero introducido a string.
                if (numLetras >= 5 && numLetras <= 10) // Si el número introducido es válido, entramos en la condición.
                {
                    letras = new TextBox[numLetras, 6]; // Declaramos la matriz.
                    estadistica.PartidasJugadas++; // Incrementamos el número de partida.
                    numIntento = 0; // Inicializamos los intentos a 0.
                    palabraGenerada = gestor.GenerarPalabra(numLetras); // Generamos la palabra aleatoria.
                    g = new Grid();
                    botonEnviar = new Button();
                    Estilizar(botonEnviar, "ENVIAR");
                    botonEnviar.HorizontalAlignment = HorizontalAlignment.Right;
                    botonEnviar.Click += BotonComprobar;
                    botonRendirse = new Button();
                    Estilizar(botonRendirse, "RENDIRSE");
                    botonRendirse.HorizontalAlignment = HorizontalAlignment.Left;
                    botonRendirse.Click += BotonRendirse;
                    botonPista = new Button();
                    Estilizar(botonPista, "USAR PISTA");
                    botonPista.HorizontalAlignment = HorizontalAlignment.Center;
                    botonPista.Click += UsarPista;
                    Grid.SetRow(botonEnviar, 4);
                    Grid.SetRow(botonRendirse, 4);
                    Grid.SetRow(botonPista, 4);
                    juego.Children.Add(botonEnviar);
                    juego.Children.Add(botonRendirse);
                    juego.Children.Add(botonPista);
                    g.Margin = new Thickness(5);
                    for (int i = 0; i < numLetras; i++)
                    {
                        g.ColumnDefinitions.Add(new ColumnDefinition()); // Creamos las columnas.
                    }
                    for (int j = 0; j < letras.GetLength(1); j++)
                    {
                        g.RowDefinitions.Add(new RowDefinition()); // Creamos las filas.
                    }
                    for (int i = 0; i < letras.GetLength(1); i++)
                    {
                        for (int j = 0; j < numLetras; j++)
                        {
                            TextBox t = new TextBox();
                            t.TextChanged += LetraSiguiente;
                            t.TextChanged += LetraAnterior;
                            t.MaxLength = 1;
                            t.Margin = new Thickness(3);
                            t.FontSize = 60;
                            t.TextAlignment = TextAlignment.Center;
                            t.CharacterCasing = CharacterCasing.Upper; // Convertimos visualmente las letras a mayúsculas.
                            letras[j, i] = t; // Asignamos los textbox a la matriz.
                            if (i == 0)
                            {
                                letras[j, i].IsEnabled = true; // El primer textbox es accesible.
                            }
                            else
                            {
                                letras[j, i].IsEnabled = false; // El resto será innacesible.
                            }
                            Grid.SetColumn(t, j);
                            Grid.SetRow(t, i);
                            g.Children.Add(t);
                        }
                    }
                    Grid.SetRow(g, 3);
                    juego.Children.Add(g);
                    letras[numIntento, 0].Focus(); // Hacemos focus en el primer puesto.
                }
                else
                {
                    MessageBox.Show("La palabra debe contener entre 5 y 10 letras.");
                }
            }
            else
            {
                MessageBox.Show("No te quedan vidas.");
            }
        }
        public void Estilizar(Button b, string contenido) // Estilización de textbox.
        {
            b.Content = contenido;
            b.Height = 30;
            b.Width = 150;
            b.Margin = new Thickness(5);
            b.BorderBrush = Brushes.Black;
        }
        public async void Pintar()
        {
            for (int i = 0; i < numLetras; i++) // Recorremos la fila.
            {
                letras[i, numIntento].Background = new SolidColorBrush(Colors.DimGray); // La pintamos de gris.
                await Task.Delay(2000);
                if (gestor.TransformarMinus(gestor.PalabraInsertada(numLetras, numIntento, letras))[i] == palabraGenerada[i])
                {
                    // Si la primera letra de la palabra introducida y la primera letra de la palabra oculta COINCIDEN, se pinta de verde.
                    letras[i, numIntento].Background = new SolidColorBrush(Colors.ForestGreen);
                }
                else
                {
                    for (int j = 0; j < numLetras; j++)
                    {
                        // Si no, se comprueba si esa letra, es parte de la palabra oculta.
                        if (gestor.TransformarMinus(gestor.PalabraInsertada(numLetras, numIntento, letras))[i] == palabraGenerada[j])
                        {
                            // De ser así, se pinta de amarillo.
                            letras[i, numIntento].Background = new SolidColorBrush(Colors.DarkGoldenrod);
                        }
                    }
                }
                letras[i, numIntento].Foreground = new SolidColorBrush(Colors.White);
            }
        }
        private void UsarPista(object sender, RoutedEventArgs e)
        {
            if (estadistica.Pistas > 0) // Si el usuario tiene pistas, entra en la condición.
            {
                Random rnd = new Random();
                char pista;
                int letraRandom = rnd.Next(0, numLetras); // Generamos un número random.
                pista = palabraGenerada[letraRandom]; // El número random será la posición de la letra de la palabra oculta.
                estadistica.Pistas--; // Restamos la pista usada.
                MessageBox.Show($"La pista es: {pista}");
            }
            else
            {
                MessageBox.Show("No te quedan pistas.");
            }
        }

        private void BotonComprobar(object sender, RoutedEventArgs e)
        {
            if (gestor.Pertenece(numLetras, numIntento, letras)) // Si la palabra introducida forma parte del diccionario.
            {
                Pintar(); // Pintamos.
                if (gestor.TransformarMinus(gestor.PalabraInsertada(numLetras, numIntento, letras)) == palabraGenerada && numIntento != 5)
                {
                    Victoria(); // Si todo coincide, victoria.
                }
                if (numIntento == 5)
                {
                    if (gestor.TransformarMinus(gestor.PalabraInsertada(numLetras, numIntento, letras)) == palabraGenerada) // Si en el último intento, acierta, victoria.
                    {
                        Victoria();
                    }
                    else
                    {
                        // Sino, pierde.
                        BotonRendirse(sender, e);
                    }
                }
                numIntento++;
                auxiliarStop = 0; // Este auxiliar sirve para redirigir el foco al siguiente textbox.
                gestor.MoverFila(numIntento, letras); // Se bloquea la fila y se desbloquea la siguiente.
                if(numIntento < 6)
                {
                    letras[0, numIntento].Focus();
                }
            }
            else
            {
                MessageBox.Show("La palabra introducida no existe.");
                letras[letras.GetLength(0) - 1, numIntento].Focus();
            }
        }
        private void LetraSiguiente(object sender, RoutedEventArgs e) // Método para pasar automáticamente al siguiente textbox cuando éste ha sido rellenado.
        {
            if (auxiliarStop < numLetras - 1)
            {
                if (((TextBox)sender).MaxLength == ((TextBox)sender).Text.Length)
                {
                    var tb = e.OriginalSource as FrameworkElement;
                    tb.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                    auxiliarStop++;
                }
            }
        }
        public void LetraAnterior(object sender, RoutedEventArgs e)
        {
            if (((TextBox)sender).MaxLength > ((TextBox)sender).Text.Length || ((TextBox)sender).Text.Length == 0)
            {
                if (auxiliarStop > 0)
                {
                    var tb = e.OriginalSource as FrameworkElement;
                    tb.MoveFocus(new TraversalRequest(FocusNavigationDirection.Previous));
                    auxiliarStop--;
                }
            }
        }
        private void BotonRendirse(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Has perdido. La palabra oculta era: {palabraGenerada}", "Wordle"); 
            estadistica.RachaActual = 0; // La racha actual pasa a ser 0 ya que el usuario se ha rendido.
            estadistica.Vidas--; // Se resta una vida.
            estadistica.SobreescribirDatos(); // Se sobreescriben los datos para evitar pérdidas.
            RemoverElementos(botonEnviar, botonPista, botonRendirse, g); // Se remueven todos los elementos del grid y él incluido.
        }
        public void Victoria()
        {
            estadistica.NumVictorias++; // Se suma una victoria.
            estadistica.RachaActual++; // La racha actual aumenta.
            int cifraGanada = 0; // Variable que cambia de valor según los intentos que necesite el usuario para adivinar la palabra.
            if (numIntento < 2)
            {
                cifraGanada = 1000;
            }
            else if (numIntento >= 2 && numIntento < 4)
            {
                cifraGanada = 500;
            }
            else
            {
                cifraGanada = 250;
            }
            estadistica.Puntos += cifraGanada;
            estadistica.SobreescribirDatos();
            MessageBox.Show($"CORRECTO. \n HAS GANADADO {cifraGanada} PUNTOS", "Wordle");
            RemoverElementos(botonEnviar, botonPista, botonRendirse, g);
        }
        public void RemoverElementos(Button a, Button b, Button c, Grid g)
        {
            juego.Children.Remove(a);
            juego.Children.Remove(b);
            juego.Children.Remove(c);
            juego.Children.Remove(g);
        }
    }
}
