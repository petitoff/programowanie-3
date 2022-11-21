using Battleship.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Battleship.Converter
{
    public class IsEmptyColorButtonConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return "#fff";
            }

            var isShootGood = (IsShootGoodEnum)value;

            if (isShootGood == IsShootGoodEnum.Empty)
            {
                return "#fff";
            }

            if (isShootGood == IsShootGoodEnum.Miss)
            {
                return "#f00";
            }

            if (isShootGood == IsShootGoodEnum.Hit)
            {
                return "#00f";
            }

            if (isShootGood == IsShootGoodEnum.Occupied)
            {
                return "#000";
            }

            return "#fff";

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
