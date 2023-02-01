using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarMechanic.Model;

namespace CarMechanic.UI.ViewModel.WorkService
{
    public class WorkItemViewModel : BaseViewModel
    {
        private string _displayMember;
        private readonly Work _work;

        public WorkItemViewModel(Work work, string displayMember = null)
        {
            _work = work;
            _displayMember = displayMember;
        }

        public Work Work => _work;

        public string DisplayMember
        {
            get => _displayMember;
            set
            {
                _displayMember = value;
                OnPropertyChanged();
            }
        }

        public int Id
        {
            get => _work.Id;
            set
            {
                _work.Id = value;
                OnPropertyChanged();
            }
        }

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

        public decimal Price
        {
            get => _work.Price;
            set
            {
                _work.Price = value;
                OnPropertyChanged();
            }
        }

        public int Time
        {
            get => _work.Time;
            set
            {
                _work.Time = value;
                OnPropertyChanged();
            }
        }

    }
}
