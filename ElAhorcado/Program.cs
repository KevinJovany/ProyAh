using System;
namespace ElAhorcado
{
    class Program
    {
        static void Main(string[] args)
        {
            int intentos = 0, Ganar = 0;
            string palabra = ElegirPalabra();
            char[] palabraChar = palabra.ToCharArray();
            char[] longitud = GenerarEspacios(palabra);
            string letraingresa = string.Empty;
            char letraingresachar = ' ';

            bool gano = false;

            while (gano == false)
            {
                int SoloUna = 0, contador = 0, repite = 0;

                while (SoloUna == 0)
                {
                    ImprimirHorca(intentos);
                    ImprimirEspacios(longitud);
                    Console.WriteLine("\nTienes 8 intentos");
                    Console.WriteLine("\nHas Fallado: {0}", intentos);
                    Console.Write("\nIntroduce una letra: ");
                    letraingresa = Console.ReadLine();
                    if (CompruebaUna(letraingresa))
                    {
                        letraingresachar = Convert.ToChar(letraingresa);
                        SoloUna++;
                    }
                    else
                    {
                        Console.Clear();
                        Console.Write("Ingresa solo una letra.");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                for (int k = 0; k < longitud.Length; k++)
                {
                    if (longitud[k] == letraingresachar)
                    {
                        if (repite == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Letra ya encontrada, escribe otra.");
                            Console.ReadKey();
                            repite++;
                        }
                        contador++;
                    }
                    else
                    {
                        if (letraingresachar == palabraChar[k])
                        {
                            longitud[k] = letraingresachar;
                            contador++;
                            Ganar++;
                        }
                    }
                }
                if (contador == 0)
                {
                    intentos++;
                }
                if (intentos == 8)
                {
                    Console.Clear();
                    ImprimirHorca(intentos);
                    Console.WriteLine("\nPerdiste...");
                    Console.ReadKey();
                    break;
                }
                if (Ganar == palabraChar.Length)
                {
                    gano = true;
                }
                Console.Clear();
            }
            ImprimirFinJuego(palabra, intentos, gano);
        }
        static string ElegirPalabra()
        {
            Console.WriteLine("JUEGO DEL AHORCADO ");
            Console.WriteLine("Ingresa una palabra: ");
            string palabras = Console.ReadLine();
            Console.Clear();
            string encontrada;
            encontrada = palabras;
            return encontrada;
        }
        static char[] GenerarEspacios(string palabra)
        {
            char[] longitud = palabra.ToCharArray();
            for (int a = 0; a < palabra.Length; a++)
                longitud[a] = '_';
            return longitud;
        }
        static void ImprimirEspacios(char[] longitud)
        {
            Console.WriteLine();
            for (int i = 0; i < longitud.Length; i++)
                Console.Write(longitud[i] + " ");
            Console.WriteLine();
        }
        static bool CompruebaUna(string letra)
        {
            bool UnaLetra = false;
            if (letra.Length == 1)
                UnaLetra = true;
            return UnaLetra;
        }
        static void ImprimirFinJuego(string palabra, int intentos, bool gano)
        {
            if (gano == true)
            {
                ImprimirHorca(intentos);
                Console.WriteLine();
                Console.WriteLine("Ganaste");
                Console.WriteLine();
                Console.WriteLine("La palabra era: {0}", palabra.ToUpper());
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("La palabra era: {0}", palabra.ToUpper());
                Console.ReadKey();
            }
        }
        static void ImprimirHorca(int intentos)
        {
            Console.WriteLine("_ _ _");
            if (intentos >= 1)
            {
                Console.SetCursorPosition(0, 0);

                Console.WriteLine("_____");
                Console.ForegroundColor = ConsoleColor.White;
            }
            if (intentos >= 2)
            {
                Console.SetCursorPosition(3, 1);
                Console.WriteLine("|");
            }
            if (intentos >= 3)
            {
                Console.SetCursorPosition(3, 2);
                Console.WriteLine("O");
            }
            if (intentos >= 4)
            {
                Console.SetCursorPosition(2, 3);
                Console.WriteLine("/");
            }
            if (intentos >= 5)
            {
                Console.SetCursorPosition(2, 3);
                Console.WriteLine("/T");
            }
            if (intentos >= 6)
            {
                Console.SetCursorPosition(2, 3);
                Console.WriteLine("/T\\");
            }
            if (intentos >= 7)
            {
                Console.SetCursorPosition(2, 4);
                Console.WriteLine("/");
            }
            if (intentos >= 8)
            {
                Console.SetCursorPosition(2, 4);
                Console.WriteLine("/ \\");
            }
            for (int i = 1; i < 6; i++)
            {
                if (intentos > 1)
                    Console.SetCursorPosition(0, i);
                Console.WriteLine("|");
            }
            Console.ForegroundColor = ConsoleColor.White;
            if (intentos >= 0)
                Console.WriteLine("_____");
        }
    }
}
