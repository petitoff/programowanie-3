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
    public class IsPlayerReadyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isPlayerReady = (IsReady)value;

            if (isPlayerReady == IsReady.Ready)
            {
                return "#4ceb34";
            }
            else
            {
                return "#eb3434";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
