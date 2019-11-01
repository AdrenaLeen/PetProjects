using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;

namespace MyEBookReader
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string theEBook = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnDownload_Click(object sender, RoutedEventArgs e)
        {
            using (WebClient wc = new WebClient())
            {
                wc.DownloadStringCompleted += (s, eArgs) =>
                {
                    theEBook = eArgs.Result;
                    txtBook.Text = theEBook;
                };

                // Загрузить электронную книгу "A Tale of Two Cities" Чарльза Диккенса.
                wc.DownloadStringAsync(new Uri("http://www.gutenberg.org/files/98/98-8.txt"));
            }
        }

        private void BtnGetStats_Click(object sender, RoutedEventArgs e)
        {
            // Получить слова из электронной книги.
            string[] words = theEBook.Split(new char[] { ' ', '\u000A', ',', '.', ';', ':', '-', '?', '/' }, StringSplitOptions.RemoveEmptyEntries);
            string[] tenMostCommon = null;
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
            StringBuilder bookStats = new StringBuilder("10 наиболее часто встречающихся слов:");
            bookStats.AppendLine();
            foreach (string s in tenMostCommon) bookStats.AppendLine(s);
            bookStats.AppendLine($"Самое длинное слово: {longestWord}");
            MessageBox.Show(bookStats.ToString(), "Информация о книге");
        }

        private string[] FindTenMostCommon(string[] words)
        {
            IEnumerable<string> frequencyOrder = from word in words
                                                 where word.Length > 6
                                                 group word by word into g
                                                 orderby g.Count() descending
                                                 select g.Key;

            string[] commonWords = (frequencyOrder.Take(10)).ToArray();
            return commonWords;
        }

        private string FindLongestWord(string[] words) => (from w in words orderby w.Length descending select w).FirstOrDefault();
    }
}
