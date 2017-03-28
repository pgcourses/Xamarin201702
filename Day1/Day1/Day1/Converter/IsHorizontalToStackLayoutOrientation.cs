using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Day1.Converter
{
    public class IsHorizontalToStackLayoutOrientation : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isHorizontal = (bool)value;
            if (isHorizontal)
            {
                return StackOrientation.Vertical;
            }
            else
            {
                return StackOrientation.Horizontal;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
