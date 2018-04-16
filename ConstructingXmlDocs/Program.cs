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
    }
}
