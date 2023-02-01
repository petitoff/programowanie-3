using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarMechanic.Model;
using CarMechanic.UI.Command;
using CarMechanic.UI.Data;
using Prism.Events;

namespace CarMechanic.UI.ViewModel.WorkService
{
    public class AddWorkViewModel : BaseViewModel
    {
        private readonly Work _work;
        private readonly IWorkDataService _workDataService;
        private readonly IUserDataStore _userDataStore;
        private readonly IEventAggregator _eventAggregator;

        public AddWorkViewModel(IEventAggregator eventAggregator, IWorkDataService workDataService, IUserDataStore userDataStore)
        {
            _eventAggregator = eventAggregator;
            _workDataService = workDataService;
            _userDataStore = userDataStore;
            _work = new Work();
            _work.Customer = new Customer() { EmployerId = _userDataStore.CurrentUserId };

            AddWorkCommand = new DelegateCommand(AddWork);
        }

        public DelegateCommand AddWorkCommand { get; }

        public string Name
        {
            get => _work.Name;
            set
            {
                _work.Name = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get => _work.Description;
            set
            {
                _work.Description = value;
                OnPropertyChanged();
            }
        }

        public string Price
        {
            get => _work.Price.ToString();
            set
            {
                _work.Price = decimal.Parse(value);
                OnPropertyChanged();
            }
        }

        public string FirstName
        {
            get => _work.Customer.FirstName;
            set
            {
                _work.Customer.FirstName = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get => _work.Customer.LastName;
            set
            {
                _work.Customer.LastName = value;
                OnPropertyChanged();
            }
        }

        private void AddWork(object obj)
        {
            _workDataService.AddWorkToEmployerAndCustomer(_work, _userDataStore.CurrentUserId);
            //_eventAggregator.GetEvent<UpdateWorkListEvent>().Publish(_work);
        }
    }
}
