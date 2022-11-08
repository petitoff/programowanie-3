using Battleship.Constans;
using System.ComponentModel;

namespace Battleship.Model
{
    public class Battlefield : INotifyPropertyChanged
    {
        public int[,] Field { get; set; }
        private bool _isEmpty { get; set; }
        public bool IsEmpty
        {
            get { return _isEmpty; }
            set
            {
                _isEmpty = value;
                OnPropertyChanged();
            }
        }

        public Player Player { get; set; }
        public int Id { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
