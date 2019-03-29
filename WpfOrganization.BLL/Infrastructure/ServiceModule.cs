using Ninject.Modules;
using WpfOrganization.DAL.Interfaces;
using WpfOrganization.DAL.Repositories;

namespace WpfOrganization.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private readonly string _connectionString;

        public ServiceModule(string connection)
        {
            _connectionString = connection;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(_connectionString);
        }
    }
}
