using System.Windows;

namespace Wordle
{
    public partial class Estadisticas : Window
    {
        public Estadistica E;
        public Estadisticas(Estadistica e) // Se le pasa la clase por el constructor para evitar crear una nueva instancia y evitar la pérdida de datos.
        {
            E = e;
            InitializeComponent();
            Datos();
        }

        public void Datos()
        {
            // Se asigna el valor de las variables a los label correspondientes.
            lbPartidas.Content = E.PartidasJugadas;
            lbPorcentaje.Content = E.CalcularPorcentajeVictorias() + "%";
            lbRachaMasLarga.Content = E.RachaMayor();
            lbRachaActual.Content = E.RachaActual;
            lbVictorias.Content = E.NumVictorias;
            lbVidas.Content = E.Vidas;
            lbPuntos.Content = E.Puntos;
            lbPistas.Content = E.Pistas;
        }
    }
}
