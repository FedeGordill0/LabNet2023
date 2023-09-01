using Practica_3_EF.Entities;
using Practica_3_EF.Logic;
using System;
using System.Data.Entity.Validation;

namespace Practica_3_EF.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcion = -1;
            CategoryLogic c = new CategoryLogic();
            EmployeeLogic e = new EmployeeLogic();
            int id;
            string descripcion, nombre, apellido, cargo, pais;

            while (opcion != 0)
            {
                try
                {
                    Console.WriteLine("Elegir opción: \n(1 - Obtener listado de categorias) \n(2 - Añadir nueva categoría) \n(3 - Modificar categoría) \n(4 - Eliminar categoría) \n(5 - Obtener listado de empleados) \n(6 - Añadir nuevo empleado) \n(7 - Modificar empleado) \n(8 - Eliminar Empleado) \n(0 - Finalizar programa)");

                    opcion = Convert.ToInt32(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            var categories = c.Get();

                            foreach (var category in categories)
                            {
                                Console.WriteLine($"ID: {category.CategoryID} Categoría: {category.CategoryName}: {category.Description}");
                            }
                            break;

                        case 2:
                            Console.Write("Insertar nombre: ");
                            nombre = Console.ReadLine();

                            Console.Write("Insertar descripción: ");
                            descripcion = Console.ReadLine();

                            var nuevaCategoria = new Categories
                            {
                                CategoryName = nombre,
                                Description = descripcion
                            };

                            c.Post(nuevaCategoria);

                            Console.WriteLine("Categoría creada correctamente.");
                            break;

                        case 3:
                            Console.WriteLine("Ingresar ID de la categoria a modificar: ");
                            id = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Insertar nombre: ");
                            nombre = Console.ReadLine();

                            Console.Write("Insertar descripción: ");
                            descripcion = Console.ReadLine();

                            var modificarCategoria = new Categories
                            {
                                CategoryID = id,
                                CategoryName = nombre,
                                Description = descripcion
                            };

                            c.Put(modificarCategoria);

                            Console.WriteLine("Categoría modificada correctamente.");
                            break;

                        case 4:
                            Console.WriteLine("Ingresar ID de la categoria a eliminar: ");
                            id = Convert.ToInt32(Console.ReadLine());

                            c.Delete(id);
                            Console.WriteLine("Categoría eliminada correctamente.");
                            break;

                        case 5:
                            var employees = e.Get();

                            foreach (var employee in employees)
                            {
                                Console.WriteLine($"ID: {employee.EmployeeID} Nombre: {employee.FirstName} {employee.LastName}, Cargo: {employee.Title}, País: {employee.Country}");
                            }
                            break;

                        case 6:
                            Console.WriteLine("Ingresar nombre: ");
                            nombre = Console.ReadLine();

                            Console.WriteLine("Ingresar apellido: ");
                            apellido = Console.ReadLine();

                            Console.WriteLine("Ingresar cargo: ");
                            cargo = Console.ReadLine();

                            Console.WriteLine("Ingresar país: ");
                            pais = Console.ReadLine();

                            var nuevoEmpleado = new Employees
                            {
                                FirstName = nombre,
                                LastName = apellido,
                                Title = cargo,
                                Country = pais
                            };

                            e.Post(nuevoEmpleado);

                            Console.WriteLine("Empleado creado correctamente.");
                            break;

                        case 7:
                            Console.WriteLine("Ingresar ID del empleado a modificar: ");
                            id = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Ingresar nombre: ");
                            nombre = Console.ReadLine();

                            Console.WriteLine("Ingresar apellido: ");
                            apellido = Console.ReadLine();

                            Console.WriteLine("Ingresar cargo: ");
                            cargo = Console.ReadLine();

                            Console.WriteLine("Ingresar país: ");
                            pais = Console.ReadLine();

                            var modificarEmpleado = new Employees
                            {
                                EmployeeID = id,
                                FirstName = nombre,
                                LastName = apellido,
                                Title = cargo,
                                Country = pais
                            };

                            e.Put(modificarEmpleado);

                            Console.WriteLine("Empleado modificado correctamente.");
                            break;

                        case 8:
                            Console.WriteLine("Ingresar ID del empleado a eliminar: ");
                            id = Convert.ToInt32(Console.ReadLine());

                            e.Delete(id);

                            Console.WriteLine("Empleado eliminado correctamente.");
                            break;

                        case 0:
                            Console.WriteLine("El programa ha finalizado.");
                            break;

                        default:
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("No se admite la carga de cadenas o espacios en blanco.");
                }
                catch (MyException m)
                {
                    Console.WriteLine(m.Message);
                }
                catch (DbEntityValidationException d)
                {
                    Console.WriteLine(d.Message);
                }
                catch (OverflowException o)
                {
                    Console.WriteLine(o.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            Console.ReadKey();
        }
    }
}