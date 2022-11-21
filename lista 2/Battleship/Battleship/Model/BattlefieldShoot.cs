using Battleship.Constans;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Battleship.Model
{
    public class BattlefieldShoot : INotifyPropertyChanged
    {
        private bool _isEmpty { get; set; }
        private int _isShootGood { get; set; }

        public int[,] Field { get; set; }

        public Player Player { get; set; }
        public int Id { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsEmpty
        {
            get { return _isEmpty; }
            set
            {
                _isEmpty = value;
                OnPropertyChanged();
            }
        }
        
        public int IsShootGood
        {
            get { return _isShootGood; }
            set
            {
                _isShootGood = value;
                OnPropertyChanged();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
