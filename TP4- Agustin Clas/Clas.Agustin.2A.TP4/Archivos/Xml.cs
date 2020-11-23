using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        public bool Guardar(string archivo, T datos)
        {

            bool retorno = true;
            try
            {
                XmlTextWriter writer = new XmlTextWriter(archivo, System.Text.Encoding.UTF8);
                XmlSerializer serializer = new XmlSerializer(typeof(T));

                serializer.Serialize(writer, datos);
            }
            catch (Exception e)
            {
                retorno = false;
            }

            return retorno;
        }

    }
}
