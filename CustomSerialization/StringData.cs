using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CustomSerialization
{
    [Serializable]
    class StringData : ISerializable
    {
        private string dataItemOne = "Первый блок данных";
        private string dataItemTwo = "Больше данных";

        public StringData() { }
        protected StringData(SerializationInfo si, StreamingContext ctx)
        {
            // Восстановить переменные-члены из потока.
            dataItemOne = si.GetString("First_Item").ToLower();
            dataItemTwo = si.GetString("dataItemTwo").ToLower();
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext ctx)
        {
            // Наполнить объект SerializationInfo форматированными данными.
            info.AddValue("First_Item", dataItemOne.ToUpper());
            info.AddValue("dataItemTwo", dataItemTwo.ToUpper());
        }
    }
}
