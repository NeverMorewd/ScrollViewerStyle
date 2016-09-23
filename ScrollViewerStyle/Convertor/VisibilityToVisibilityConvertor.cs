using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace ScrollViewerStyle.Convertor
{
    public class VisibilityToVisibilityConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                Visibility v = (Visibility)value;
                if (v == Visibility.Collapsed||v==Visibility.Hidden)
                    return Visibility.Hidden;
                else
                    return Visibility.Visible;
            }
            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
