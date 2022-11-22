using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Battleship.Command;
using Battleship.Const;
using Battleship.Model;

namespace Battleship.ViewModel
{
    public class GameViewModel : BaseViewModel
    {
        private int _player1Score;
        private int _player2Score;

        private IsReady _isPlayer1Ready;
        private IsReady _isPlayer2Ready;

        private bool _isGameRunning;

        public AddShipPositionCommand AddShip { get; }
        public ShootShipPositionCommand ShootShip { get; }
        public ExecuteSubmitReadyCommand SubmitReadyPlayer1Command { get; }
        public ExecuteSubmitReadyCommand SubmitReadyPlayer2Command { get; }
        public ICommand RestartGameCommand { get; }

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

        public IsReady IsPlayer1Ready
        {
            get => _isPlayer1Ready;

            set
            {
                _isPlayer1Ready = value;
                OnPropertyChanged();
            }
        }

        public IsReady IsPlayer2Ready
        {
            get => _isPlayer2Ready;
            set
            {
                _isPlayer2Ready = value;
                OnPropertyChanged();
            }
        }

        public GameViewModel()
        {
            AddShip = new AddShipPositionCommand(AddShipPosition);
            ShootShip = new ShootShipPositionCommand(ShootShipPosition);
            SubmitReadyPlayer1Command = new ExecuteSubmitReadyCommand(SubmitReadyPositionPlayer1);
            SubmitReadyPlayer2Command = new ExecuteSubmitReadyCommand(SubmitReadyPositionPlayer2);
            RestartGameCommand = new ExecuteRestartGameCommand(this);

            Battlefield1 = new ObservableCollection<BattlefieldShoot>();
            BattlefieldShoot1 = new ObservableCollection<BattlefieldShoot>();
            BattlefieldShoot2 = new ObservableCollection<BattlefieldShoot>();
            Battlefield2 = new ObservableCollection<BattlefieldShoot>();

            InitBattlefield();
        }


        private void SubmitReadyPositionPlayer1(object obj)
        {
            IsPlayer1Ready = IsReady.Ready;
        }

        private void SubmitReadyPositionPlayer2(object obj)
        {
            IsPlayer2Ready = IsReady.Ready;
        }

        private void InitBattlefield()
        {
            const int numberOfButtons = 100;

            Battlefield1.Clear();
            BattlefieldShoot1.Clear();
            BattlefieldShoot2.Clear();
            Battlefield2.Clear();

            IsPlayer1Ready = IsReady.NotReady;
            IsPlayer2Ready = IsReady.NotReady;

            for (int i = 0; i < numberOfButtons; i++)
            {
                Battlefield1.Add(new BattlefieldShoot { Player = Player.Player1, Id = i });
            }

            for (int i = 0; i < numberOfButtons; i++)
            {
                Battlefield2.Add(new BattlefieldShoot { Player = Player.Player2, Id = i });
            }

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
                if (IsPlayer1Ready == IsReady.Ready)
                {
                    return;
                }

                var found = Battlefield1.FirstOrDefault(x => x.Id == battlefield.Id);
                if (found != null) found.IsShootGood = IsShootGoodEnum.Occupied;
            }
            else
            {
                if (IsPlayer2Ready == IsReady.Ready)
                {
                    return;
                }

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

        private void ChangeOptions(object obj)
        {

        }

        public void SubmitReady()
        {
            throw new System.NotImplementedException();
        }

        public void RestartGame()
        {
            InitBattlefield();
        }
    }
}
