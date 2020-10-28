using System;
using System.Windows;

namespace WpfAppAllCode
{
    class Program : Application
    {
        [STAThread]
        static void Main()
        {
            // Обработать события Startup и Exit и затем запустить приложение.
            Program app = new Program();
            app.Startup += AppStartUp;
            app.Exit += AppExit;

            // Инициирует событие Startup.
            app.Run();
        }

        static void AppExit(object sender, ExitEventArgs e)
        {
            MessageBox.Show("Приложение завершило работу.");
        }

        static void AppStartUp(object sender, StartupEventArgs e)
        {
            // Проверить входные аргументы командной строки на предмет наличия флага /GODMODE.
            Current.Properties["GodMode"] = false;
            foreach (string arg in e.Args)
            {
                if (arg.ToLower() == "/godmode")
                {
                    Current.Properties["GodMode"] = true;
                    break;
                }
            }

            // Создать объект MainWindow.
            MainWindow main = new MainWindow("Моё лучшее приложение WPF!", 200, 300);
            main.Show();
        }
    }
}
