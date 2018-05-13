using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Globalization;

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

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Поскольку заботиться о "двунаправленной" привязке не нужно, просто возвратить значение value.
            return value;
        }
    }
}
