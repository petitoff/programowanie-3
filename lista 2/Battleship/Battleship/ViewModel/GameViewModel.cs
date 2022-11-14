using Battleship.Command;
using Battleship.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Battleship.ViewModel
{
    class GameViewModel : BaseViewModel
    {
        private int _player1Score;
        private int _player2Score;

        public AddShipPositionCommand AddShip { get; }

        public ObservableCollection<Battlefield> Battlefield { get; }
        public ObservableCollection<Battlefield> Battlefield2 { get; }

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

            int numberOfButtons = 100;

            Battlefield = new ObservableCollection<Battlefield>();
            for (int i = 0; i < numberOfButtons; i++)
            {
                Battlefield.Add(new Battlefield() { Player = Constans.Player.Player1, IsEmpty = true, Id = i });
            }

            Battlefield2 = new ObservableCollection<Battlefield>();
            for (int i = 0; i < numberOfButtons; i++)
            {
                Battlefield2.Add(new Battlefield() { Player = Constans.Player.Player2, IsEmpty = true, Id = i });
            }

        }

        private void AddShipPosition(object obj)
        {
            Battlefield battlefield = obj as Battlefield;

            if (battlefield.Player == Constans.Player.Player1)
            {
                var found = Battlefield.FirstOrDefault(x => x.Id == battlefield.Id);
                found.IsEmpty = false;
            }
            else
            {
                var found = Battlefield2.FirstOrDefault(x => x.Id == battlefield.Id);
                found.IsEmpty = false;
            }
        }
    }
}
