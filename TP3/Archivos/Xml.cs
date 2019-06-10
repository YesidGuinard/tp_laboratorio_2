using System;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, T datos)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            XmlTextWriter writer = null;
            bool retorno = true;

            try
            {
                writer = new XmlTextWriter(archivo, null);
                ser.Serialize(writer, datos);
            }
            catch (Exception)
            {
                retorno = false;
            }
            finally
            {
                writer.Close();
            }
            return retorno;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out T datos)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            XmlTextReader reader = null;
            bool retorno = true;

            try
            {
                reader = new XmlTextReader(archivo);
                datos = (T)ser.Deserialize(reader);
            }
            catch (Exception)
            {
                datos = default(T);
                retorno = false;  
            }
            finally
            {
                reader.Close();
            }
            return retorno;
        }

    }
}