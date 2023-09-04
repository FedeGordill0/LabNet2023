using Practica_4_LINQ.Data;
using Practica_4_LINQ.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Practica_4_LINQ.Logic
{
    public class QueryLogic : BaseLogic
    {
        public void GetObjetoCliente()
        {
            var cliente = _context.Customers.Take(1).ToList();

            if (cliente != null)
            {
                foreach (var lista in cliente)
                {
                    Console.WriteLine($"ID: {lista.CustomerID}, Cliente: {lista.CompanyName}, Contacto: {lista.ContactName}, País: {lista.Country}, Dirección: {lista.Address}, Teléfono: {lista.Phone}");
                }
            }
        }

        public void ProductosSinStock()
        {
            var listadoProductos = from producto in _context.Products
                                   where producto.UnitsInStock == 0
                                   select producto;

            foreach (var lista in listadoProductos)
            {
                Console.WriteLine($"Producto: {lista.ProductName}, Unidades en stock: {lista.UnitsInStock}");
            }
        }
        public void ProductosStockMas3Unidad()
        {
            var listadoProductos = from producto in _context.Products
                                   where producto.UnitsInStock != 0 && producto.UnitPrice > 3
                                   select producto;

            foreach (var lista in listadoProductos)
            {
                Console.WriteLine($"Producto: {lista.ProductName}, Unidades en stock: {lista.UnitsInStock}, Precio por unidad: {lista.UnitPrice}");
            }
        }

        public void ClientesRegionWA()
        {
            var listadoClientes = from cliente in _context.Customers
                                  where cliente.Region == "WA"
                                  select cliente;

            foreach (var cliente in listadoClientes)
            {
                Console.WriteLine($"Cliente: {cliente.CompanyName}, Contacto: {cliente.ContactName}, Region: {cliente.Region}");
            }
        }

        public void Producto789()
        {
            var producto = _context.Products.Where(p => p.ProductID == 789).FirstOrDefault();

            if (producto != null)
            {
                Console.WriteLine($"ID: {producto.ProductID}, Producto: {producto.ProductName}, Precio Unitario: {producto.UnitPrice}");
            }

            else
            {
                throw new MyException($"No existe el producto");
            }
        }

        public void Customers_Upper_Lower()
        {
            var listadoClientes = _context.Customers.ToList();

            foreach (var cliente in listadoClientes)
            {
                Console.WriteLine($"ID: {cliente.CustomerID.ToUpper()}, CLIENTE: {cliente.CompanyName.ToUpper()}");

                Console.WriteLine($"ID: {cliente.CustomerID.ToLower()}, cliente: {cliente.CompanyName.ToLower()}");
            }
        }

        public void Join_CustomerOrders()
        {
            var customersOrders = from customer in _context.Customers
                                  join orders in _context.Orders
                                  on new { customer.CustomerID } equals new { orders.CustomerID }
                                  where customer.Region == "WA" && orders.OrderDate > new DateTime(1997, 1, 1)
                                  select new
                                  {
                                      customer.Region,
                                      orders.OrderDate,
                                      customer.CompanyName
                                  };

            foreach (var c in customersOrders)
            {
                Console.WriteLine($"Cliente: {c.CompanyName}, Region: {c.Region} Fecha de orden: {c.OrderDate}");
            }
        }

        public void Top3Clientes()
        {
            var listadoClientes = _context.Customers.Where(c => c.Region == "WA").Take(3).ToList();

            foreach (var cliente in listadoClientes)
            {
                Console.WriteLine($"ID: {cliente.CustomerID}, Cliente: {cliente.CompanyName}, Contacto: {cliente.ContactName}, Region: {cliente.Region}");
            }
        }

        public void Producto_OrderByNombre()
        {
            var listaProductos = _context.Products.OrderBy(p => p.ProductName).ToList();

            foreach (var lista in listaProductos)
            {
                Console.WriteLine($"{lista.ProductName}");
            }
        }
        public void Producto_UnitsInStockDesc()
        {
            var listaProductos = _context.Products.OrderByDescending(p => p.UnitsInStock).ToList();

            foreach (var lista in listaProductos)
            {
                Console.WriteLine($"Producto: {lista.ProductName}, Unidades en stock: {lista.UnitsInStock}");
            }
        }
        public void Join_ProductosCategorias()
        {
            var productosCategorias = from product in _context.Products
                                      join category in _context.Categories
                                      on product.CategoryID equals category.CategoryID
                                      select new
                                      {
                                          product.ProductName,
                                          category.CategoryName
                                      };

            var productosCategoriasDistintos = productosCategorias.Distinct().ToList();

            foreach (var item in productosCategoriasDistintos)
            {
                Console.WriteLine($"Producto: {item.ProductName}, Categoría: {item.CategoryName}");

            }
        }

        public void PrimerProducto()
        {
            var p = _context.Products.First();

            Console.WriteLine($"ID: {p.ProductID}, Producto: {p.ProductName}, Unidades en stock: {p.UnitsInStock}, Precio por unidad: {p.UnitPrice}");

        }
        public void CantidadOrdenesPorCliente()
        {
            var listadoOrdenesCliente = from orden in _context.Orders
                                        join cliente in _context.Customers
                                                                    on orden.CustomerID equals cliente.CustomerID
                                        select new { cliente.CompanyName, orden.CustomerID } into consulta
                                        group consulta by new { consulta.CompanyName } into g
                                        select new
                                        {
                                            CompanyNames = g.Key.CompanyName,
                                            CustomerID = g.Select(o => o.CustomerID).Count()
                                        };

            foreach (var item in listadoOrdenesCliente)
            {
                Console.WriteLine($"Cliente: {item.CompanyNames}, Cantidad de ordenes asociadas: {item.CustomerID}");
            }
        }
    }
}
