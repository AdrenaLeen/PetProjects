using System.ServiceModel;

namespace MagicEightBallServiceLib
{
    [ServiceContract(Namespace = "http://xskuznetsova.ru")]
    public interface IEightBall
    {
        // Задайте вопрос, получите ответ!
        [OperationContract]
        string ObtainAnswerToQuestion(string userQuestion);
    }
}
