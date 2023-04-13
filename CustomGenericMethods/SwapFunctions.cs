namespace CustomGenericMethods
{
    static class SwapFunctions
    {
        // Поменять местами два целочисленных значения.
        internal static void Swap(ref int a, ref int b) => (b, a) = (a, b);

        // Поменять местами два объекта Person.
        internal static void Swap(ref Person a, ref Person b) => (b, a) = (a, b);

        // Этот метод будет менять местами два элемента типа, указанного в параметре <T>.
        internal static void Swap<T>(ref T a, ref T b)
        {
            Console.WriteLine($"Вы послали методу Swap() {typeof(T)}");
            (b, a) = (a, b);
        }
    }
}
