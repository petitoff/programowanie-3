using Battleship.View;
using System.Windows;

namespace Battleship
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            var _vieModel = new ViewModel.GameViewModel();
            this.DataContext = _vieModel;

            // create new windows Player2
            Player2 player2 = new Player2();
            player2.DataContext = _vieModel;
            player2.Show();
        }
    }
}
