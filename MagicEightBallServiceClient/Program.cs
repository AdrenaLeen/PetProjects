using MagicEightBallServiceClient.ServiceReference1;
using System;

namespace MagicEightBallServiceClient
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Спросите магический шар *****");

            using (EightBallClient ball = new EightBallClient("BasicHttpBinding_IEightBall"))
            {
                Console.Write("Ваш вопрос: ");
                string question = Console.ReadLine();
                string answer = ball.ObtainAnswerToQuestion(question);
                Console.WriteLine("Шар говорит: {0}", answer);
            }
            Console.ReadLine();
        }
    }
}
