using System;
using System.Runtime.Serialization;

namespace CustomSerialization
{
    [Serializable]
    class MoreData
    {
        private string dataItemOne = "Первый блок данных";
        private string dataItemTwo = "Больше данных";

        [OnSerializing]
        private void OnSerializing(StreamingContext context)
        {
            // Вызывается в течение процесса сериализации.
            dataItemOne = dataItemOne.ToUpper();
            dataItemTwo = dataItemTwo.ToUpper();
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            // Вызывается, когда процесс десериализации завершён.
            dataItemOne = dataItemOne.ToLower();
            dataItemTwo = dataItemTwo.ToLower();
        }
    }
}
