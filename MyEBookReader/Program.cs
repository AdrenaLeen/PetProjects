using System.Text;

string theEBook = string.Empty;
GetBook();
Console.WriteLine("Загрузка книги...");
Console.ReadLine();

async void GetBook()
{
    using var wc = new HttpClient();

    // Загрузить электронную книгу "A Tale of Two Cities" Чарльза Диккенса.
    using HttpResponseMessage response = await wc.GetAsync("https://www.gutenberg.org/files/98/98-0.txt");
    response.EnsureSuccessStatusCode();
    theEBook = await response.Content.ReadAsStringAsync();

    Console.WriteLine("Загрузка завершена.");
    GetStats();
}
void GetStats()
{
    // Получить слова из электронной книги.
    string[] words = theEBook.Split(new char[] { ' ', '\u000A', ',', '.', ';', ':', '-', '?', '/' }, StringSplitOptions.RemoveEmptyEntries);

    string[] tenMostCommon = new string[10];
    string longestWord = string.Empty;
    Parallel.Invoke(() =>
    {
        // Найти 10 наиболее часто встречающихся слов.
        tenMostCommon = FindTenMostCommon(words);
    }, () =>
    {
        // Получить самое длинное слово.
        longestWord = FindLongestWord(words);
    });

    // Когда все задачи завершены, построить строку, показывающую всю статистику в окне сообщений.
    var bookStats = new StringBuilder("10 наиболее часто встречающихся слов:");
    bookStats.AppendLine();
    foreach (string s in tenMostCommon) bookStats.AppendLine(s);
    bookStats.AppendLine($"Самое длинное слово: {longestWord}");
    Console.WriteLine(bookStats.ToString());
}
string[] FindTenMostCommon(string[] words)
{
    var frequencyOrder = from word in words
                         where word.Length > 6
                         group word by word into g
                         orderby g.Count() descending
                         select g.Key;
    string[] commonWords = frequencyOrder.Take(10).ToArray();
    return commonWords;
}
string FindLongestWord(string[] words) => (from w in words orderby w.Length descending select w).FirstOrDefault() ?? string.Empty;