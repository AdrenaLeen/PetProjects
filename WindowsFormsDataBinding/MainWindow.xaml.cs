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
using System.Data;

namespace WindowsFormsDataBinding
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Коллекция объектов Car.
        private List<Car> listCars = new List<Car>();

        // Складская информация.
        private DataTable inventoryTable = new DataTable();

        public MainWindow()
        {
            InitializeComponent();

            // Заполнить список объектами Car.
            listCars = new List<Car>
            {
                new Car { Id = 1, PetName = "Чаки", Make = "BMW", Color = "Зелёный" },
                new Car { Id = 2, PetName = "Тини", Make = "Yugo", Color = "Белый" },
                new Car { Id = 3, PetName = "Ами", Make = "Jeep", Color = "Жёлто-коричневый" },
                new Car { Id = 4, PetName = "Индуктор боли", Make = "Caravan", Color = "Розовый" },
                new Car { Id = 5, PetName = "Фред", Make = "BMW", Color = "Зелёный" },
                new Car { Id = 6, PetName = "Сид", Make = "BMW", Color = "Чёрный" },
                new Car { Id = 7, PetName = "Мэл", Make = "Firebird", Color = "Красный" },
                new Car { Id = 8, PetName = "Сара", Make = "Colt", Color = "Чёрный" }
            };
            CreateDataTable();
        }

        void CreateDataTable()
        {
            // Создать схему таблицы.
            DataColumn carIDColumn = new DataColumn("Id", typeof(int));
            DataColumn carMakeColumn = new DataColumn("Make", typeof(string));
            DataColumn carColorColumn = new DataColumn("Color", typeof(string));
            DataColumn carPetNameColumn = new DataColumn("PetName", typeof(string)) { Caption = "Дружественное имя" };
            inventoryTable.Columns.AddRange( new[] { carIDColumn, carMakeColumn, carColorColumn, carPetNameColumn });

            // Пройти по элементам List<Car> для создания строк.
            foreach (Car c in listCars)
            {
                DataRow newRow = inventoryTable.NewRow();
                newRow["Id"] = c.Id;
                newRow["Make"] = c.Make;
                newRow["Color"] = c.Color;
                newRow["PetName"] = c.PetName;
                inventoryTable.Rows.Add(newRow);
            }

            // Привязать объект DataTable к carInventoryGridView.
            carInventoryGridView.DataContext = inventoryTable;
        }
    }
}
