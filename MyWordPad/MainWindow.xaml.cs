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

namespace MyWordPad
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetF1CommandBinding();
        }

        private void SetF1CommandBinding()
        {
            CommandBinding helpBinding = new CommandBinding(ApplicationCommands.Help);
            helpBinding.CanExecute += CanHelpExecute;
            helpBinding.Executed += HelpExecuted;
            CommandBindings.Add(helpBinding);
        }

        private void HelpExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Слушайте, это не так сложно. Просто введите что-нибудь!", "Справка!");
        }

        private void CanHelpExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            // Если нужно предотвратить выполнение команды, то можно установить CanExecute в false.
            e.CanExecute = true;
        }

        private void FileExit_MouseEnter(object sender, MouseEventArgs e)
        {
            statBarText.Text = "Завершить работу приложения";
        }

        private void FileExit_MouseLeave(object sender, MouseEventArgs e)
        {
            statBarText.Text = "Показать советы по правописанию";
        }

        private void FileExit_Click(object sender, RoutedEventArgs e)
        {
            // Закрыть это окно.
            Close();
        }

        private void ToolsSpellingHints_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void ToolsSpellingHints_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void ToolsSpellingHints_Click(object sender, RoutedEventArgs e)
        {
            string spellingHints = string.Empty;

            // Попробовать получить ошибку правописания в текущем положении курсора ввода.
            SpellingError error = txtData.GetSpellingError(txtData.CaretIndex);
            if (error != null)
            {
                // Построить строку с предполагаемыми вариантами правописания.
                foreach (string s in error.Suggestions) spellingHints += $"{s}\n";

                // Отобразить предполагаемые варианты и раскрыть элемент Expander.
                lblSpellingHints.Content = spellingHints;
                expanderSpelling.IsExpanded = true;
            }
        }
    }
}
