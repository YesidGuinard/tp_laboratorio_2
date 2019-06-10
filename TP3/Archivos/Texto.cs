using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guarda cadena en archivo de texto
        /// </summary>
        /// <param name="archivo">Ruta del archivo</param>
        /// <param name="datos">Cadena a almacenarce</param>
        /// <returns>verdadero si el archivo se guardo con exito</returns>
        public bool Guardar(string archivo, string datos)
        {
            StreamWriter streamReader = null;
            bool retorno = true;
            try
            {
                streamReader = new StreamWriter(archivo, false);
                streamReader.Write(datos);
            }
            catch (Exception)
            {
                retorno = false;
            }
            finally
            {
                streamReader.Close();
            }
            return retorno;
        }

        /// <summary>
        /// Lee archivo
        /// </summary>
        /// <param name="archivo">Ruta archivo</param>
        /// <param name="datos">Datos leidos</param>
        /// <returns>Verdadero en caso de leer bien</returns>
        public bool Leer(string archivo, out string datos)
        {
            StreamReader streamReader = null;

            bool retorno = true;
            try
            {
                streamReader = new StreamReader(archivo);
                datos = streamReader.ReadToEnd();
            }
            catch (Exception)
            {
                datos = null;
                retorno = false;
            }
            finally
            {
                streamReader.Close();
            }
            return retorno;
        }
    }
}
