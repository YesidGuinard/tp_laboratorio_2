using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ListaDePaquetesInstanciada()
        {
            Correo correo = new Correo();
            Assert.IsNotNull(correo.Paquetes);
            
        }

        [TestMethod]
        public void PaquetesIguales()
        {
            Correo correo = new Correo();
            Paquete p1 = new Paquete("Misiones 1206", "123");
            Paquete p2 = new Paquete("Viamonte 765", "123");

            try
            {
                correo = correo + p1;
                correo = correo + p2;
                Assert.Fail();
            }catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(TrackingIdRepetidoException));
            }
           
        }
    }
}
