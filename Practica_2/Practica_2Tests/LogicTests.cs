using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practica_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_2.Tests
{
    [TestClass()]
    public class LogicTests
    {
        [TestMethod()]
        public void MostrarExcepcionTest()
        {
            Logic l = new Logic();
            Assert.ThrowsException<Exception>(() => { l.MostrarExcepcion(); });
        }

        [TestMethod()]
        public void ExcepcionPersonalizadaTest()
        {
            Logic l = new Logic();
            Assert.ThrowsException<MyException>(() => { l.ExcepcionPersonalizada(); });

        }
    }
}