using System.ServiceProcess;

namespace MathWindowsServiceHost
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new MathWinService()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
