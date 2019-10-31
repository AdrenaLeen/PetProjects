using System;
using System.Reflection;

namespace LateBindingWithDynamic
{
    class Program
    {
        static void Main()
        {
            AddWithReflection();
            AddWithDynamic();
            Console.ReadLine();
        }

        private static void AddWithReflection()
        {
            Assembly asm = Assembly.Load("MathLibrary");
            try
            {
                // Получить метаданные для типа SimpleMath.
                Type math = asm.GetType("MathLibrary.SimpleMath");

                // Создать объект SimpleMath на лету.
                object obj = Activator.CreateInstance(math);

                // Получить информацию о методе Add().
                MethodInfo mi = math.GetMethod("Add");

                // Вызвать метод (с параметрами).
                object[] args = { 10, 70 };
                Console.WriteLine($"Результат: {mi.Invoke(obj, args)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void AddWithDynamic()
        {
            Assembly asm = Assembly.Load("MathLibrary");

            try
            {
                // Получить метаданные для типа SimpleMath.
                Type math = asm.GetType("MathLibrary.SimpleMath");

                // Создать объект SimpleMath на лету.
                dynamic obj = Activator.CreateInstance(math);
                Console.WriteLine($"Результат: {obj.Add(10, 70)}");
            }
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
