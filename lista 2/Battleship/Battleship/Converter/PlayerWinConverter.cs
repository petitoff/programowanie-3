using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using Battleship.Const;

namespace Battleship.Converter
{
    public class PlayerWinConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return "";
            }
            
            var playerTurn = (Player)value;
            
            if (playerTurn == Player.Player1)
            {
                return "Gracz 1 wygrał";
            }
            else
            {
                return "Gracz 2 wygrał";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}