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
using System.Reflection;
using CommonSnappableTypes;
using Microsoft.Win32;

namespace MyExtendableApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SnapInModuleToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            // Позволить пользователю выбрать сборку для загрузки.
            OpenFileDialog dlg = new OpenFileDialog();

            if (dlg.ShowDialog() == true)
            {
                if (dlg.FileName.Contains("CommonSnappableTypes")) MessageBox.Show("CommonSnappableTypes не содержит оснасток!");
                else if (!LoadExternalModule(dlg.FileName)) MessageBox.Show("Не удаётся обнаружить класс, который реализует IAppFunctionality!");
            }
        }

        private bool LoadExternalModule(string path)
        {
            bool foundSnapIn = false;
            Assembly theSnapInAsm = null;
            try
            {
                // Динамически загрузить выбранную сборку.
                theSnapInAsm = Assembly.LoadFrom(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return foundSnapIn;
            }

            // Получить все совместимые с IAppFunctionality классы в сборке.
            IEnumerable<Type> theClassTypes = from t in theSnapInAsm.GetTypes()
                                              where t.IsClass &&
                                              (t.GetInterface("IAppFunctionality") != null)
                                              select t;

            // Создать объект и вызвать метод DoIt().
            foreach (Type t in theClassTypes)
            {
                foundSnapIn = true;

                // Использовать позднее связывание для создания экземпляра типа.
                IAppFunctionality itfApp = (IAppFunctionality)theSnapInAsm.CreateInstance(t.FullName, true);
                itfApp.DoIt();
                lstLoadedSnapIns.Items.Add(t.FullName);

                // Отобразить информацию о компании.
                DisplayCompanyData(t);
            }
            return foundSnapIn;
        }

        private void DisplayCompanyData(Type t)
        {
            // Получить данные [CompanyInfo].
            IEnumerable<object> compInfo = from ci in t.GetCustomAttributes(false)
                                           where (ci.GetType() == typeof(CompanyInfoAttribute))
                                           select ci;

            // Отобразить данные.
            foreach (CompanyInfoAttribute c in compInfo) MessageBox.Show(c.CompanyUrl, $"Больше информации о {c.CompanyName} может быть найдено в");
        }
    }
}
