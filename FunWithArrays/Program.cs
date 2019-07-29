using System;

namespace FunWithArrays
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Массивы *****");
            SimpleArrays();
            ArrayInitialization();
            DeclareImplicitArrays();
            ArrayOfObjects();
            RectMultidimensionalArray();
            JaggedMultidimensionalArray();
            PassAndReceiveArrays();
            SystemArrayFunctionality();
            Console.ReadLine();
        }

        static void SimpleArrays()
        {
            Console.WriteLine("=> Создание простого массива.");
            // Создать массив int, который содержит 3 элемента с индексами 0, 1, 2.
            int[] myInts = new int[3];

            // Создать массив string, который содержит 100 элементов с индексами 0 - 99.
            string[] booksOnDotNet = new string[100];

            myInts[0] = 100;
            myInts[1] = 200;
            myInts[2] = 300;

            // Вывести все значения.
            foreach (int i in myInts) Console.WriteLine(i);
            Console.WriteLine();
        }

        static void ArrayInitialization()
        {
            Console.WriteLine("=> Инициализация массивов.");

            // Синтаксис инициализации массива с использованием ключевого слова new.
            string[] stringArray = new string[] { "один", "два", "три" };
            Console.WriteLine($"stringArray содержит {stringArray.Length} элемента");

            // Синтаксис инициализации массива без использования ключевого слова new.
            bool[] boolArray = { false, false, true };
            Console.WriteLine($"boolArray содержит {boolArray.Length} элемента");

            // Инициализация массива с применением ключевого слова new и указанием размера.
            int[] intArray = new int[4] { 20, 22, 23, 0 };
            Console.WriteLine($"intArray содержит {intArray.Length} элемента");
            Console.WriteLine();
        }

        static void DeclareImplicitArrays()
        {
            Console.WriteLine("=> Неявная инициализация массивов.");

            // Переменная a на самом деле имеет тип int[].
            var a = new[] { 1, 10, 100, 1000 };
            Console.WriteLine("a является: {0}", a.ToString());

            // Переменная b на самом деле имеет тип double[].
            var b = new[] { 1, 1.5, 2, 2.5 };
            Console.WriteLine("b является: {0}", b.ToString());

            // Переменная c на самом деле имеет тип string[].
            var c = new[] { "hello", null, "world" };
            Console.WriteLine("c является: {0}", c.ToString());
            Console.WriteLine();
        }

        static void ArrayOfObjects()
        {
            Console.WriteLine("=> Массив элементов типа оbject.");

            // Массив объектов может содержать всё что угодно.
            object[] myObjects = new object[4];
            myObjects[0] = 10;
            myObjects[1] = false;
            myObjects[2] = new DateTime(1969, 3, 24);
            myObjects[3] = "Форма & Пустота";

            // Вывести тип и значение каждого элемента в массиве.
            foreach (object obj in myObjects) Console.WriteLine($"Тип: {obj.GetType()}, значение: {obj}");
            Console.WriteLine();
        }

        static void RectMultidimensionalArray()
        {
            Console.WriteLine("=> Прямоугольный многомерный массив.");

            // Прямоугольный многомерный массив.
            int[,] myMatrix;
            myMatrix = new int[3, 4];

            // Заполнить массив (3 * 4).
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++) myMatrix[i, j] = i * j;
            }
                
            // Вывести содержимое массива (3 * 4).
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++) Console.Write($"{myMatrix[i, j]}\t");
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void JaggedMultidimensionalArray()
        {
            Console.WriteLine("=> Зубчатый многомерный массив.");

            // Зубчатый многомерный массив (т.е. массив массивов).
            // Здесь у нас есть массив из 5 разных массивов.
            int[][] myJagArray = new int[5][];

            // Создать зубчатый массив.
            for (int i = 0; i < myJagArray.Length; i++) myJagArray[i] = new int[i + 7];

            // Вывести все строчки (помните, что каждый элемент имеет стандартное значение 0).
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < myJagArray[i].Length; j++) Console.Write($"{myJagArray[i][j]} ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void PrintArray(int[] myInts)
        {
            for (int i = 0; i < myInts.Length; i++) Console.WriteLine($"Элемент {i} равен {myInts[i]}");
        }

        static string[] GetStringArray()
        {
            string[] theStrings = { "Привет", "из", "GetStringArray" };
            return theStrings;
        }

        static void PassAndReceiveArrays()
        {
            Console.WriteLine("=> Массивы в качестве параметров и возвращаемых значений.");
            
            // Передать массив в качестве параметров.
            int[] ages = { 20, 22, 23, 0 };
            PrintArray(ages);

            // Получить массив как возвращаемое значение.
            string[] strs = GetStringArray();
            foreach (string s in strs) Console.WriteLine(s);

            Console.WriteLine();
        }

        static void SystemArrayFunctionality()
        {
            Console.WriteLine("=> Работа с System.Array.");
            
            // Инициализировать элементы при запуске.
            string[] gothicBands = { "Tones on Tail", "Bauhaus", "Sisters of Mercy" };

            // Вывести имена в порядке их объявления.
            Console.WriteLine("-> Вот массив:");
            // Вывести имя.
            for (int i = 0; i < gothicBands.Length; i++) Console.Write($"{gothicBands[i]}, ");
            Console.WriteLine("\n");

            // Обратить порядок следования элементов...
            Array.Reverse(gothicBands);
            Console.WriteLine("-> Массив в обратном порядке:");
            // ...и вывести их.
            // Вывести имя.
            for (int i = 0; i < gothicBands.Length; i++) Console.Write($"{gothicBands[i]}, ");
            Console.WriteLine("\n");

            // Удалить все элементы кроме первого.
            Console.WriteLine("-> Удалили все элементы кроме первого...");
            Array.Clear(gothicBands, 1, 2);
            // Вывести имя.
            for (int i = 0; i < gothicBands.Length; i++) Console.Write($"{gothicBands[i]}, ");
            Console.WriteLine();
        }
    }
}
