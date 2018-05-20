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

namespace BinaryResourcesApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Список файлов BitmapImage.
        List<BitmapImage> images = new List<BitmapImage>();

        // Текущая позиция в списке.
        private int currImage = 0;
        private const int maxImages = 2;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                string path = Environment.CurrentDirectory;

                // Загрузить эти изображения во время загрузки окна.
                images.Add(new BitmapImage(new Uri($@"{path}\Images\Deer.jpg")));
                images.Add(new BitmapImage(new Uri($@"{path}\Images\Dogs.jpg")));
                images.Add(new BitmapImage(new Uri($@"{path}\Images\Welcome.jpg")));

                // Показать первое изображение в List<>.
                imageHolder.Source = images[currImage];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPreviousImage_Click(object sender, RoutedEventArgs e)
        {
            if (--currImage < 0) currImage = maxImages;
            imageHolder.Source = images[currImage];
        }

        private void btnNextImage_Click(object sender, RoutedEventArgs e)
        {
            if (++currImage > maxImages) currImage = 0;
            imageHolder.Source = images[currImage];
        }
    }
}
