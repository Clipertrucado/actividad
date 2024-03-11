using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    internal class Program
    {
        public static void Main() {

            string rutaFichero = DateTime.Today.ToString("ddMMyyyy")+".txt";

            string fraseCompleta = peidrFrase();

            string frase = peticion(fraseCompleta);

            string[] lista = trozo(frase);

            fichero(lista, rutaFichero);

            leer(rutaFichero, lista);

            bool continuar = preguntar(frase);        
            
            if (continuar) { 
                pedirVocales(frase , fraseCompleta);
            }
        }

        private static string peidrFrase() {
            Console.WriteLine("Ingresa una frase");
            string frase = Console.ReadLine();
            return frase;
        }

        private static string peticion(string frase)
        {

            char[] vocales = {'a', 'e', 'i', 'o', 'u' };
            

            for(int i = 0; i<=vocales.Length -1; i++)
            {
                frase = frase.Replace(vocales[i], '*');
            }

            Console.WriteLine(frase);
            
            return frase;
        }

        private static string[] trozo(string frase) {

            string[] lista;
            lista = frase.Split(' ');

            for(int i = 0;i<=lista.Length - 1; i++) {

                Console.WriteLine(lista[i]);

            }


            return lista;
        }

        private static void fichero(string[] lista, string rutaFichero){  

            using (StreamWriter sw = new StreamWriter(rutaFichero))
            {
                for (int i = 0; i <= lista.Length - 1; i++)
                {

                    sw.WriteLine(lista[i]);

                }

            }

        }

        private static void leer(string rutaFichero, string[] lista) {

            Console.WriteLine("ULTIMAS 2 POSICIONES");

            using (StreamReader sw = new StreamReader(rutaFichero))
            {

                var i =0;
                string frase = sw.ReadLine();
                while (frase != null)
                {

                    if (i >= lista.Length - 2)
                    {
                        Console.WriteLine(frase);

                    }

                    i = i + 1;
                    frase = sw.ReadLine();
                }

            }
    
        }

        private static bool preguntar(string frase) {

            Console.WriteLine("¿Cuantas vocales faltan?");
            int nPedido = Convert.ToInt32(Console.ReadLine());

            bool resultado = false;

            string[] lista;
            lista = frase.Split('*');

            int nValidar = lista.Length - 1;

            if (nValidar == nPedido)
            {

                Console.WriteLine("¡¡Felicidades!!");
                resultado = true;
            }

            Console.WriteLine(nValidar);
            Console.ReadLine();
            return resultado;
        }

        private static void pedirVocales(string frase, string frase2)
        {
            
            char[] lista;
            lista = frase.ToCharArray();

            char[] lista2;
            lista2 = frase2.ToCharArray();

            char sus = '*';

            for (int i = 0; i <= lista.Length - 1; i++)
            {
                
                if (lista[i].Equals(sus))
                {
                    Console.WriteLine("Ingrese la una vocal");
                    char vocal = Convert.ToChar(Console.ReadLine());
                    if (vocal.Equals(lista2[i]))
                    {
                        lista[i] = vocal;

                        mostrarLista(lista);
                    }
                }

            }

        }

        private static void mostrarLista(char[] lista)
        {
            Console.WriteLine("");
            for (int i = 0; i <= lista.Length - 1; i++)
            {

                Console.Write(lista[i]);

            }
        }
    }
}
