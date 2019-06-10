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
        /// 
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, string datos)
        {
            StreamWriter file = null;
            bool retorno = true;
            try
            {
                file = new StreamWriter(archivo, false);
                file.Write(datos);
            }
            catch (Exception)
            {
                retorno = false;
            }
            finally
            {
                file.Close();
            }
            return retorno;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out string datos)
        {
            StreamReader file = null;
            bool retorno = true;
            try
            {
                file = new StreamReader(archivo);
                datos = file.ReadToEnd();
            }
            catch (Exception)
            {
                datos = null;
                retorno = false;
            }
            finally
            {
                file.Close();
            }
            return retorno;
        }
    }
}
