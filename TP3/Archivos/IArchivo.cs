namespace Archivos
{

    interface IArchivo<T>
    {
        bool Guardar(string archivo, T datos);
        bool Leer(string archivo, out T datos);
    }


}