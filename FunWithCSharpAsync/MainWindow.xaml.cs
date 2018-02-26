﻿using System;
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
using System.Threading;

namespace FunWithCSharpAsync
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

        private async void btnCallMethod_Click(object sender, RoutedEventArgs e)
        {
            this.Title = await DoWorkAsync();
        }

        private async Task<string> DoWorkAsync()
        {
            return await Task.Run(() =>
            {
                Thread.Sleep(10000);
                return "Готово!";
            });
        }

        private async Task MethodReturningVoidAsync()
        {
            await Task.Run(() =>
            {
                // Выполнение какой-то работы...
                Thread.Sleep(4000);
            });
        }

        private async void btnVoidMethodCall_Click(object sender, RoutedEventArgs e)
        {
            await MethodReturningVoidAsync();
            MessageBox.Show("Готово!");
        }
    }
}
