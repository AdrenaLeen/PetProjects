using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;

namespace CustomSerialization
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Настраиваемая сериализация *****");

            // Этот тип реализует интерфейс ISerializable.
            StringData myData = new StringData();

            // Сохранить экземляр в локальный файл в формате SOAP.
            SoapFormatter soapFormat = new SoapFormatter();
            using (Stream fStream = new FileStream("MyData.soap", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                soapFormat.Serialize(fStream, myData);
            }
            Console.ReadLine();
        }
    }
}
