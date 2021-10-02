using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Test
{
    [TestClass]
    public class Pais
    {
        [TestMethod]
        public void Listar()
        {
            Negocio.Pais.Listar();
        }

        [TestMethod]
        public void Obtener()
        {
            Negocio.Pais.Obtener(1);
        }

    }
}