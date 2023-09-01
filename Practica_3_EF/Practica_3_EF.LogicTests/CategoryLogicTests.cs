using Practica_3_EF.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practica_3_EF.Entities;
using System.Collections.Generic;
using System.Linq;
using Moq;
using System.Data.Entity;
using Practica_3_EF.Data;
using System;

namespace Practica_3_EF.Logic.Tests
{
    [TestClass()]
    public class CategoryLogicTests
    {
        [TestMethod()]
        public void GetCategorias()
        {
            var categorias = new List<Categories>
            {
                new Categories{CategoryName = "categoria1"},
                new Categories{CategoryName = "categoria2"},
            }.AsQueryable();

            var tablaCategoria = new Mock<DbSet<Categories>>();

            tablaCategoria.As<IQueryable<Categories>>().Setup(m => m.Provider).Returns(categorias.Provider);
            tablaCategoria.As<IQueryable<Categories>>().Setup(m => m.Expression).Returns(categorias.Expression);
            tablaCategoria.As<IQueryable<Categories>>().Setup(m => m.ElementType).Returns(categorias.ElementType);
            tablaCategoria.As<IQueryable<Categories>>().Setup(m => m.GetEnumerator()).Returns(categorias.GetEnumerator());

            var northwindContextMock = new Mock<NorthwindContext>();
            northwindContextMock.Setup(c => c.Categories).Returns(tablaCategoria.Object);

            var categoriaLogic = new CategoryLogic(northwindContextMock.Object);
            var categoria = categoriaLogic.Get();

            Assert.AreEqual(2, categoria.Count);
            Assert.AreEqual("categoria1", categoria[0].CategoryName);
            Assert.AreEqual("categoria2", categoria[1].CategoryName);
        }

        [TestMethod()]
        [ExpectedException(typeof(MyException))]
        public void DeleteTest()
        {
            var categorias = new List<Categories> {
            new Categories { CategoryID = 10 },
            }.AsQueryable();

            var tablaCategoria = new Mock<DbSet<Categories>>();

            tablaCategoria.As<IQueryable<Categories>>().Setup(m => m.Provider).Returns(categorias.Provider);
            tablaCategoria.As<IQueryable<Categories>>().Setup(m => m.Expression).Returns(categorias.Expression);
            tablaCategoria.As<IQueryable<Categories>>().Setup(m => m.ElementType).Returns(categorias.ElementType);
            tablaCategoria.As<IQueryable<Categories>>().Setup(m => m.GetEnumerator()).Returns(categorias.GetEnumerator());

            var northwindContextMock = new Mock<NorthwindContext>();
            northwindContextMock.Setup(m => m.Categories).Returns(tablaCategoria.Object);

            CategoryLogic categoryLogic = new CategoryLogic(northwindContextMock.Object);

            categoryLogic.Delete(10);

            tablaCategoria.Verify(m => m.Remove(It.IsAny<Categories>()), Times.Once());
            northwindContextMock.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}