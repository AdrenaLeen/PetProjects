using System;
using System.IO;

namespace BinaryWriterReader
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Binary Writer / Reader *****");

            // Открыть средство двоичной записи в файл.
            FileInfo f = new FileInfo("BinFile.dat");
            using (BinaryWriter bw = new BinaryWriter(f.OpenWrite()))
            {
                // Вывести на консоль тип BaseStream (System.IO.FileStream в данном случае).
                Console.WriteLine($"Основной поток: {bw.BaseStream}");

                // Создать некоторые данные для сохранения в файле.
                double aDouble = 1234.67;
                int anInt = 34567;
                string aString = "A, B, C";

                // Записать данные.
                bw.Write(aDouble);
                bw.Write(anInt);
                bw.Write(aString);
            }
            Console.WriteLine("Готово!");

            // Читать двоичные данные из потока.
            using (BinaryReader br = new BinaryReader(f.OpenRead()))
            {
                Console.WriteLine(br.ReadDouble());
                Console.WriteLine(br.ReadInt32());
                Console.WriteLine(br.ReadString());
            }

            Console.ReadLine();
        }
    }
}
