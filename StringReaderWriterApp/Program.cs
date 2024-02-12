using System.Text;

Console.WriteLine("***** StringWriter / StringReader *****");

// Создать объект StringWriter и записать символьные данные в память.
using (var strWriter = new StringWriter())
{
    strWriter.WriteLine("Не забыть день матери в этом году...");

    // Получить копию содержимого (хранящегося в строке) и вывести на консоль.
    Console.WriteLine($"Содержимое StringWriter: {strWriter}");

    // Получить внутренний объект StringBuilder.
    StringBuilder sb = strWriter.GetStringBuilder();
    sb.Insert(0, "Привет!! ");
    Console.WriteLine($"-> {sb}");
    sb.Remove(0, "Привет!! ".Length);
    Console.WriteLine($"-> {sb}");
}
using (var strWriter = new StringWriter())
{
    strWriter.WriteLine("Не забыть день матери в этом году...");
    Console.WriteLine($"Содержимое StringWriter: {strWriter}");

    // Читать данные из объекта StringWriter.
    using var strReader = new StringReader(strWriter.ToString());
    string? input = null;
    while ((input = strReader.ReadLine()) != null) Console.WriteLine(input);
}

Console.ReadLine();