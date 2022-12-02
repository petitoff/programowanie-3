using System.Collections.ObjectModel;
using lista_3.Model;

namespace lista_3.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<Customer> Customers { get; }

        public MainViewModel()
        {
            Customers = new ObservableCollection<Customer>
                {
                    new Customer { FirstName = "John", LastName = "Smith" },
                    new Customer { FirstName = "Jane", LastName = "Doe"},
                    new Customer { FirstName = "Jack", LastName = "Black"}
                };
        }
    }
}
