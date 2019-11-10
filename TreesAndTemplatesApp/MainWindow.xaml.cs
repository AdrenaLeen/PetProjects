using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace TreesAndTemplatesApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string dataToShow = string.Empty;
        private Control ctrlToExamine = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnShowLogicalTree_Click(object sender, RoutedEventArgs e)
        {
            dataToShow = "";
            BuildLogicalTree(0, this);
            txtDisplayArea.Text = dataToShow;
        }

        void BuildLogicalTree(int depth, object obj)
        {
            // Добавить имя типа к переменной-члену dataToShow.
            dataToShow += $"{new string(' ', depth)}{obj.GetType().Name}\n";

            // Если элемент - не DependencyObject, то пропустить его.
            if (!(obj is DependencyObject)) return;

            // Выполнить рекурсивный вызов для каждого логического дочернего элемента.
            foreach (object child in LogicalTreeHelper.GetChildren((DependencyObject)obj)) BuildLogicalTree(depth + 5, child);
        }

        private void BtnShowVisualTree_Click(object sender, RoutedEventArgs e)
        {
            dataToShow = "";
            BuildVisualTree(0, this);
            txtDisplayArea.Text = dataToShow;
        }

        void BuildVisualTree(int depth, DependencyObject obj)
        {
            // Добавить имя типа к переменной-члену dataToShow member.
            dataToShow += $"{new string(' ', depth)}{obj.GetType().Name}\n";

            // Выполнить рекурсивный вызов для каждого визуально дочернего элемента.
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++) BuildVisualTree(depth + 1, VisualTreeHelper.GetChild(obj, i));
        }

        private void BtnTemplate_Click(object sender, RoutedEventArgs e)
        {
            dataToShow = "";
            ShowTemplate();
            txtDisplayArea.Text = dataToShow;
        }

        private void ShowTemplate()
        {
            // Удалить элемент, который в текущий момент находится в области предварительного просмотра.
            if (ctrlToExamine != null) stackTemplatePanel.Children.Remove(ctrlToExamine);
            try
            {
                // Загрузить PresentationFramework и создать экземпляр указанного элемента управления. Установить его размеры для отображения, а затем добавить в пустой контейнер StackPanel.
                Assembly asm = Assembly.Load("PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35");
                ctrlToExamine = (Control)asm.CreateInstance(txtFullName.Text);
                ctrlToExamine.Height = 200;
                ctrlToExamine.Width = 200;
                ctrlToExamine.Margin = new Thickness(5);
                stackTemplatePanel.Children.Add(ctrlToExamine);

                // Определить настройки XML для предохранения отступов.
                XmlWriterSettings xmlSettings = new XmlWriterSettings { Indent = true };

                // Создать объект StringBuilder для хранения разметки XAML.
                StringBuilder strBuilder = new StringBuilder();

                // Создать объект XmlWriter на основе имеющихся настроек.
                XmlWriter xWriter = XmlWriter.Create(strBuilder, xmlSettings);

                // Сохранить разметку XAML в объекте XmlWriter на основе ControlTemplate.
                XamlWriter.Save(ctrlToExamine.Template, xWriter);

                // Отобразить разметку XAML в текстовом поле.
                dataToShow = strBuilder.ToString();
            }
            catch (Exception ex)
            {
                dataToShow = ex.Message;
            }
        }
    }
}
