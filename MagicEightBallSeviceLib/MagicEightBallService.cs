using System;

namespace MagicEightBallServiceLib
{
    public class MagicEightBallService : IEightBall
    {
        // Просто для отображения на хосте.
        public MagicEightBallService()
        {
            Console.WriteLine("Магический шар ожидает вашего вопроса...");
        }

        public string ObtainAnswerToQuestion(string userQuestion)
        {
            string[] answers =  { "Никто не знает будущего", "Да", "Нет", "Неясно", "Спросите ещё раз позднее", "Определённо" };

            // Возвратить случайный ответ.
            Random r = new Random();
            return answers[r.Next(answers.Length)];
        }
    }
}
