using Battleship.Const;
using System;
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

            switch (isShootGood)
            {
                case IsShootGoodEnum.Empty:
                    return "#fff";
                case IsShootGoodEnum.Miss:
                    return "#f00";
                case IsShootGoodEnum.Hit:
                    return "#00f";
                case IsShootGoodEnum.Occupied:
                    return "#000";
                default:
                    return "#fff";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
