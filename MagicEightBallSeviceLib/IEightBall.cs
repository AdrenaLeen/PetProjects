using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace MagicEightBallSeviceLib
{
    [ServiceContract(Namespace = "http://xskuznetsova.ru")]
    public interface IEightBall
    {
        // Задайте вопрос, получите ответ!
        [OperationContract]
        string ObtainAnswerToQuestion(string userQuestion);
    }
}
