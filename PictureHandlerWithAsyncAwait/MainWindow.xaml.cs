using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace PictureHandlerWithAsyncAwait
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CancellationTokenSource? cancelToken = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        // Используется для того, чтобы сообщить всем рабочим потокам о необходимости остановиться!
        private void CmdCancel_Click(object sender, EventArgs e) => cancelToken?.Cancel();

        private async void CmdProcess_Click(object sender, EventArgs e)
        {
            cancelToken = new CancellationTokenSource();
            var basePath = Directory.GetCurrentDirectory();
            var pictureDirectory = Path.Combine(basePath, "TestPictures");
            var outputDirectory = Path.Combine(basePath, "ModifiedPictures");

            // Очистить все существующие файлы
            if (Directory.Exists(outputDirectory)) Directory.Delete(outputDirectory);
            Directory.CreateDirectory(outputDirectory);
            string[] files = Directory.GetFiles(pictureDirectory, "*.jpg", SearchOption.AllDirectories);
            try
            {
                foreach (string file in files)
                {
                    try
                    {
                        await ProcessFile(file, outputDirectory, cancelToken.Token);
                    }
                    catch (OperationCanceledException ex)
                    {
                        Console.WriteLine(ex);
                        throw;
                    }
                }
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            cancelToken = null;
            this.Title = "Обработка завершена";
        }

        private async Task ProcessFile(string currentFile, string outputDirectory, CancellationToken token)
        {
            string filename = Path.GetFileName(currentFile);
            using var bitmap = new Bitmap(currentFile);
            try
            {
                await Task.Run(() =>
                {
                    Dispatcher?.Invoke(() => { Title = $"Обработка {filename}"; });
                    bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    bitmap.Save(Path.Combine(outputDirectory, filename));
                }, token);
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
