using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using MathServiceLibrary;
using System.ServiceModel;

namespace MathWindowsServiceHost
{
    public partial class MathWinService : ServiceBase
    {
        // Переменная-член типа ServiceHost.
        private ServiceHost myHost;

        public MathWinService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // Проверить для подстраховки.
            if (myHost != null) myHost.Close();

            // Создать хост и указать URL для привязки HTTP.
            myHost = new ServiceHost(typeof(MathService), new Uri("http://localhost:8080/MathServiceLibrary"));

            // Выбрать стандартные конечные точки.
            myHost.AddDefaultEndpoints();

            // Открыть хост.
            myHost.Open();
        }

        protected override void OnStop()
        {
            // Остановить хост.
            if (myHost != null) myHost.Close();
        }
    }
}
