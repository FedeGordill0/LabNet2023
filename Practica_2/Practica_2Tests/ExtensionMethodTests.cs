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
    public class ExtensionMethodTests
    {
        [TestMethod()]
        public void DividirCeroTest()
        {
            int num1 = 10;
            Assert.ThrowsException<DivideByZeroException>(() => { ExtensionMethod.DividirCero(num1); }); ;
        }

        [TestMethod()]
        public void DividirTest()
        {
            int num1 = 10;
            int num2 = 0;
            Assert.ThrowsException<DivideByZeroException>(() => { ExtensionMethod.Dividir(num1, num2); });
        }
    }
}