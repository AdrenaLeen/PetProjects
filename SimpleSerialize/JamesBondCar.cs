using System;
using System.Xml.Serialization;

namespace SimpleSerialize
{
    [Serializable]
    [XmlRoot(Namespace = "http://xskuznetsova.ru")]
    public class JamesBondCar : Car
    {
        [XmlAttribute]
        public bool canFly;

        [XmlAttribute]
        public bool canSubmerge;

        public JamesBondCar(bool skyWorthy, bool seaWorthy)
        {
            canFly = skyWorthy;
            canSubmerge = seaWorthy;
        }

        // XmlSerializer требует стандартного конструктора!
        public JamesBondCar() { }
    }
}
