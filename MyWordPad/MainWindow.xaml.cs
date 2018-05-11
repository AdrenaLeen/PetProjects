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
using Microsoft.Win32;

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

        private void OpenCmd_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // Создать диалоговое окно открытия файла и показать в нём только текстовые файлы.
            OpenFileDialog openDlg = new OpenFileDialog { Filter = "Текстовые файлы |*.txt" };

            // Был ли совершён щелчок на кнопке OK?
            if (true == openDlg.ShowDialog())
            {
                // Загрузить содержимое выбранного файла.
                string dataFromFile = File.ReadAllText(openDlg.FileName);

                // Отобразить строку в TextBox.
                txtData.Text = dataFromFile;
            }
        }

        private void OpenCmd_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void SaveCmd_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var saveDlg = new SaveFileDialog { Filter = "Текстовые файлы |*.txt" };

            // Был ли совершён щелчок на кнопке OK?
            if (true == saveDlg.ShowDialog())
            {
                // Сохранить данные из TextBox в указанном файле.
                File.WriteAllText(saveDlg.FileName, txtData.Text);
            }
        }

        private void SaveCmd_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
