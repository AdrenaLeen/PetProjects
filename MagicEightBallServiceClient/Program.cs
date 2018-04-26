using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicEightBallServiceClient.ServiceReference1;

namespace MagicEightBallServiceClient
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Спросите магический шар *****");

            using (EightBallClient ball = new EightBallClient())
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
