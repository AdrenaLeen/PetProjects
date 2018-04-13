﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LinqToXmlFirstLook
{
    class Program
    {
        static void Main()
        {
            BuildXmlDocWithDOM();
            Console.ReadLine();
        }

        private static void BuildXmlDocWithDOM()
        {
            // Создать новый XML документ в памяти.
            XmlDocument doc = new XmlDocument();

            // Заполнить документ корневым элементом по имени <Inventory>.
            XmlElement inventory = doc.CreateElement("Inventory");

            // Создать подэлемент по имени <Car> с атрибутом ID.
            XmlElement car = doc.CreateElement("Car");
            car.SetAttribute("ID", "1000");

            // Построить данные внутри элемента <Car>.
            XmlElement name = doc.CreateElement("PetName");
            name.InnerText = "Джимбо";
            XmlElement color = doc.CreateElement("Color");
            color.InnerText = "Красный";
            XmlElement make = doc.CreateElement("Make");
            make.InnerText = "Ford";

            // Добавить к элементу <Car> элементы <PetName>, <Color> и <Make>.
            car.AppendChild(name);
            car.AppendChild(color);
            car.AppendChild(make);

            // Добавить к элементу <Inventory> элемент <Car>.
            inventory.AppendChild(car);

            // Вставить завершённый XML в объект XmlDocument и сохранить в файле.
            doc.AppendChild(inventory);
            doc.Save("Inventory.xml");
        }
    }
}
