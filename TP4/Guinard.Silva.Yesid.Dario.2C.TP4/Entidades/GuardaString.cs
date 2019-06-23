using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        /// <summary>
        /// MEtodo de extesion de string que guarda archivo en Desktop
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="archivo"></param>
        /// <returns></returns>
        public static bool Guardar(this string texto, string archivo)
        {
            bool retorno = false;
            StreamWriter file = null;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/" + archivo;
            try
            {
                file = new StreamWriter(path, true);
                file.WriteLine(texto);
                retorno = true;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (file != null)
                {
                    file.Close();
                }
            }

            return retorno;
        }
    }
}
