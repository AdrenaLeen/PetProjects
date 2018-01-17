using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private Lazy<AllTracks> allSongs = new Lazy<AllTracks>();

        public AllTracks GetAllTracks()
        {
            // Возвратить все композиции.
            return allSongs.Value;
        }
    }
}
