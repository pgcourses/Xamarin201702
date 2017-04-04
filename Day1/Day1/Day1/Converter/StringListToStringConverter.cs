using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Day1.Converter
{
    /// <summary>
    /// Mivel a ValidationManager egy listát ad vissza, hogy Text-re lehessen Bind-olni
    /// ezért visszatérünk az első sorral a listából, ha van.
    /// </summary>
    public class StringListToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var list = value as ICollection<string>;
            if (list == null)
            {
                return null;
            }

            return list.FirstOrDefault();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
