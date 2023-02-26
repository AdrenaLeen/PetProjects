using System.Runtime.Serialization;

namespace ProcessMultipleExceptions
{
    // Это специальное исключение описывает детали условия выхода автомобиля из строя.
    // (Не забывайте, что можно также просто расширить класс Exception.)
    [Serializable]
    class CarIsDeadException : ApplicationException
    {
        public DateTime ErrorTimeStamp { get; set; }
        public string CauseOfError { get; set; } = string.Empty;
        public CarIsDeadException() { }
        public CarIsDeadException(string cause, DateTime time)
        {
            CauseOfError = cause;
            ErrorTimeStamp = time;
        }
        public CarIsDeadException(string cause, DateTime time, string message, Exception inner) : base(message, inner)
        {
            CauseOfError = cause;
            ErrorTimeStamp = time;
        }
        protected CarIsDeadException(string cause, DateTime time, SerializationInfo info, StreamingContext context) : base(info, context)
        {
            CauseOfError = cause;
            ErrorTimeStamp = time;
        }
    }
}
