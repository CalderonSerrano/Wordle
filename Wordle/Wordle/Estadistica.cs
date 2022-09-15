using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

namespace Wordle
{
    public class Estadistica
    {
        // Declaración de variables.
        public int PartidasJugadas { get; set; }
        public float PorcentajeVictorias { get; set; }
        public int MayorRacha { get; set; }
        public int RachaActual { get; set; }
        public int NumVictorias { get; set; }
        public int Vidas { get; set; }
        public int Puntos { get; set; }
        public int Pistas { get; set; }
        
        public void LeerDatos() // Método que lee los datos del txt Estadísticas y los carga en las variables.
        {
            string aux;
            int contador = 1;
            using (StreamReader sr = new StreamReader("Estadísticas.txt"))
            {
                while ((aux = sr.ReadLine()) != null) // Mientras que sr no este vacío, se guarda en aux.
                {
                    if (contador == 1)
                    {
                        PartidasJugadas = Convert.ToInt32(aux);
                        contador++;
                    }
                    else if (contador == 2)
                    {
                        PorcentajeVictorias = Convert.ToSingle(aux);
                        contador++;
                    }
                    else if (contador == 3)
                    {
                        MayorRacha = Convert.ToInt32(aux);
                        contador++;
                    }
                    else if (contador == 4)
                    {
                        RachaActual = Convert.ToInt32(aux);
                        contador++;
                    }
                    else if (contador == 5)
                    {
                        NumVictorias = Convert.ToInt32(aux);
                        contador++;
                    }
                    else if (contador == 6)
                    {
                        Vidas = Convert.ToInt32(aux);
                        contador++;
                    }
                    else if (contador == 7)
                    {
                        Puntos = Convert.ToInt32(aux);
                        contador++;
                    }
                    else if (contador == 8)
                    {
                        Pistas = Convert.ToInt32(aux);
                    }
                }
            }
        }
        public int RachaMayor()
        {
            if (RachaActual > MayorRacha) // Si la racha actual es mayor que la mayor racha, ésta pasa a ser la mayor racha.
            {
                MayorRacha = RachaActual;
            }
            return MayorRacha;
        }
        public float CalcularPorcentajeVictorias()
        {
            if (PartidasJugadas == 0)
            {
                PorcentajeVictorias = 0; // Si no se han jugado partidas, el porcentaje es 0.
            }
            else
            {
                PorcentajeVictorias = ((float)NumVictorias / PartidasJugadas) * 100;
            }
            return PorcentajeVictorias;
        }
        public void SobreescribirDatos()
        {
            using (StreamWriter sw2 = new StreamWriter("Estadísticas.txt"))
            {
                string sPartidasJugadas = PartidasJugadas.ToString(Console.ReadLine()); // Se crean las variables en string para hacer los datos legibles.
                string sPorcentajeVictorias = PorcentajeVictorias.ToString(Console.ReadLine());
                string sMayorRacha = MayorRacha.ToString(Console.ReadLine());
                string sRachaActual = RachaActual.ToString(Console.ReadLine());
                string sNumVictorias = NumVictorias.ToString(Console.ReadLine());
                string sVidas = Vidas.ToString(Console.ReadLine());
                string sPuntos = Puntos.ToString(Console.ReadLine());
                string sPistas = Pistas.ToString(Console.ReadLine());

                // Se añaden los datos al documento txt Estadísticas.
                sw2.WriteLine(sPartidasJugadas);
                sw2.WriteLine(sPorcentajeVictorias);
                sw2.WriteLine(sMayorRacha);
                sw2.WriteLine(sRachaActual);
                sw2.WriteLine(sNumVictorias);
                sw2.WriteLine(sVidas);
                sw2.WriteLine(sPuntos);
                sw2.WriteLine(sPistas);
            }
        }
    }

}
