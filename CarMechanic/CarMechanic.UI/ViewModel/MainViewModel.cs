using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CarMechanic.Model;
using CarMechanic.UI.Command;
using CarMechanic.UI.Data;
using Prism.Events;

namespace CarMechanic.UI.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private string _nameOfUser;
        private string _roleOfUser;
        private readonly IEmployerDataService _employerDataService;
        private BaseViewModel _selectedViewModel;
        private readonly IUserDataStore _userDataStore;

        public MainViewModel(IEmployerDataService employerDataService, DashboardViewModel dashboardViewModel,
            CustomersViewModel customersViewModel, WorksViewModel worksViewModel, IEventAggregator eventAggregator, IUserDataStore userDataStore)
        {
            _employerDataService = employerDataService;
            _userDataStore = userDataStore;

            Employers = new ObservableCollection<Employer>();

            DashboardViewModel = dashboardViewModel;
            SelectedViewModel = DashboardViewModel;
            CustomersViewModel = customersViewModel;
            WorksViewModel = worksViewModel;

            GoToDashboardCommand = new DelegateCommand(GoToDashboard);
            GoToCustomersCommand = new DelegateCommand(GoToCustomers);
            GoToWorksCommand = new DelegateCommand(GoToWorks);
        }

        public ObservableCollection<Employer> Employers { get; set; }

        public DashboardViewModel DashboardViewModel { get; }
        public CustomersViewModel CustomersViewModel { get; }
        public WorksViewModel WorksViewModel { get; }
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public DelegateCommand GoToDashboardCommand { get; }
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public DelegateCommand GoToCustomersCommand { get; }
        public DelegateCommand GoToWorksCommand { get; }

        public BaseViewModel SelectedViewModel
        {
            get => _selectedViewModel;
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged();
            }
        }

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
            var employer = await _employerDataService.GetEmployerById(_userDataStore.CurrentUserId);

            NameOfUser = $"{employer?.FirstName} {employer?.LastName}";
            RoleOfUser = $"{employer?.Role}";
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
        
        private void GoToWorks(object obj)
        {
            WorksViewModel.Initialize();
            SelectedViewModel = WorksViewModel;
        }
    }
}
