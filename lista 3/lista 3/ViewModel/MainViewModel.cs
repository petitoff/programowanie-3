namespace lista_3.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public CustomersViewModel CustomersViewModel { get; set; }
        private BaseViewModel _selectedViewModel;

        public MainViewModel(CustomersViewModel customersViewModel)
        {
            CustomersViewModel = customersViewModel;
            SelectedViewModel = CustomersViewModel;
        }

        public BaseViewModel SelectedViewModel
        {
            get => _selectedViewModel;
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged();
            }
        }
    }
}
