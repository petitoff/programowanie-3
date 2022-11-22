using Battleship.Const;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Battleship.Model
{
    public class BattlefieldShoot : INotifyPropertyChanged
    {
        private IsShootGoodEnum _isShootGood;
        private bool _isPlayerReady;

        public int[,] Field { get; set; }

        public Player Player { get; set; }
        public IsShootGoodEnum IsShootGood
        {
            get => _isShootGood;
            set
            {
                _isShootGood = value;
                OnPropertyChanged();
            }
        }

        public bool IsPlayerReady
        {
            get => _isPlayerReady;
            set
            {
                _isPlayerReady = value;
                OnPropertyChanged();
            }
        }

        public int Id { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
