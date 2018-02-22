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
using System.IO;
using System.Drawing;

namespace DataParallelismWithForEach
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Новая переменная уровня MainWindow.
        private CancellationTokenSource cancelToken = new CancellationTokenSource();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnProcessImages_Click(object sender, RoutedEventArgs e)
        {
            // Запустить новую "задачу" для обработки файлов.
            Task.Factory.StartNew(() =>
            {
                ProcessFiles();
            });
        }

        private void ProcessFiles()
        {
            // Использовать экземпляр ParallelOptions для хранения CancellationToken.
            ParallelOptions parOpts = new ParallelOptions();
            parOpts.CancellationToken = cancelToken.Token;
            parOpts.MaxDegreeOfParallelism = Environment.ProcessorCount;

            // Загрузить все файлы *.jpg и создать новый каталог для модифицированных данных.
            string[] files = Directory.GetFiles(@"D:\OneDrive\Pictures\Фотоальбом", "*.jpg", SearchOption.AllDirectories);
            string newDir = @"D:\OneDrive\Pictures\ModifiedPictures";
            Directory.CreateDirectory(newDir);

            try
            {
                // Обработать данные изображений в параллельном режиме!
                Parallel.ForEach(files, parOpts, currentFile =>
                {
                    parOpts.CancellationToken.ThrowIfCancellationRequested();
                    string filename = System.IO.Path.GetFileName(currentFile);
                    using (Bitmap bitmap = new Bitmap(currentFile))
                    {
                        bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        bitmap.Save(System.IO.Path.Combine(newDir, filename));

                        // Вызвать Invoke на объекте MainWindow, чтобы позволить вторичным потокам получать доступ к элементам управления в безопасной к потокам манере.
                        this.Dispatcher.Invoke((Action)delegate
                        {
                            this.Title = $"Обработка {filename} в потоке {Thread.CurrentThread.ManagedThreadId}";
                        });
                    }
                });
                this.Dispatcher.Invoke((Action)delegate
                {
                    this.Title = "Готово!";
                });
            }
            catch (OperationCanceledException ex)
            {
                this.Dispatcher.Invoke((Action)delegate
                {
                    this.Title = ex.Message;
                });
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            // Используется для сообщения всем рабочим потокам о необходимости останова!
            cancelToken.Cancel();
        }
    }
}
