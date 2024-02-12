using System.Text;

Console.WriteLine("***** Класс FileStream *****");

// Получить объект FileStream.
using (FileStream fStream = File.Open(@"D:\OneDrive\myMessage.dat", FileMode.Create))
{
    // Закодировать строку в массив байтов.
    string msg = "Привет!";
    byte[] msgAsByteArray = Encoding.Default.GetBytes(msg);

    // Записать byte[] в файл.
    fStream.Write(msgAsByteArray, 0, msgAsByteArray.Length);

    // Сбросить внутреннюю позицию потока.
    fStream.Position = 0;

    // Прочитать byte[] из файла и вывести на консоль.
    Console.Write("Ваше сообщение как массив байтов: ");
    byte[] bytesFromFile = new byte[msgAsByteArray.Length];
    for (int i = 0; i < msgAsByteArray.Length; i++)
    {
        bytesFromFile[i] = (byte)fStream.ReadByte();
        Console.Write(bytesFromFile[i]);
    }
    Console.WriteLine();

    // Вывести декодированное сообщение.
    Console.Write("Декодированное сообщение: ");
    Console.WriteLine(Encoding.Default.GetString(bytesFromFile));
}

Console.ReadLine();