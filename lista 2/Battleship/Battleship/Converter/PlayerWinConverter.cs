using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Battleship.Converter
{
    public class PlayerWinConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Const.Player player)) return "";
            
            switch (player)
            {
                case Const.Player.Player1:
                    return "Player 1";
                case Const.Player.Player2:
                    return "Player 2";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}