using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Path = System.IO.Path;

namespace DataParallelismWithForEach
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Новая переменная уровня MainWindow.
        private readonly CancellationTokenSource cancelToken = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        // Используется для сообщения всем рабочим потокам о необходимости останова!
        private void BtnCancel_Click(object sender, RoutedEventArgs e) => cancelToken.Cancel();

        // Запустить новую "задачу" для обработки файлов.
        private void BtnProcessImages_Click(object sender, RoutedEventArgs e) => Task.Factory.StartNew(() => ProcessFiles());

        private void ProcessFiles()
        {
            // Загрузить все файлы *.jpg и создать новый каталог для модифицированных данных.
            var basePath = Directory.GetCurrentDirectory();
            var pictureDirectory = Path.Combine(basePath, "TestPictures");
            var outputDirectory = Path.Combine(basePath, "ModifiedPictures");

            // Удалить любые существующие файлы.
            if (Directory.Exists(outputDirectory)) Directory.Delete(outputDirectory, true);
            Directory.CreateDirectory(outputDirectory);
            string[] files = Directory.GetFiles(pictureDirectory, "*.jpg", SearchOption.AllDirectories);

            // Использовать экземпляр ParallelOptions для хранения CancellationToken.
            var parOpts = new ParallelOptions
            {
                CancellationToken = cancelToken.Token,
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };

            try
            {
                // Обработать данные изображений в параллельном режиме!
                Parallel.ForEach(files, parOpts, currentFile =>
                {
                    parOpts.CancellationToken.ThrowIfCancellationRequested();
                    Thread.Sleep(20000);
                    string filename = Path.GetFileName(currentFile);

                    // Вызвать Invoke() на объекте Dispatcher, чтобы позволить вторичным потокам получать доступ к элементам управления в безопасной к потокам манере.
                    Dispatcher?.Invoke(() => { Title = $"Обработка {filename} в потоке {Environment.CurrentManagedThreadId}"; });

                    using var bitmap = new Bitmap(currentFile);
                    bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    bitmap.Save(Path.Combine(outputDirectory, filename));
                });
                Dispatcher?.Invoke(() => { Title = "Готово!"; });
            }
            catch (OperationCanceledException ex)
            {
                Dispatcher?.Invoke(() => { Title = ex.Message; });
            }
        }
    }
}
