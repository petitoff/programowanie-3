using Battleship.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Battleship.Const;

namespace Battleship.Converter
{
    public class IsShootColorButtonConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return "#fff";
            }
            
            var isShootGood = (IsShootGoodEnum)value;

            switch (isShootGood)
            {
                case IsShootGoodEnum.Miss:
                    return "#f00";
                case IsShootGoodEnum.Hit:
                    return "#00f";
                case IsShootGoodEnum.Empty:
                    return "#fff";
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
