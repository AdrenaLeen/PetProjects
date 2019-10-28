using System;

namespace LazyObjectInstantiation
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Ленивое создание объектов *****");

            // В этом вызывающем коде получение всех композиций не производится, но косвенно всё равно создаются 10 000 объектов!
            MediaPlayer myPlayer = new MediaPlayer();
            myPlayer.Play();

            // Размещение объекта AllTracks происходит только в случае вызова метода GetAllTracks().
            MediaPlayer yourPlayer = new MediaPlayer();
            AllTracks yourMusic = yourPlayer.GetAllTracks();

            Console.ReadLine();
        }
    }
}
