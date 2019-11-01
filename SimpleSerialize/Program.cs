using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;

namespace SimpleSerialize
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Сериализация объектов *****");

            // Создать объект JamesBondCar и установить состояние.
            JamesBondCar jbc = new JamesBondCar
            {
                canFly = true,
                canSubmerge = false
            };
            jbc.theRadio.stationPresets = new double[] { 89.3, 105.1, 97.1 };
            jbc.theRadio.hasTweeters = true;

            // Сохранить объект JamesBondCar в указанном файле в двоичном формате.
            SaveAsBinaryFormat(jbc, "CarData.dat");
            LoadFromBinaryFile("CarData.dat");
            SaveAsSoapFormat(jbc, "CarData.soap");
            SaveAsXmlFormat(jbc, "CarData.xml");
            SaveListOfCars();
            SaveListOfCarsAsBinary();

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

        static void SaveAsXmlFormat(object objGraph, string fileName)
        {
            // Сохранить объект в файле CarData.xml в формате XML.
            XmlSerializer xmlFormat = new XmlSerializer(typeof(JamesBondCar));

            using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlFormat.Serialize(fStream, objGraph);
            }
            Console.WriteLine("=> Машина сохранена в формате XML!");
        }

        static void SaveListOfCars()
        {
            // Сохранить список List<T> объектов JamesBondCars.
            List<JamesBondCar> myCars = new List<JamesBondCar>();
            myCars.Add(new JamesBondCar(true, true));
            myCars.Add(new JamesBondCar(true, false));
            myCars.Add(new JamesBondCar(false, true));
            myCars.Add(new JamesBondCar(false, false));

            using (Stream fStream = new FileStream("CarCollection.xml", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<JamesBondCar>));
                xmlFormat.Serialize(fStream, myCars);
            }
            Console.WriteLine("=> Список машин сохранён!");
        }

        static void SaveListOfCarsAsBinary()
        {
            // Сохранить объект ArrayList (myCars) в двоичном виде.
            List<JamesBondCar> myCars = new List<JamesBondCar>();

            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fStream = new FileStream("AllMyCars.dat", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, myCars);
            }
            Console.WriteLine("=> Список машин сохранён в двоичном виде!");
        }
    }
}
