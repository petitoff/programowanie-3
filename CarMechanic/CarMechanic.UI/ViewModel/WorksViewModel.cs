using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarMechanic.Model;
using CarMechanic.UI.Command;
using CarMechanic.UI.Data;

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

            Works = new ObservableCollection<Work>();

            OpenSecondWindowEditCustomerCommand = new DelegateCommand(OnOpenSecondWindowEditCustomerExecute);
        }

        public DelegateCommand OpenSecondWindowEditCustomerCommand { get; }

        public ObservableCollection<Work> Works { get; set; }

        public void Initialize()
        {
            LoadWorks();
        }

        private async void LoadWorks()
        {
            //var works = await _workDataService.GetWorksByEmployerId(_userDataStore.CurrentUserId);
            //Works.Clear();
            //foreach (var work in works)
            //{
            //    Works.Add(work);
            //}
        }

        private void OnOpenSecondWindowEditCustomerExecute(object obj)
        {
            
        }
    }
}
