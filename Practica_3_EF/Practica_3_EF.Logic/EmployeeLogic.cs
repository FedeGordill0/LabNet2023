using Practica_3_EF.Data;
using Practica_3_EF.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace Practica_3_EF.Logic
{
    public class EmployeeLogic : BLogic, ILogic<Employees>
    {
        public EmployeeLogic()
        {
          
        } 
        public EmployeeLogic(NorthwindContext context)
        {
            _context = context;
        }
        public void Delete(int id)
        {
            var idEmpleado = _context.Employees.Find(id);

            if (idEmpleado != null)
            {
                _context.Employees.Remove(idEmpleado);
                _context.SaveChanges();
            }
            else
            {
                throw new MyException("No existe el empleado con ID: " + id);
                throw new OverflowException("El valor del ID es demasiado grande");
            }
        }

        public List<Employees> GetAll()
        {
            return _context.Employees.ToList();
        }

        public Employees Post(Employees entidad)
        {
            if (entidad.FirstName.Length < 10 && entidad.LastName.Length < 20 && entidad.Title.Length < 30 && entidad.Country.Length < 15)
            {
                _context.Employees.Add(entidad);
                _context.SaveChanges();
                return entidad;
            }
            else
            {
                throw new DbEntityValidationException("La longitud del campo ingresado excede la cantidad de caracteres requeridos");
            }
        }

        public void Put(Employees entidad)
        {
            var empleadoUpdate = _context.Employees.Find(entidad.EmployeeID);

            if (empleadoUpdate != null)
            {
                if (entidad.FirstName.Length < 10 || entidad.LastName.Length < 20 || entidad.Title.Length < 30 || entidad.Country.Length < 15)
                {
                    empleadoUpdate.FirstName = entidad.FirstName;
                    empleadoUpdate.LastName = entidad.LastName;
                    empleadoUpdate.Title = entidad.Title;
                    empleadoUpdate.Country = entidad.Country;

                    _context.SaveChanges();
                }
                else
                {
                    throw new DbEntityValidationException("La longitud del campo ingresado excede la cantidad de caracteres requeridos");
                }
            }
            else
            {
                throw new MyException("No existe el empleado con ID: " + entidad.EmployeeID);
                throw new OverflowException("El valor del ID es demasiado grande");
            }
        }
    }
}
