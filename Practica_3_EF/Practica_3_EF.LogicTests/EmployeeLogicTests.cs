using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Practica_3_EF.Data;
using Practica_3_EF.Entities;
using Practica_3_EF.Logic;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_3_EF.Logic.Tests
{
    [TestClass()]
    public class EmployeeLogicTests
    {
        [TestMethod()]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void PostEmpleado()
        {
            var tablaEmpleado = new Mock<DbSet<Employees>>();

            var northwindContextMock = new Mock<NorthwindContext>();
            northwindContextMock.Setup(m => m.Employees).Returns(tablaEmpleado.Object);

            EmployeeLogic employeeLogic = new EmployeeLogic(northwindContextMock.Object);

            employeeLogic.Post(new Employees
            {
                FirstName = "nombreTest",
                LastName = "apellidoTest",
            });

            tablaEmpleado.Verify(m => m.Add(It.IsAny<Employees>()), Times.Once());
            northwindContextMock.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}
