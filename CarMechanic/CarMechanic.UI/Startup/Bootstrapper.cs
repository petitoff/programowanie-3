using Autofac;
using CarMechanic.DataAccess;
using CarMechanic.UI.Data;
using CarMechanic.UI.ViewModel;
using CarMechanic.UI.ViewModel.CustomerService;
using CarMechanic.UI.ViewModel.WorkService;
using Prism.Events;

namespace CarMechanic.UI.Startup
{
    public class Bootstrapper
    {
        public IContainer BootStrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();
            builder.RegisterType<UserDataStore>().As<IUserDataStore>().SingleInstance();

            builder.RegisterType<CarMechanicDbContext>().AsSelf();

            builder.RegisterType<MainWindow>().AsSelf();

            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<DashboardViewModel>().AsSelf();
            builder.RegisterType<CustomersViewModel>().AsSelf();
            builder.RegisterType<WorksViewModel>().AsSelf();

            builder.RegisterType<AddCustomerViewModel>().AsSelf();
            builder.RegisterType<EditCustomerViewModel>().AsSelf();

            builder.RegisterType<AddWorkViewModel>().AsSelf();
            builder.RegisterType<EditWorkViewModel>().AsSelf();

            builder.RegisterType<CustomerDataService>().As<ICustomerDataService>();
            builder.RegisterType<EmployerDataService>().As<IEmployerDataService>();
            builder.RegisterType<WorkDataService>().As<IWorkDataService>();

            return builder.Build();
        }
    }
}
