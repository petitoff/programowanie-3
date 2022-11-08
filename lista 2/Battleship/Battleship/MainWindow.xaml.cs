using Battleship.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Battleship
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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

        private void AddTaskItem_OnClick(object sender, RoutedEventArgs e)
        {
        }
    }
}
