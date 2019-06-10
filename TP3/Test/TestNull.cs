using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Instanciables;

namespace Test
{
    [TestClass]
    public class TestNull
    {
        /// <summary>
        /// Valida si profesor,alumno,jornada diferente de null
        /// </summary>
        [TestMethod]
        public void ValoresNull()
        {
            Universidad universidad = new Universidad();
            Profesor profesor = new Profesor(1, "Profesor", "Fede", "12345678", Profesor.ENacionalidad.Argentino);
            Alumno alumno = new Alumno(2, "Alumno", "Yesid", "95777215", Alumno.ENacionalidad.Extranjero, Universidad.EClases.Programacion);
            Assert.IsNotNull(universidad.Alumnos);
            Assert.IsNotNull(universidad.Profesores);
            Assert.IsNotNull(universidad.Jornadas);
            Assert.IsNotNull(profesor);
            Assert.IsNotNull(alumno);
        }
    }
}
