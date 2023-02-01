using System.Collections.ObjectModel;
using CarMechanic.Model;
using CarMechanic.UI.Command;
using CarMechanic.UI.Data;
using CarMechanic.UI.ViewModel.WorkService;
using CarMechanic.UI.Window;

namespace CarMechanic.UI.ViewModel
{
    public class WorksViewModel : BaseViewModel
    {
        private readonly IWorkDataService _workDataService;
        private readonly IUserDataStore _userDataStore;
        private BaseViewModel _selectedViewModel;

        public WorksViewModel(IWorkDataService workDataService, IUserDataStore userDataStore, AddWorkViewModel addWorkViewModel, EditWorkViewModel editWorkViewModel)
        {
            _workDataService = workDataService;
            _userDataStore = userDataStore;

            Works = new ObservableCollection<WorkItemViewModel>();
            AddWorkViewModel = addWorkViewModel;
            EditWorkViewModel = editWorkViewModel;
            SelectedViewModel = AddWorkViewModel;

            OpenSecondWindowAddWorkCommand = new DelegateCommand(OnOpenSecondWindowAddWorkExecute);
            OpenSecondWindowEditWorkCommand = new DelegateCommand(OnOpenSecondWindowEditWorkExecute);
        }

        
        public BaseViewModel SelectedViewModel { get => _selectedViewModel;
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged();
            }
        }
        public AddWorkViewModel AddWorkViewModel { get; set; }
        public EditWorkViewModel EditWorkViewModel { get; set; }

        public DelegateCommand OpenSecondWindowAddWorkCommand { get; set; }

        public DelegateCommand OpenSecondWindowEditWorkCommand { get; }

        public ObservableCollection<WorkItemViewModel> Works { get; set; }

        

        public void Initialize()
        {
            LoadWorks();
        }

        private async void LoadWorks()
        {
            var works = await _workDataService.GetWorksWithCustomerByEmployerId(_userDataStore.CurrentUserId);
            Works.Clear();
            foreach (var work in works)
            {
                Works.Add(new WorkItemViewModel(work, $"{work.Customer.FirstName} {work.Customer.LastName}"));
            }
        }

        private void OnOpenSecondWindowAddWorkExecute(object obj)
        {
            SelectedViewModel = AddWorkViewModel;
            OpenSecondWindow();
        }


        private void OnOpenSecondWindowEditWorkExecute(object obj)
        {
            // create from obj a work, obj is a WorkItemViewModel
            var work = new Work();
            var workItemViewModel = (WorkItemViewModel)obj;
            work = workItemViewModel.Work;

            EditWorkViewModel.InitializeWork(work);
            SelectedViewModel = EditWorkViewModel;
            OpenSecondWindow();
        }

        private void OpenSecondWindow()
        {
            var secondWindow = new SecondWindow
            {
                DataContext = this
            };
            secondWindow.Show();
        }
    }
}
