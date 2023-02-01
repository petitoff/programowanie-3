using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarMechanic.Model;
using CarMechanic.UI.Command;
using CarMechanic.UI.Data;
using CarMechanic.UI.ViewModel.WorkService;

namespace CarMechanic.UI.ViewModel
{
    public class WorksViewModel : BaseViewModel
    {
        private readonly IWorkDataService _workDataService;
        private readonly IUserDataStore _userDataStore;

        public WorksViewModel(IWorkDataService workDataService, IUserDataStore userDataStore)
        {
            _workDataService = workDataService;
            _userDataStore = userDataStore;

            Works = new ObservableCollection<WorkItemViewModel>();

            OpenSecondWindowEditCustomerCommand = new DelegateCommand(OnOpenSecondWindowEditCustomerExecute);
        }

        public DelegateCommand OpenSecondWindowEditCustomerCommand { get; }

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

        private void OnOpenSecondWindowEditCustomerExecute(object obj)
        {
            
        }
    }
}
