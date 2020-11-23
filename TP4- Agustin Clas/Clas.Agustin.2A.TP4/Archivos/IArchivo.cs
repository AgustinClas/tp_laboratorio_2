using System;

namespace Archivos
{
    public interface IArchivo<T>
    {
        bool Guardar(string archivo, T datos);
    }
}
