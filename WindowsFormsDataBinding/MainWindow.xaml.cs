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

        // Представление DataTable.
        private DataView yugosOnlyView;

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

            // Создать таблицу данных.
            CreateDataTable();
            ShowCarsWithIdGreaterThanFive();

            // Создать представление.
            CreateDataView();
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

        // Удалить эту строку из DataRowCollection
        private void btnRemoveRow_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Найти корректную строку для удаления.
                DataRow[] rowToDelete = inventoryTable.Select($"Id={int.Parse(txtRowToRemove.Text)}");

                // Удалить её.
                rowToDelete[0].Delete();
                inventoryTable.AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDisplayMakes_Click(object sender, RoutedEventArgs e)
        {
            // Построить фильтр на основе пользовательского ввода.
            string filterStr = $"Make='{txtMakeToView.Text}'";

            // Найти все строки, удовлетворяющие фильтру.
            // Сортировать по PetName.
            // Возвратить результаты в убывающем порядке.
            DataRow[] makes = inventoryTable.Select(filterStr, "PetName DESC");

            // Показать полученные результаты.
            if (makes.Length == 0) MessageBox.Show("Простите, машин нет...", "Ошибка выборки!");
            else
            {
                string strMake = null;
                for (int i = 0; i < makes.Length; i++)
                {
                    strMake += $"{makes[i]["PetName"]}\n";
                }

                // Вывести все результаты в окне сообщений.
                MessageBox.Show(strMake, $"У нас есть {txtMakeToView.Text} с именами:");
            }
        }

        private void ShowCarsWithIdGreaterThanFive()
        {
            // Вывести дружественные имена всех автомобилей со значением ID больше 5.
            DataRow[] properIDs;
            string newFilterStr = "Id > 5";
            properIDs = inventoryTable.Select(newFilterStr);
            string strIDs = null;
            for (int i = 0; i < properIDs.Length; i++)
            {
                DataRow temp = properIDs[i];
                strIDs += $"{temp["PetName"]} - ID {temp["ID"]}\n";
            }
            MessageBox.Show(strIDs, "Дружественные имена автомобилей, где Id > 5");
        }

        // Найти с помощью фильтра все строки, которые нужно отредактировать.
        private void btnChangeMakes_Click(object sender, RoutedEventArgs e)
        {
            // Удостовериться, что пользователь не изменил выбор.
            if (MessageBoxResult.Yes != MessageBox.Show("Вы уверены? BMW намного лучше, чем Yugo!", "Пожалуйста, подтвердите!", MessageBoxButton.YesNo)) return;
            
            // Построить фильтр.
            string filterStr = "Make='BMW'";

            // Найти все строки, соответствующие фильтру.
            DataRow[] makes = inventoryTable.Select(filterStr);

            // Заменить BMW на Yugo.
            for (int i = 0; i < makes.Length; i++)
            {
                makes[i]["Make"] = "Yugo";
            }
        }

        private void CreateDataView()
        {
            // Установить таблицу, которая используется для создания этого представления.
            yugosOnlyView = new DataView(inventoryTable);

            // Сконфигурировать представление с применением фильтра.
            yugosOnlyView.RowFilter = "Make = 'Yugo'";

            // Привязать к новому элементу DataGridView.
            dataGridColtsView.DataContext = yugosOnlyView;
        }
    }
}
