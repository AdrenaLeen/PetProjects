using System;
using System.Globalization;
using System.Windows.Data;

namespace WpfControlsAndAPIs
{
    class MyDoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Преобразовать значение double в int.
            double v = (double)value;
            return (int)v;
        }

        // Поскольку заботиться о "двунаправленной" привязке не нужно, просто возвратить значение value.
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => value;
    }
}
