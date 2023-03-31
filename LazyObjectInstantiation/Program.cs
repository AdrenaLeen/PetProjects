using LazyObjectInstantiation;

Console.WriteLine("***** Ленивое создание объектов *****");

// В этом вызывающем коде получение всех композиций не производится, но косвенно всё равно создаются 10 000 объектов!
var myPlayer = new MediaPlayer();
myPlayer.Play();

// Размещение объекта AllTracks происходит только в случае вызова метода GetAllTracks().
var yourPlayer = new MediaPlayer();
AllTracks _ = yourPlayer.GetAllTracks();

Console.ReadLine();