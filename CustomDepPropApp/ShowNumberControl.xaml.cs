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

namespace CustomDepPropApp
{
    /// <summary>
    /// Логика взаимодействия для ShowNumberControl.xaml
    /// </summary>
    public partial class ShowNumberControl : UserControl
    {
        public ShowNumberControl()
        {
            InitializeComponent();
        }

        public int CurrentNumber
        {
            get { return (int)GetValue(CurrentNumberProperty); }
            set { SetValue(CurrentNumberProperty, value); }
        }

        // Это сделает возможной анимацию, применение стилей, привязку и т.д.
        public static readonly DependencyProperty CurrentNumberProperty = DependencyProperty.Register("CurrentNumber", typeof(int), typeof(ShowNumberControl), new UIPropertyMetadata(100, new PropertyChangedCallback(CurrentNumberChanged)), new ValidateValueCallback(ValidateCurrentNumber));

        public static bool ValidateCurrentNumber(object value)
        {
            // Очень просто бизнес-правило: значение должно находиться в диапазоне между 0 и 500.
            if (Convert.ToInt32(value) >= 0 && Convert.ToInt32(value) <= 500) return true;
            else return false;
        }

        private static void CurrentNumberChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs args)
        {
            // Привести DependencyObject к ShowNumberControl.
            ShowNumberControl c = (ShowNumberControl)depObj;

            // Получить элемент управления Label в ShowNumberControl.
            Label theLabel = c.numberDisplay;

            // Установить для Label новое значение.
            theLabel.Content = args.NewValue.ToString();
        }
    }
}
