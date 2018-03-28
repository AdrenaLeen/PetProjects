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
using System.Data.SqlClient;
using System.Configuration;

namespace MultitabledDataSetApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Объект DataSet уровня формы.
        private DataSet autoLotDs = new DataSet("AutoLot");

        // Использовать построители команд для упрощения конфигурирования адаптеров данных.
        private SqlCommandBuilder sqlCbInventory;
        private SqlCommandBuilder sqlCbCustomers;
        private SqlCommandBuilder sqlCbOrders;

        // Адаптеры данных (для каждой таблицы).
        private SqlDataAdapter invTableAdapter;
        private SqlDataAdapter custTableAdapter;
        private SqlDataAdapter ordersTableAdapter;

        // Строка подключения уровня формы.
        private string connectionString;

        public MainWindow()
        {
            InitializeComponent();

            // Получить строку подключения.
            connectionString = ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"].ConnectionString;

            // Создать объекты адаптеров.
            invTableAdapter = new SqlDataAdapter("Select * from Inventory", connectionString);
            custTableAdapter = new SqlDataAdapter("Select * from Customers", connectionString);
            ordersTableAdapter = new SqlDataAdapter("Select * from Orders", connectionString);

            // Автоматически сгенерировать команды.
            sqlCbInventory = new SqlCommandBuilder(invTableAdapter);
            sqlCbOrders = new SqlCommandBuilder(ordersTableAdapter);
            sqlCbCustomers = new SqlCommandBuilder(custTableAdapter);

            // Заполнить таблицы в DataSet.
            invTableAdapter.Fill(autoLotDs, "Inventory");
            custTableAdapter.Fill(autoLotDs, "Customers");
            ordersTableAdapter.Fill(autoLotDs, "Orders");

            // Построить отношения между таблицами.
            BuildTableRelationship();

            // Привязать к сеткам.
            dataGridViewInventory.DataContext = autoLotDs.Tables["Inventory"];
            dataGridViewCustomers.DataContext = autoLotDs.Tables["Customers"];
            dataGridViewOrders.DataContext = autoLotDs.Tables["Orders"];
        }

        private void BuildTableRelationship()
        {
            throw new NotImplementedException();
        }
    }
}
