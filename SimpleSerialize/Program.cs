using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;

namespace SimpleSerialize
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Сериализация объектов *****");

            // Создать объект JamesBondCar и установить состояние.
            JamesBondCar jbc = new JamesBondCar();
            jbc.canFly = true;
            jbc.canSubmerge = false;
            jbc.theRadio.stationPresets = new double[] { 89.3, 105.1, 97.1 };
            jbc.theRadio.hasTweeters = true;

            // Сохранить объект JamesBondCar в указанном файле в двоичном формате.
            SaveAsBinaryFormat(jbc, "CarData.dat");
            LoadFromBinaryFile("CarData.dat");

            SaveAsSoapFormat(jbc, "CarData.soap");

            Console.ReadLine();
        }

        static void SaveAsBinaryFormat(object objGraph, string fileName)
        {
            // Сохранить граф объектов в файл CarData.dat в двоичном виде.
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, objGraph);
            }
            Console.WriteLine("=> Машина сохранена в двоичном формате!");
        }

        static void LoadFromBinaryFile(string fileName)
        {
            BinaryFormatter binFormat = new BinaryFormatter();

            // Прочитать объект JamesBondCar из двоичного файла.
            using (Stream fStream = File.OpenRead(fileName))
            {
                JamesBondCar carFromDisk = (JamesBondCar)binFormat.Deserialize(fStream);
                Console.WriteLine($"Может ли эта машина летать? : {carFromDisk.canFly}");
            }
        }

        static void SaveAsSoapFormat(object objGraph, string fileName)
        {
            // Сохранить граф объектов в файле CarData.soap в формате SOAP.
            SoapFormatter soapFormat = new SoapFormatter();

            using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                soapFormat.Serialize(fStream, objGraph);
            }
            Console.WriteLine("=> Машина сохранена в формате SOAP!");
        }
    }
}
