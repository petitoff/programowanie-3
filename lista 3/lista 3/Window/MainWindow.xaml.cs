using System.Windows;
using lista_3.ViewModel;

namespace lista_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        private readonly MainViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();

            _viewModel = new MainViewModel(new CustomersViewModel());
            DataContext = _viewModel;
        }
    }
}
