using System.Collections.ObjectModel;
using lista_3.Model;

namespace lista_3.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public readonly CustomersViewModel CustomersViewModel;
        private BaseViewModel _selectedViewModel;

        public MainViewModel()
        {
            CustomersViewModel = new CustomersViewModel();
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
