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
        public ShootShipPositionCommand ShootShip { get; }

        public ObservableCollection<Battlefield> Battlefield1 { get; }
        public ObservableCollection<BattlefieldShoot> BattlefieldShoot1 { get; }
        public ObservableCollection<Battlefield> Battlefield2 { get; }
        public ObservableCollection<BattlefieldShoot> BattlefieldShoot2 { get; }

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
            ShootShip = new ShootShipPositionCommand(ShootShipPosition);

            int numberOfButtons = 100;

            Battlefield1 = new ObservableCollection<Battlefield>();
            for (int i = 0; i < numberOfButtons; i++)
            {
                Battlefield1.Add(new Battlefield() { Player = Constans.Player.Player1, IsEmpty = true, Id = i });
            }

            Battlefield2 = new ObservableCollection<Battlefield>();
            for (int i = 0; i < numberOfButtons; i++)
            {
                Battlefield2.Add(new Battlefield() { Player = Constans.Player.Player2, IsEmpty = true, Id = i });
            }

            BattlefieldShoot1 = new ObservableCollection<BattlefieldShoot>();
            BattlefieldShoot2 = new ObservableCollection<BattlefieldShoot>();

            for (int i = 0; i < numberOfButtons; i++)
            {
                BattlefieldShoot1.Add(
                    new BattlefieldShoot()
                    {
                        Player = Constans.Player.Player1,
                        IsEmpty = true,
                        IsShootGood = 0,
                        Id = i
                    });
            }

            for (int i = 0; i < numberOfButtons; i++)
            {
                BattlefieldShoot2.Add(
                    new BattlefieldShoot()
                    {
                        Player = Constans.Player.Player2,
                        IsEmpty = true,
                        IsShootGood = 0,
                        Id = i
                    });
            }
        }

        private void AddShipPosition(object obj)
        {
            Battlefield battlefield = obj as Battlefield;

            if (battlefield.Player == Constans.Player.Player1)
            {
                var found = Battlefield1.FirstOrDefault(x => x.Id == battlefield.Id);
                found.IsEmpty = false;
            }
            else
            {
                var found = Battlefield2.FirstOrDefault(x => x.Id == battlefield.Id);
                found.IsEmpty = false;
            }
        }

        private void ShootShipPosition(object obj)
        {
            var battlefield = obj as BattlefieldShoot;

            if (battlefield.Player == Constans.Player.Player2)
            {
                var found = Battlefield2.FirstOrDefault(x => x.Id == battlefield.Id);
                var foundShoot = BattlefieldShoot2.FirstOrDefault(x => x.Id == found.Id);

                if (found.IsEmpty == true)
                {
                    foundShoot.IsEmpty = false;
                    foundShoot.IsShootGood = 1;
                }
                else
                {
                    foundShoot.IsEmpty = false;
                    foundShoot.IsShootGood = 2;
                }
            }

            if (battlefield.Player == Constans.Player.Player1)
            {
                {
                    var found = Battlefield1.FirstOrDefault(x => x.Id == battlefield.Id);
                    var foundShoot = BattlefieldShoot1.FirstOrDefault(x => x.Id == found.Id);

                    if (found.IsEmpty == true)
                    {
                        foundShoot.IsEmpty = false;
                        foundShoot.IsShootGood = 1;
                    }
                    else
                    {
                        foundShoot.IsEmpty = false;
                        foundShoot.IsShootGood = 2;
                    }
                }
            }
        }
    }
}
