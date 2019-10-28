using System;

namespace LazyObjectInstantiation
{
    // Объект MediaPlayer имеет объекты Lazy<AllTracks>.
    class MediaPlayer
    {
        // Предположим, что эти методы делают что-то полезное.
        public void Play()
        {
            // Воспроизведение композиции.
        }
        public void Pause()
        {
            // Пауза в воспроизведении.
        }
        public void Stop()
        {
            // Останов воспроизведения.
        }

        // При использовании переменной Lazy() взывается стандартный конструктор класса AllTracks.
        // Использовать лямбда-выражение для добавления дополнительного кода, который выполняется при создании объекта AllTracks.
        private readonly Lazy<AllTracks> allSongs = new Lazy<AllTracks>(() =>
        {
            Console.WriteLine("Создание объекта AllTracks!");
            return new AllTracks();
        });

        // Возвратить все композиции.
        public AllTracks GetAllTracks() => allSongs.Value;
    }
}
