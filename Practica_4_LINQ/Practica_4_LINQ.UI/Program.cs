using Practica_4_LINQ.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_4_LINQ.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            QueryLogic q = new QueryLogic();
            int opcion = -1;

            while (opcion != 0)
            {
                try
                {
                    Console.WriteLine("Elegir opción: \n(1 - Devolver objeto cliente) \n(2 - Productos sin stock) \n(3 - Productos con stock y que cuestan más de 3 por unidad) \n(4 - Clientes que pertenecen a la Región WA) \n(5 - Producto con ID 789) \n(6 - Clientes en mayúsculas y minúsculas) \n(7 - Clientes de la Región WA con fecha de orden mayor al 1/1/1997) \n(8 - Obtener los 3 primeros clientes) \n(9 - Productos ordenados por nombre) \n(10 - Productos ordenados por unidades en stock de mayor a menor) \n(11 - Diferentes categorías asociadas a los productos) \n(12 - Primer producto) \n(13 - Cantidad de ordenes por cliente) \n(0 - Finalizar Programa)");
                    opcion = Convert.ToInt32(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            q.GetObjetoCliente();
                            break;

                        case 2:
                            q.ProductosSinStock();
                            break;

                        case 3:
                            q.ProductosStockMas3Unidad();
                            break;

                        case 4:
                            q.ClientesRegionWA();
                            break;

                        case 5:
                            q.Producto789();
                            break;

                        case 6:
                            q.Customers_Upper_Lower();
                            break;

                        case 7:
                            q.Join_CustomerOrders();
                            break;

                        case 8:
                            q.Top3Clientes();
                            break;

                        case 9:
                            q.Producto_OrderByNombre();
                            break;

                        case 10:
                            q.Producto_UnitsInStockDesc();
                            break;

                        case 11:
                            q.Join_ProductosCategorias();
                            break;

                        case 12:
                            q.PrimerProducto();
                            break;

                        case 13:
                            q.CantidadOrdenesPorCliente();
                            break;

                        case 0:
                            Console.WriteLine("El programa ha finalizado.");
                            break;

                        default:
                            Console.WriteLine("La opción seleccionada no existe");
                            break;
                    }
                }
                catch (FormatException f)
                {
                    Console.WriteLine(f.Message);
                }
                catch (MyException m)
                {
                    Console.WriteLine(m.Message);
                }
            }
            Console.ReadKey();
        }
    }
}
