using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CarMechanic.Model;
using CarMechanic.UI.Command;
using CarMechanic.UI.Data;

namespace CarMechanic.UI.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private string _nameOfUser;
        private string _roleOfUser;
        private readonly IEmployerDataService _employerDataService;
        private BaseViewModel _selectedViewModel;

        public MainViewModel(IEmployerDataService employerDataService, DashboardViewModel dashboardViewModel, CustomersViewModel customersViewModel)
        {
            _employerDataService = employerDataService;
            Employers = new ObservableCollection<Employer>();

            DashboardViewModel = dashboardViewModel;
            SelectedViewModel = DashboardViewModel;
            CustomersViewModel = customersViewModel;

            GoToDashboardCommand = new DelegateCommand(GoToDashboard);
            GoToCustomersCommand = new DelegateCommand(GoToCustomers);
        }

        public ObservableCollection<Employer> Employers { get; set; }

        public BaseViewModel SelectedViewModel
        {
            get => _selectedViewModel;
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged();
            }
        }
        
        public DashboardViewModel DashboardViewModel { get; }
        public CustomersViewModel CustomersViewModel { get; }
        public DelegateCommand GoToDashboardCommand { get; set; }
        public DelegateCommand GoToCustomersCommand { get; set; }


        public string NameOfUser
        {
            get => _nameOfUser;
            set
            {
                _nameOfUser = value;
                OnPropertyChanged();
            }
        }

        public string RoleOfUser
        {
            get => _roleOfUser;
            set
            {
                _roleOfUser = value;
                OnPropertyChanged();
            }
        }

        public async Task OnLoad()
        {
            var employers = await _employerDataService.GetAllEmployers();
            Employers.Clear();
            foreach (var employer in employers)
            {
                Employers.Add(employer);
            }

            NameOfUser = $"{Employers[0].FirstName} {Employers[0].LastName}";
            RoleOfUser = $"{Employers[0].Role}";
        }

        private void GoToDashboard(object obj)
        {
            SelectedViewModel = DashboardViewModel;
        }


        private void GoToCustomers(object obj)
        {
            CustomersViewModel.Initialize();
            SelectedViewModel = CustomersViewModel;
        }
    }
}
