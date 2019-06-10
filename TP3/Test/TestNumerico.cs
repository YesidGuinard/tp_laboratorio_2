using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Abstractas;
using Clases_Instanciables;
using Excepciones;

namespace Test
{
    [TestClass]
    public class TestNumerico
    {
        /// <summary>
        /// Valida formato valido dni
        /// </summary>
        [TestMethod]
        public void DniInvalido()
        {
            string dniInvalido = "g5777215";
            Alumno alumno = new Alumno(1, "Dario", "Test", "95777215", Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion);
            try
            {
                alumno.StringToDNI = dniInvalido;
            }
            catch (DniInvalidoException)
            {
                Assert.AreNotEqual(dniInvalido, alumno.DNI);
            }

        }

        /// <summary>
        /// Valida conversion de string a int de dni
        /// </summary>
        [TestMethod]
        public void ValidarDniString()
        {
            int dni = 95777215;
            string numero = "95777215";
            Alumno alumno = new Alumno(1, "Dario", "Test", numero, Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion);
            alumno.StringToDNI = numero;
            Assert.AreEqual(dni, alumno.DNI);

        }

    }
}
