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
            // Создать объект отношения между данными CustomerOrder.
            DataRelation dr = new DataRelation("CustomerOrder", autoLotDs.Tables["Customers"].Columns["CustID"], autoLotDs.Tables["Orders"].Columns["CustID"]);
            autoLotDs.Relations.Add(dr);

            // Создать объект отношения между данными InventoryOrder.
            dr = new DataRelation("InventoryOrder", autoLotDs.Tables["Inventory"].Columns["CarID"], autoLotDs.Tables["Orders"].Columns["CarID"]);
            autoLotDs.Relations.Add(dr);
        }

        private void btnUpdateDatabase_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                invTableAdapter.Update(autoLotDs, "Inventory");
                custTableAdapter.Update(autoLotDs, "Customers");
                ordersTableAdapter.Update(autoLotDs, "Orders");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGetOrderInfo_Click(object sender, RoutedEventArgs e)
        {
            string strOrderInfo = string.Empty;

            // Получить идентификатор клиента из текстового поля.
            int custID = int.Parse(txtCustID.Text);

            // На основе custID получить подходящую строку из таблицы Customers.
            DataRow[] drsCust = autoLotDs.Tables["Customers"].Select($"CustID = {custID}");
            strOrderInfo += $"Заказчик {drsCust[0]["CustID"]}: {drsCust[0]["FirstName"].ToString().Trim()} {drsCust[0]["LastName"].ToString().Trim()}\n";

            // Перейти из таблицы Customers в таблицу Orders.
            DataRow[] drsOrder = drsCust[0].GetChildRows(autoLotDs.Relations["CustomerOrder"]);

            // Проход в цикле по всем заказам этого клиента.
            foreach (DataRow order in drsOrder)
            {
                strOrderInfo += $"----\nНомер заказа: {order["OrderID"]}\n";

                // Получить автомобиль, на который ссылается этот заказ.
                DataRow[] drsInv = order.GetParentRows(autoLotDs.Relations["InventoryOrder"]);

                // Получить информацию для (ОДНОГО) автомобиля из этого заказа.
                DataRow car = drsInv[0];
                strOrderInfo += $"Марка: {car["Make"]}\n";
                strOrderInfo += $"Цвет: {car["Color"]}\n";
                strOrderInfo += $"Дружественное имя: {car["PetName"]}\n";
            }
            MessageBox.Show(strOrderInfo, "Детали заказа");
        }
    }
}
