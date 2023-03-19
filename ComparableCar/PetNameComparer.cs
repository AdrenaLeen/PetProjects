using System.Collections;

namespace ComparableCar
{
    // Этот вспомогательный класс используется для сортировки массива объектов Car по дружественному имени.
    class PetNameComparer : IComparer
    {
        // Проверить дружественное имя каждого объекта
        int IComparer.Compare(object? o1, object? o2)
        {
            if (o1 is Car t1 && o2 is Car t2) return string.Compare(t1.PetName, t2.PetName);
            else throw new ArgumentException("Параметр не является объектом типа Car!");
        }
    }
}
