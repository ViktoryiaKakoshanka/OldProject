using WpfOrganization.DAL.Interfaces;
using WpfOrganization.DAL.Repositories;

namespace WpfOrganization.DAL
{
    public static class TemporaryUnitOfWork
    {
        public static readonly IUnitOfWork Database = new EFUnitOfWork(@"Data Source=.\SQLEXPRESS;Initial Catalog=CableTV;Integrated Security=True");
    }
}
