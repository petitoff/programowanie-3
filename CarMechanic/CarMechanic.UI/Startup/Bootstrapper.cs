using Autofac;
using CarMechanic.DataAccess;
using CarMechanic.UI.Data;
using CarMechanic.UI.ViewModel;

namespace CarMechanic.UI.Startup
{
    public class Bootstrapper
    {
        public IContainer BootStrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<CarMechanicDbContext>().AsSelf();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();

            builder.RegisterType<CustomerDataService>().As<ICustomerDataService>();

            return builder.Build();
        }
    }
}
