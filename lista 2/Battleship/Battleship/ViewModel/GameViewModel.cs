using System.Collections.ObjectModel;
using System.Linq;
using Battleship.Command;
using Battleship.Const;
using Battleship.Model;

namespace Battleship.ViewModel
{
    class GameViewModel : BaseViewModel
    {
        private int _player1Score;
        private int _player2Score;

        public AddShipPositionCommand AddShip { get; }
        public ShootShipPositionCommand ShootShip { get; }

        public ObservableCollection<BattlefieldShoot> Battlefield1 { get; }
        public ObservableCollection<BattlefieldShoot> BattlefieldShoot1 { get; }
        public ObservableCollection<BattlefieldShoot> Battlefield2 { get; }
        public ObservableCollection<BattlefieldShoot> BattlefieldShoot2 { get; }

        public int Player1Score
        {
            get => _player1Score;
            set
            {
                _player1Score = value;
                OnPropertyChanged();
            }
        }

        public int Player2Score
        {
            get => _player2Score;
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

            const int numberOfButtons = 100;

            Battlefield1 = new ObservableCollection<BattlefieldShoot>();
            for (int i = 0; i < numberOfButtons; i++)
            {
                Battlefield1.Add(new BattlefieldShoot { Player = Player.Player1, Id = i });
            }

            Battlefield2 = new ObservableCollection<BattlefieldShoot>();
            for (int i = 0; i < numberOfButtons; i++)
            {
                Battlefield2.Add(new BattlefieldShoot { Player = Player.Player2, Id = i });
            }

            BattlefieldShoot1 = new ObservableCollection<BattlefieldShoot>();
            BattlefieldShoot2 = new ObservableCollection<BattlefieldShoot>();

            for (int i = 0; i < numberOfButtons; i++)
            {
                BattlefieldShoot1.Add(
                    new BattlefieldShoot
                    {
                        Player = Player.Player1,
                        IsShootGood = IsShootGoodEnum.Empty,
                        Id = i
                    });
            }

            for (int i = 0; i < numberOfButtons; i++)
            {
                BattlefieldShoot2.Add(
                    new BattlefieldShoot
                    {
                        Player = Player.Player2,
                        IsShootGood = IsShootGoodEnum.Empty,
                        Id = i
                    });
            }
        }

        private void AddShipPosition(object obj)
        {
            if (!(obj is BattlefieldShoot battlefield))
            {
                return;
            }

            if (battlefield.Player == Player.Player1)
            {
                var found = Battlefield1.FirstOrDefault(x => x.Id == battlefield.Id);
                if (found != null) found.IsShootGood = IsShootGoodEnum.Occupied;
            }
            else
            {
                var found = Battlefield2.FirstOrDefault(x => x.Id == battlefield.Id);
                if (found != null) found.IsShootGood = IsShootGoodEnum.Occupied;
            }
        }

        private void ShootShipPosition(object obj)
        {
            if (!(obj is BattlefieldShoot battlefield))
            {
                return;
            }

            ValidateShoot(battlefield);
        }

        private void ValidateShoot(BattlefieldShoot battlefield)
        {

            var found = battlefield.Player == Player.Player1 ? Battlefield1.FirstOrDefault(x => x.Id == battlefield.Id) : Battlefield2.FirstOrDefault(x => x.Id == battlefield.Id);
            if (found == null)
            {
                return;
            }

            var foundShoot = battlefield.Player == Player.Player1 ? BattlefieldShoot1.FirstOrDefault(x => x.Id == found.Id) : BattlefieldShoot2.FirstOrDefault(x => x.Id == found.Id);
            if (foundShoot == null)
            {
                return;
            }

            if (found.IsShootGood != IsShootGoodEnum.Occupied)
            {
                foundShoot.IsShootGood = IsShootGoodEnum.Miss;
                found.IsShootGood = IsShootGoodEnum.Miss;
            }
            else
            {
                foundShoot.IsShootGood = IsShootGoodEnum.Hit;
                found.IsShootGood = IsShootGoodEnum.Hit;
            }
        }
    }
}
