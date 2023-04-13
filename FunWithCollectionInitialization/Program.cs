using System.Collections;
using System.Drawing;

Console.WriteLine("***** Инициализация коллекций *****");

// Инициализация стандартного массива.
int[] _ = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

// Инициализация обобщенного List<> с элементами int.
var myGenericList = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

// Инициализация ArrayList числовыми данными.
var myList = new ArrayList { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

var myListOfPoints = new List<Point>
                    {
                        new Point { X = 2, Y = 2 },
                        new Point { X = 3, Y = 3 },
                        new Point { X = 4, Y = 4 }
                    };

foreach (var pt in myListOfPoints) Console.WriteLine(pt);

var myListOfRects = new List<Rectangle>
                    {
                        new Rectangle { Height = 90, Width = 90, Location = new Point { X = 10, Y = 10 }},
                        new Rectangle { Height = 50, Width = 50, Location = new Point { X = 2, Y = 2 }},
                    };

foreach (var r in myListOfRects) Console.WriteLine(r);

Console.ReadLine();