using System;
using System.Runtime.Serialization;

namespace ProcessMultipleExceptions
{
    // Это специальное исключение описывает детали условия выхода автомобиля из строя.
    // (Не забывайте, что можно также просто расширить класс Exception.)
    [Serializable]
    class CarIsDeadException : ApplicationException
    {
        public CarIsDeadException() { }
        public CarIsDeadException(string message) : base(message) { }
        public CarIsDeadException(string message, Exception inner) : base(message, inner) { }
        protected CarIsDeadException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        // Любые дополнительные специальные свойства, конструкторы и члены данных...
        public DateTime ErrorTimeStamp { get; set; }
        public string CauseOfError { get; set; }
        public CarIsDeadException(string message, string cause, DateTime time) : base(message)
        {
            CauseOfError = cause;
            ErrorTimeStamp = time;
        }
    }
}
