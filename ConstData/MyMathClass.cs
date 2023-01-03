namespace ConstData
{
    class MyMathClass
    {
        public static readonly double PI;

        static MyMathClass() => PI = 3.14;

        public static void LocalConstStringVariable()
        {
            // Доступ к локальным константным данным можно получать напрямую.
            const string fixedStr = "Фиксированные строковые данные";
            Console.WriteLine(fixedStr);
        }
    }
}
