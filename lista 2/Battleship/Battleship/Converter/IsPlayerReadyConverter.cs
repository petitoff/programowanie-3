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
            var isPlayerReady = (IsReady?)value;

            return isPlayerReady == IsReady.Ready ? "#4ceb34" : "#eb3434";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
