namespace GenericDelegate
{
    // Этот обобщенный делегат может вызывать любой метод, который возвращает void и принимает единственный параметр типа T.
    public delegate void MyGenericDelegate<T>(T arg);
}
