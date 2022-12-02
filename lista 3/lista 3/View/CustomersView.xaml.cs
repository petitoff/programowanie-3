using lista_3.Model;
using System.Windows.Controls;
using System.Windows.Input;

namespace lista_3.View
{
    /// <summary>
    /// Interaction logic for CustomersView.xaml
    /// </summary>
    public partial class CustomersView : UserControl
    {
        public CustomersView()
        {
            InitializeComponent();
        }

        private void EventSetter_OnHandler(object sender, MouseButtonEventArgs e)
        {
            if (sender is DataGridRow row)
            {
                var emp = row.DataContext as Customer;
            }
        }
    }
}
