using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_Practica_1_POO
{
    internal class Program
    {
        private static int cPasajeros;
        private static TransportePublico taxi;
        private static TransportePublico omnibus;
        static void Main(string[] args)
        {
            List<TransportePublico> listadoTransportesPublicos = new List<TransportePublico>();

            Console.WriteLine("Ingresar tipo de transporte público: (1 - Taxi) (2 - Omnibus)");

            int tipo = Convert.ToInt32(Console.ReadLine());

            if (tipo == 1)
            {
                for (int i = 0; i < 5; i++)
                {
                    try
                    {
                        Console.WriteLine($"Ingresar cantidad de pasajeros del taxi n°{(i + 1)}: ");

                        cPasajeros = Convert.ToInt32(Console.ReadLine());

                        if (cPasajeros < 0)
                        {
                            throw new ArgumentException("El número debe ser mayor o igual a 0");
                        }

                        taxi = new Taxi(cPasajeros);
                        listadoTransportesPublicos.Add(taxi);
                    }

                    catch (FormatException)
                    {
                        Console.WriteLine("NO se pueden ingresar letras, palabras o espacios en blanco");
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);

                    }

                }
                foreach (var l in listadoTransportesPublicos)
                {
                    Console.WriteLine("Cantidad de pasajeros: " + l.Pasajeros);
                }
                Console.WriteLine(taxi.Avanzar());
                Console.WriteLine(taxi.Detenerse());
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    try
                    {
                        Console.WriteLine($"Ingresar cantidad de pasajeros del omnibus n°{(i + 1)}: ");

                        cPasajeros = Convert.ToInt32(Console.ReadLine());

                        if (cPasajeros < 0)
                        {
                            throw new ArgumentException("El número debe ser mayor o igual a 0");
                        }

                        omnibus = new Omnibus(cPasajeros);
                        listadoTransportesPublicos.Add(omnibus);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("NO se pueden ingresar letras ,palabras o espacios en blanco");
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);

                    }

                }
                foreach (var l in listadoTransportesPublicos)
                {
                    Console.WriteLine("Cantidad de pasajeros: " + l.Pasajeros);
                }
                Console.WriteLine(omnibus.Avanzar());
                Console.WriteLine(omnibus.Detenerse());
            }
            Console.ReadKey();
        }
    }
}

