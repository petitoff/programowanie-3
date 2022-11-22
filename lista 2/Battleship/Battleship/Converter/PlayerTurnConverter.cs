using System;
using System.Globalization;
using System.Windows.Data;
using Battleship.Const;

namespace Battleship.Converter
{
    public class PlayerTurnConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var playerTurn = (Player)value;

            if (playerTurn == Player.Player1)
            {
                return "Kolej gracza 1";
            }
            else
            {
                return "Kolej gracza 2";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}