using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{

    interface IArchivo<T>
    {
        /// <summary>
        /// Guarda archivo
        /// </summary>
        /// <param name="archivo">Ruta</param>
        /// <param name="datos">Datos a guardar</param>
        /// <returns>Verdadero si se guardo</returns>
        bool Guardar(string archivo, T datos);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        bool Leer(string archivo, out T datos);
    }


}