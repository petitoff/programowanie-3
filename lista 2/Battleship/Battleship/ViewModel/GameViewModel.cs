using Battleship.Command;
using Battleship.Model;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Battleship.ViewModel
{
    class GameViewModel : BaseViewModel
    {
        private int _player1Score;
        private int _player2Score;

        public AddShipPositionCommand AddShip { get; }

        public ObservableCollection<Battlefield> Battlefield { get; }

        public int Player1Score
        {
            get { return _player1Score; }
            set
            {
                _player1Score = value;
                OnPropertyChanged();
            }
        }

        public int Player2Score
        {
            get { return _player2Score; }
            set
            {
                _player2Score = value;
                OnPropertyChanged();
            }
        }

        public GameViewModel()
        {
            AddShip = new AddShipPositionCommand(AddShipPosition);

            Battlefield = new ObservableCollection<Battlefield>();
            for (int i = 0; i < 100; i++)
            {
                Battlefield.Add(new Battlefield() { Player = Constans.Player.Player1, IsEmpty = false, Id = i });
            }
        }

        private void AddShipPosition(object obj)
        {
            Battlefield battlefield = obj as Battlefield;

            if (battlefield.Player == Constans.Player.Player1)
                return;
        }
    }
}
