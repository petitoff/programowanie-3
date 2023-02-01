using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarMechanic.Model;

namespace CarMechanic.UI.ViewModel.WorkService
{
    public class EditWorkViewModel : BaseViewModel
    {
        private Work _work;

        public EditWorkViewModel()
        {
            Work = new Work();
            Work.Customer = new Customer();
        }

        public Work Work
        {
            get => _work;
            set
            {
                _work = value;
                OnPropertyChanged();
            }
        }

        public void InitializeWork(Work work)
        {
            Work = work;
        }
    }
}
