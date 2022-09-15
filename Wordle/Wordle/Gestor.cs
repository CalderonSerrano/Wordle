using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Wordle
{
    public class Gestor
    {
        public string GenerarPalabra(int numLetras)
        {
            string palabra = "";
            string aux;
            Random rnd = new Random();
            using (StreamReader sr = new StreamReader($"0{numLetras}.txt")) // Se leen cuántas lineas tiene el documento, para obtener el límite del Random.
            {
                int filas = File.ReadLines($"0{numLetras}.txt").Count(); // Se almacena el número de lineas en la variable entera filas.
                int random = rnd.Next(1, (filas + 1)); // La variable random generará un número aleatorio entre 1 y el número de filas + 1 (ya que al ser límite, no llega a ese número y hay que sumarle 1).
                int i = 1; // Variable que se irá incrementando en función del número de filas hasta ser igual al número aleatorio.
                while ((aux = sr.ReadLine()) != null)
                {
                    if (i == random) // Cuando esta variable sea igual al número random, esta fila será de donde se obtendrá la palabra aleatoria.
                    {
                        palabra = aux;
                    }
                    i++;
                }
            }
            palabra = EliminarTildes(palabra); // Eliminamos las tildes de la palabra para evitar errores.
            return palabra;
        }

        public string PalabraInsertada(int numLetras, int numIntento, TextBox[,] letras)
        {
            string palabra = "";
            for (int i = 0; i < numLetras; i++) // Recorremos la fila almacenando los valores char en una string y sumándolos para obtener la palabra.
            {
                palabra += letras[i, numIntento].Text;
            }
            EliminarTildes(palabra); // Le eliminamos las tildes.
            return palabra;
        }

        public string TransformarMinus(string PalabraInsertada)
        {
            // Dado que visualmente las letras se ven en mayúsculas, hay que transformarlas a minúsculas con este método.
            string palabraMayus = PalabraInsertada;
            palabraMayus = palabraMayus.ToLower();
            return palabraMayus;
        }

        public bool Pertenece(int numLetras, int numIntento, TextBox[,] letras) // Bucle que recorre todo el contenido del documento Estadísticas comparando la palabra fila a fila para comprobar que existe.
        {
            bool comprueba = false;
            using (StreamReader sr = File.OpenText($"0{numLetras}.txt"))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    if (TransformarMinus(PalabraInsertada(numLetras, numIntento, letras)) == EliminarTildes(s))
                    {
                        comprueba = true;
                    }
                }
            }
            return comprueba;
        }
        public void MoverFila(int numIntento, TextBox[,] letras)
        {
            for (int j = 0; j < letras.GetLength(1); j++)
            {
                for (int i = 0; i < letras.GetLength(0); i++)
                {
                    if (j == numIntento) // Mientras que la fila del array sea igual al intento, se desbloquean las celdas correspondientes.
                    {
                        letras[i, j].IsEnabled = true;
                    }
                    else
                    {
                        letras[i, j].IsEnabled = false; // Y se bloquean el resto de celdas.
                    }
                }
            }
        }
        public string EliminarTildes(string cadena) // Método para eliminar las tildes de una palabra.
        {
            Dictionary<char, char> sustitucion = new Dictionary<char, char>() {
            {'á','a'}, { 'é', 'e' }, { 'í', 'i' }, { 'ó', 'o' }, { 'ú', 'u' } };
            StringBuilder resultado = new StringBuilder();
            for (int i = 0; i < cadena.Length; i++)
            {
                if (sustitucion.ContainsKey(cadena[i]))
                {
                    resultado.Append(sustitucion[cadena[i]]);
                }
                else
                {
                    resultado.Append(cadena[i]);
                }
            }
            return resultado.ToString();
        }
    }
}
