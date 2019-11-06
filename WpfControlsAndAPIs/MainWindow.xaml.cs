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
using System.IO;
using System.Windows.Ink;
using System.Windows.Annotations;
using System.Windows.Annotations.Storage;
using System.Windows.Markup;
using AutoLotDAL.Repos;

namespace WpfControlsAndAPIs
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Установить режим Ink в качестве стандартного.
            myInkCanvas.EditingMode = InkCanvasEditingMode.Ink;
            inkRadio.IsChecked = true;
            comboColors.SelectedIndex = 0;
            PopulateDocument();
            EnableAnnotations();

            // Построить обработчики событий Click для сохранения и загрузки документа нефиксированного формата.
            btnSaveDoc.Click += (o, s) =>
            {
                using (FileStream fStream = File.Open("documentData.xaml", FileMode.Create))
                {
                    XamlWriter.Save(this.myDocumentReader.Document, fStream);
                }
            };
            btnLoadDoc.Click += (o, s) =>
            {
                using (FileStream fStream = File.Open("documentData.xaml", FileMode.Open))
                {
                    try
                    {
                        FlowDocument doc = XamlReader.Load(fStream) as FlowDocument;
                        myDocumentReader.Document = doc;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка загрузки документа!");
                    }
                }
            };
            SetBindings();
            ConfigureGrid();
        }

        private void RadioButtonClicked(object sender, RoutedEventArgs e)
        {
            // В зависимости от того, какая кнопка отправила событие, поместить InkCanvas в нужный режим оперирования.
            switch ((sender as RadioButton)?.Content.ToString())
            {
                case "Режим пера!":
                    myInkCanvas.EditingMode = InkCanvasEditingMode.Ink;
                    break;

                case "Режим ластика!":
                    myInkCanvas.EditingMode = InkCanvasEditingMode.EraseByStroke;
                    break;

                case "Режим выбора!":
                    myInkCanvas.EditingMode = InkCanvasEditingMode.Select;
                    break;
            }
        }

        private void ColorChanged(object sender, SelectionChangedEventArgs e)
        {
            // Получить свойство Tag выбранного элемента StackPanel.
            string colorToUse = (comboColors.SelectedItem as StackPanel).Tag.ToString();

            // Изменить цвет, используемый для визуализации штрихов.
            myInkCanvas.DefaultDrawingAttributes.Color = (Color)ColorConverter.ConvertFromString(colorToUse);
        }

        private void SaveData(object sender, RoutedEventArgs e)
        {
            // Сохранить все данные InkCanvas в локальном файле.
            using (FileStream fs = new FileStream("StrokeData.bin", FileMode.Create))
            {
                myInkCanvas.Strokes.Save(fs);
                fs.Close();
            }
        }

        private void LoadData(object sender, RoutedEventArgs e)
        {
            // Наполнить StrokeCollection из файла.
            using (FileStream fs = new FileStream("StrokeData.bin", FileMode.Open, FileAccess.Read))
            {
                StrokeCollection strokes = new StrokeCollection(fs);
                myInkCanvas.Strokes = strokes;
            }
        }

        private void Clear(object sender, RoutedEventArgs e) =>
            // Очистить все штрихи.
            myInkCanvas.Strokes.Clear();

        private void PopulateDocument()
        {
            // Добавить некоторые данные в элемент List.
            listOfFunFacts.FontSize = 14;
            listOfFunFacts.MarkerStyle = TextMarkerStyle.Circle;
            listOfFunFacts.ListItems.Add(new ListItem(new Paragraph(new Run("Фиксированные документы предназначены для представления готовых к печати WYSIWYG документов!"))));
            listOfFunFacts.ListItems.Add(new ListItem(new Paragraph(new Run("API поддерживает таблицы и встроенные данные!"))));
            listOfFunFacts.ListItems.Add(new ListItem(new Paragraph(new Run("Потоковые документы доступны только для чтения!"))));
            listOfFunFacts.ListItems.Add(new ListItem(new Paragraph(new Run("BlockUIContainer позволяет вам встраивать элементы управления WPF в документ!")
              )));

            // Добавить некоторые данные в элемент Paragraph. Первая часть абзаца.
            Run prefix = new Run("Этот абзац был сгенерирован ");

            // Середина абзаца.
            Bold b = new Bold();
            Run infix = new Run("динамически")
            {
                Foreground = Brushes.Red,
                FontSize = 30
            };
            b.Inlines.Add(infix);

            // Последняя часть абзаца.
            Run suffix = new Run(" во время выполнения!");

            // Добавить все части в коллекцию встроенных элементов Paragraph.
            paraBodyText.Inlines.Add(prefix);
            paraBodyText.Inlines.Add(infix);
            paraBodyText.Inlines.Add(suffix);
        }

        private void EnableAnnotations()
        {
            // Создать объект AnnotationService, который работает с FlowDocumentReader.
            AnnotationService anoService = new AnnotationService(myDocumentReader);

            // Создать объект MemoryStream, который будет содержать аннотации.
            MemoryStream anoStream = new MemoryStream();

            // Создать XML-хранилище на основе MemoryStream. Этот объект можно использовать для программного добавления, удаления или поиска аннотаций.
            AnnotationStore store = new XmlStreamStore(anoStream);

            // Включить службы аннотаций.
            anoService.Enable(store);
        }

        private void SetBindings()
        {
            // Создать объект Binding.
            Binding b = new Binding
            {
                // Зарегистрировать преобразователь, источник и путь.
                Converter = new MyDoubleConverter(),
                Source = mySB,
                Path = new PropertyPath("Value")
            };

            // Вызвать метод SetBinding объекта Label.
            labelSBThumb.SetBinding(ContentProperty, b);
        }

        private void ConfigureGrid()
        {
            using (InventoryRepo repo = new InventoryRepo())
            {
                // Построить запрос LINQ, который извлекает необходимые данные из таблицы Inventory.
                gridInventory.ItemsSource = repo.GetAll().Select(x => new { x.CarId, x.Make, x.Color, x.PetName });
            }
        }
    }
}
