using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Instanciables;
using Excepciones;

namespace Test
{
    [TestClass]
    public class TestExcepciones
    {
        /// <summary>
        /// test de excepciones de alumno repetido
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void ExcepcionAlumnoRepetido()
        {
            Universidad universidad = new Universidad();
            Alumno alumno = new Alumno(1, "Yesid", "Dario", "95777215", Alumno.ENacionalidad.Extranjero, Universidad.EClases.Programacion);
            Alumno alumno2 = new Alumno(1, "Yesid", "test", "95777215", Alumno.ENacionalidad.Extranjero, Universidad.EClases.Programacion);
            universidad += alumno;
            universidad += alumno2;
        }

        /// <summary>
        /// Test si se intenta agregar un alumno a una clase sin profe
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(SinProfesorException))]
        public void ExcepcionSinProfesor()
        {
            Universidad universidad = new Universidad();
            Alumno alumno = new Alumno(1, "Yesid", "Dario", "95777215", Alumno.ENacionalidad.Extranjero, Universidad.EClases.Programacion);
            universidad += alumno;
            universidad += Universidad.EClases.Programacion;
        }

    }
}
