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
using System.Threading;

namespace PLINQDataProcessingWithCancellation
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CancellationTokenSource cancelToken = new CancellationTokenSource();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnExecute_Click(object sender, RoutedEventArgs e)
        {
            // Запустить новую "задачу" для обработки целых чисел.
            Task.Factory.StartNew(() =>
            {
                ProcessIntData();
            });
        }

        private void ProcessIntData()
        {
            // Получить очень большой массив целых чисел.
            int[] source = Enumerable.Range(1, 10000000).ToArray();

            // Найти числа, для которых истинно условие num % 3 == 0, и возвратить их в убывающем порядке.
            int[] modThreeIsZero = (from num in source.AsParallel().WithCancellation(cancelToken.Token) where num % 3 == 0
                                    orderby num descending select num).ToArray();
            MessageBox.Show($"Найдено {modThreeIsZero.Count()} чисел, которые соответствуют запросу!");
        }
    }
}
