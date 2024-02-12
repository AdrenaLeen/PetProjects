using System.Xml.Serialization;

namespace SimpleSerialize
{
    [XmlRoot(Namespace = "http://xskuznetsova.ru")]
    public class JamesBondCar : Car
    {
        [XmlAttribute]
        public bool canFly;

        [XmlAttribute]
        public bool canSubmerge;

        public override string ToString() => $"CanFly:{canFly}, CanSubmerge:{canSubmerge} {base.ToString()}";
    }
}
