namespace CustomInterfaces
{
    public abstract class CloneableType
    {
        // Поддерживать этот "полиморфный интерфейс" могут только производные типы. Классы в других иерархиях не имеют доступа к данному абстрактному члену.
        public abstract object Clone();
    }
}
