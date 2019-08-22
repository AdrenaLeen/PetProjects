namespace BasicInheritance
{
    // MiniVan "является" Car.
    // Класс MiniVan является производным от Car.
    // Класс MiniVan не может быть расширен!
    sealed class MiniVan : Car
    {
        // Нормально! Доступ к открытым членам родительского типа в производном типе возможен.
        public void TestMethod() => Speed = 10;
    }
}
