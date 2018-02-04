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
using Excel = Microsoft.Office.Interop.Excel;

namespace ExportDataToOfficeApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Car> carsInStock = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            carsInStock = new List<Car>
            {
                new Car {Color="Зелёный", Make="VW", PetName="Мэри"},
                new Car {Color="Красный", Make="Saab", PetName="Мэл"},
                new Car {Color="Чёрный", Make="Ford", PetName="Хэнк"},
                new Car {Color="Жёлтый", Make="BMW", PetName="Дэви"}
            };
            UpdateGrid();
        }

        private void UpdateGrid()
        {
            // Сбросить источник данных.
            dataGridCars.ItemsSource = null;
            dataGridCars.ItemsSource = carsInStock;
        }

        private void btnAddNewCar_Click(object sender, RoutedEventArgs e)
        {
            NewCarDialog d = new NewCarDialog();
            if (d.ShowDialog() == true)
            {
                // Добавить в ведомость запись о новом автомобиле.
                carsInStock.Add(d.theCar);
                UpdateGrid();
            }
        }

        private void btnExportToExcel_Click(object sender, RoutedEventArgs e)
        {
            ExportToExcel(carsInStock);
        }

        static void ExportToExcel(List<Car> carsInStock)
        {
            // Загрузить Excel и затем создать новую пустую рабочую книгу.
            Excel.Application excelApp = new Excel.Application();
            // Сделать пользовательский интерфейс Excel видимым на рабочем столе.
            excelApp.Visible = true;
            excelApp.Workbooks.Add();

            // В этом примере используется единственный рабочий лист.
            Excel._Worksheet workSheet = excelApp.ActiveSheet;

            // Установить заголовки столбцов в ячейках.
            workSheet.Cells[1, "A"] = "Изготовитель";
            workSheet.Cells[1, "B"] = "Цвет";
            workSheet.Cells[1, "C"] = "Дружественное имя";

            // Отобразить все данные в List<Car> на ячейки электронной таблицы.
            int row = 1;
            foreach (Car c in carsInStock)
            {
                row++;
                workSheet.Cells[row, "A"] = c.Make;
                workSheet.Cells[row, "B"] = c.Color;
                workSheet.Cells[row, "C"] = c.PetName;
            }

            // Придать симпатичный вид табличным данным.
            workSheet.Range["A1"].AutoFormat(Excel.XlRangeAutoFormat.xlRangeAutoFormatClassic2);

            // Сохранить файл, завершить работу Excel и отобразить сообщение пользователю.
            workSheet.SaveAs(string.Format(@"{0}\Inventory.xlsx", Environment.CurrentDirectory));
            excelApp.Quit();
            MessageBox.Show("Файл Inventory.xslx сохранён в папке приложения.", "Экспорт завершён!");
        }
    }
}
