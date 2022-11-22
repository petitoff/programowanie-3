using System;
using System.Globalization;
using System.Windows.Data;
using Battleship.Const;

namespace Battleship.Converter
{
    public class IsPlayerReadyTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isPlayerReady = (IsReady)value;

            if (isPlayerReady == IsReady.Ready)
            {
                return "Ready";
            }
            else
            {
                return "Not Ready";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}