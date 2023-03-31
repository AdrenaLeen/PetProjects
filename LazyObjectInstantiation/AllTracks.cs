namespace LazyObjectInstantiation
{
    // Представляет все композиции в проигрывателе.
    class AllTracks
    {
        // Наш проигрыватель может содержать максимум 10 000 композиций.
        private readonly Song[] allSongs = new Song[10000];

        public AllTracks()
        {
            // Предположим, что здесь производится заполнение массива объектов Song.
            Console.WriteLine("Заполнение песен!");
        }
    }
}
