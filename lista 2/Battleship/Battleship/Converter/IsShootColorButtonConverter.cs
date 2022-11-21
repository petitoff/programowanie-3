using Battleship.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Battleship.Converter
{
    public class IsShootColorButtonConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            var isShootGood = (int)value;

            switch (isShootGood)
            {
                case 0:
                    return "#fff";
                case 1:
                    return "#f00";
                case 2:
                    return "#00f";
                default:
                    return "#fff";
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
