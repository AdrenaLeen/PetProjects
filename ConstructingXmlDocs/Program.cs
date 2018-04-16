using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConstructingXmlDocs
{
    class Program
    {
        static void Main()
        {
            CreateFullXDocument();
            CreateRootAndChildren();
            MakeXElementFromArray();
            ParseAndLoadExistingXml();
            Console.ReadLine();
        }

        static void CreateFullXDocument()
        {
            XDocument inventoryDoc =
              new XDocument(
                new XComment("Текущие запасы автомобилей!"),
                new XProcessingInstruction("xml-stylesheet", "href='MyStyles.css' title='Compact' type='text/css'"),
                new XElement("Inventory",
                  new XElement("Car", new XAttribute("ID", "1"),
                    new XElement("Color", "Зелёный"),
                    new XElement("Make", "BMW"),
                    new XElement("PetName", "Стэн")
                  ),
                  new XElement("Car", new XAttribute("ID", "2"),
                    new XElement("Color", "Розовый"),
                    new XElement("Make", "Yugo"),
                    new XElement("PetName", "Мэлвин")
                  )
                )
              );

            // Сохранить на диске.
            inventoryDoc.Save("FullXmlDoc.xml");
        }

        static void CreateRootAndChildren()
        {
            XElement inventoryDoc =
              new XElement("Inventory",
                new XComment("Текущие запасы автомобилей!"),
                    new XElement("Car", new XAttribute("ID", "1"),
                    new XElement("Color", "Зелёный"),
                    new XElement("Make", "BMW"),
                    new XElement("PetName", "Стэн")
                  ),
                  new XElement("Car", new XAttribute("ID", "2"),
                    new XElement("Color", "Розовый"),
                    new XElement("Make", "Yugo"),
                    new XElement("PetName", "Мэлвин")
                  )
              );

            // Сохранить на диске.
            inventoryDoc.Save("SimpleInventory.xml");
        }

        static void MakeXElementFromArray()
        {
            // Создать анонимный массив анонимных типов.
            var people = new[] {
                new { FirstName = "Мэнди", Age = 40},
                new { FirstName = "Эндрю", Age  = 32 },
                new { FirstName = "Дэйв", Age  = 41 },
                new { FirstName = "Сара", Age  = 31}
            };
            IEnumerable<XElement> arrayDataAsXElements = from c in people
                                                         select
                                                         new XElement("Person",
                                                             new XAttribute("Age", c.Age),
                                                             new XElement("FirstName", c.FirstName));
            XElement peopleDoc = new XElement("People", arrayDataAsXElements);
            Console.WriteLine(peopleDoc);
            Console.WriteLine();
        }

        static void ParseAndLoadExistingXml()
        {
            // Построить объект XElement из строки.
            string myElement =
              @"<Car ID ='3'>
                  <Color>Жёлтый</Color>
                  <Make>Yugo</Make>
                </Car>";
            XElement newElement = XElement.Parse(myElement);
            Console.WriteLine(newElement);
            Console.WriteLine();

            // Загрузить файл SimpleInventory.xml.
            XDocument myDoc = XDocument.Load("SimpleInventory.xml");
            Console.WriteLine(myDoc);
        }
    }
}
