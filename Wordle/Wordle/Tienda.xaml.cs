using System.Windows;

namespace Wordle
{
    public partial class Tienda : Window
    {
        public Estadistica Estadistica;
        public Tienda(Estadistica estadistica)
        {
            Estadistica = estadistica;
            InitializeComponent();
        }

        private void Vidas1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult Resultado; // Se declara una variable del tipo MessageBoxResult para saber qué decide hacer el usuario.
            Resultado = MessageBox.Show("¿Seguro que quieres comprar 1 vida por 50 de oro?", "Tienda", MessageBoxButton.YesNo);
            if (Resultado == MessageBoxResult.Yes) // Si la respuesta es sí.
            {
                if (Estadistica.Puntos >= 50) // Se comprueba que el usuario disponga de créditos suficientes, de ser así entra en la condición, adquiere la compra y se le restan los créditos.
                {
                    Estadistica.Vidas += 1;
                    Estadistica.Puntos -= 50;
                    ActualizaVidas(); // Mensaje que muestra su saldo actual y su nueva cantidad de vidas.
                }
                else
                {
                    MessageBox.Show("No tienes suficiente oro.");
                }
            }
            else
            {
                return;
            }
        }

        private void Vidas5(object sender, RoutedEventArgs e)
        {
            MessageBoxResult Resultado;
            Resultado = MessageBox.Show("¿Seguro que quieres comprar 5 vidas por 230 de oro?", "Tienda", MessageBoxButton.YesNo);
            if (Resultado == MessageBoxResult.Yes)
            {
                if(Estadistica.Puntos >= 230)
                {
                    Estadistica.Vidas += 5;
                    Estadistica.Puntos -= 230;
                    ActualizaVidas();
                }
                else
                {
                    MessageBox.Show("No tienes suficiente oro.");
                }
            }
            else
            {
                return;
            }
        }

        private void Vidas10(object sender, RoutedEventArgs e)
        {
            MessageBoxResult Resultado;
            Resultado = MessageBox.Show("¿Seguro que quieres comprar 10 vidas por 450 de oro?", "Tienda", MessageBoxButton.YesNo);
            if (Resultado == MessageBoxResult.Yes)
            {
                if (Estadistica.Puntos >= 450)
                {
                    Estadistica.Vidas += 10;
                    Estadistica.Puntos -= 450;
                    ActualizaVidas();
                }
                else
                {
                    MessageBox.Show("No tienes suficiente oro.");
                }
            }
            else
            {
                return;
            }
        }

        private void Vidas20(object sender, RoutedEventArgs e)
        {
            MessageBoxResult Resultado;
            Resultado = MessageBox.Show("¿Seguro que quieres comprar 20 vidas por 850 de oro?", "Tienda", MessageBoxButton.YesNo);
            if (Resultado == MessageBoxResult.Yes)
            {
                if (Estadistica.Puntos >= 850)
                {
                    Estadistica.Vidas += 20;
                    Estadistica.Puntos -= 850;
                    ActualizaVidas();
                }
                else
                {
                    MessageBox.Show("No tienes suficiente oro.");
                }
            }
            else
            {
                return;
            }
        }

        private void Vidas50(object sender, RoutedEventArgs e)
        {
            MessageBoxResult Resultado;
            Resultado = MessageBox.Show("¿Seguro que quieres comprar 50 vida por 1500 de oro?", "Tienda", MessageBoxButton.YesNo);
            if (Resultado == MessageBoxResult.Yes)
            {
                if (Estadistica.Puntos >= 1500)
                {
                    Estadistica.Vidas += 50;
                    Estadistica.Puntos -= 1500;
                    ActualizaVidas();
                }
                else
                {
                    MessageBox.Show("No tienes suficiente oro.");
                }
            }
            else
            {
                return;
            }
        }

        private void Pistas1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult Resultado;
            Resultado = MessageBox.Show("¿Seguro que quieres comprar 1 pista por 150 de oro?", "Tienda", MessageBoxButton.YesNo);
            if (Resultado == MessageBoxResult.Yes)
            {
                if (Estadistica.Puntos >= 150)
                {
                    Estadistica.Pistas += 1;
                    Estadistica.Puntos -= 150;
                    ActualizaPistas();
                }
                else
                {
                    MessageBox.Show("No tienes suficiente oro.");
                }
            }
            else
            {
                return;
            }
        }

        private void Pistas5(object sender, RoutedEventArgs e)
        {
            MessageBoxResult Resultado;
            Resultado = MessageBox.Show("¿Seguro que quieres comprar 5 pistas por 700 de oro?", "Tienda", MessageBoxButton.YesNo);
            if (Resultado == MessageBoxResult.Yes)
            {
                if (Estadistica.Puntos >= 700)
                {
                    Estadistica.Pistas += 5;
                    Estadistica.Puntos -= 700;
                    ActualizaPistas();
                }
                else
                {
                    MessageBox.Show("No tienes suficiente oro.");
                }
            }
            else
            {
                return;
            }
        }

        private void Pistas10(object sender, RoutedEventArgs e)
        {
            MessageBoxResult Resultado;
            Resultado = MessageBox.Show("¿Seguro que quieres comprar 10 pistas por 1350 de oro?", "Tienda", MessageBoxButton.YesNo);
            if (Resultado == MessageBoxResult.Yes)
            {
                if (Estadistica.Puntos >= 1350)
                {
                    Estadistica.Pistas += 10;
                    Estadistica.Puntos -= 1350;
                    ActualizaPistas();
                }
                else
                {
                    MessageBox.Show("No tienes suficiente oro.");
                }
            }
            else
            {
                return;
            }
        }

        private void Pistas20(object sender, RoutedEventArgs e)
        {
            MessageBoxResult Resultado;
            Resultado = MessageBox.Show("¿Seguro que quieres comprar 20 pistas por 2500 de oro?", "Tienda", MessageBoxButton.YesNo);
            if (Resultado == MessageBoxResult.Yes)
            {
                if (Estadistica.Puntos >= 2500)
                {
                    Estadistica.Pistas += 20;
                    Estadistica.Puntos -= 2500;
                    ActualizaPistas();
                }
                else
                {
                    MessageBox.Show("No tienes suficiente oro.");
                }
            }
            else
            {
                return;
            }
        }

        private void Pistas50(object sender, RoutedEventArgs e)
        {
            MessageBoxResult Resultado;
            Resultado = MessageBox.Show("¿Seguro que quieres comprar 50 pistas por 6000 de oro?", "Tienda", MessageBoxButton.YesNo);
            if (Resultado == MessageBoxResult.Yes)
            {
                if (Estadistica.Puntos >= 6000)
                {
                    Estadistica.Pistas += 50;
                    Estadistica.Puntos -= 6000;
                    ActualizaPistas();
                }
                else
                {
                    MessageBox.Show("No tienes suficiente oro.");
                }
            }
            else
            {
                return;
            }
        }
        private void ActualizaVidas()
        {
            MessageBox.Show($"Vidas actuales: {Estadistica.Vidas}. \n Nuevo saldo: {Estadistica.Puntos}."); // Mensaje que muestra su saldo actual y su nueva cantidad de vidas.
        }
        private void ActualizaPistas()
        {
            MessageBox.Show($"Vidas actuales: {Estadistica.Vidas}. \n Nuevo saldo: {Estadistica.Puntos}."); // Mensaje que muestra su saldo actual y su nueva cantidad de pistas.
        }
    }
}
