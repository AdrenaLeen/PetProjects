using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomException
{
    // Это специальное исключение описывает детали условия выхода автомобиля из строя.
    // (Не забывайте, что можно также просто расширить класс Exception.)
    class CarIsDeadException : ApplicationException
    {
        private string messageDetails = String.Empty;
        public DateTime ErrorTimeStamp { get; set; }
        public string CauseOfError { get; set; }

        public CarIsDeadException() { }
        public CarIsDeadException(string message, string cause, DateTime time)
        {
            messageDetails = message;
            CauseOfError = cause;
            ErrorTimeStamp = time;
        }

        // Переопределение свойства Exception.Message.
        public override string Message
        {
            get
            {
                return $"Сообщение об ошибке от Car: {messageDetails}";
            }
        }
    }
}
