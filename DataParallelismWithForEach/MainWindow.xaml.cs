using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace DataParallelismWithForEach
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Новая переменная уровня MainWindow.
        private readonly CancellationTokenSource cancelToken = new CancellationTokenSource();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnProcessImages_Click(object sender, RoutedEventArgs e)
        {
            // Запустить новую "задачу" для обработки файлов.
            Task.Factory.StartNew(() => ProcessFiles());
        }

        private void ProcessFiles()
        {
            // Использовать экземпляр ParallelOptions для хранения CancellationToken.
            ParallelOptions parOpts = new ParallelOptions
            {
                CancellationToken = cancelToken.Token,
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };

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
                    string filename = Path.GetFileName(currentFile);
                    using (Bitmap bitmap = new Bitmap(currentFile))
                    {
                        bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        bitmap.Save(Path.Combine(newDir, filename));

                        // Вызвать Invoke на объекте MainWindow, чтобы позволить вторичным потокам получать доступ к элементам управления в безопасной к потокам манере.
                        Dispatcher.Invoke(delegate { Title = $"Обработка {filename} в потоке {Thread.CurrentThread.ManagedThreadId}"; });
                    }
                });
                Dispatcher.Invoke(delegate { Title = "Готово!"; });
            }
            catch (OperationCanceledException ex)
            {
                Dispatcher.Invoke(delegate { Title = ex.Message; });
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e) =>
            // Используется для сообщения всем рабочим потокам о необходимости останова!
            cancelToken.Cancel();
    }
}
