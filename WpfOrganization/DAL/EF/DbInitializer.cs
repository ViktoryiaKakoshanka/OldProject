using System.Data.Entity;
using WpfOrganization.DAL.Entities;

namespace WpfOrganization.DAL.EF
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext db)
        {
            db.StreetTypes.Add(new StreetType { ShortStreetTypeName = "ул." , FullStreetTypeName = "улица"} );
            db.Masters.Add(new Master
            {
                OrdersOnCableTv = null,
                FullName = new FullName {Name = "A", Surname = "M", Patronymic = "S"},
                Brigade = false,
                ComplitedOrderRepairAndRestructionListByMaster = null,
                HomePhone = "+375",
                MobilePhone = "",
                OrdersRepairAndRestructionAccountableToMaster = null,
                SecondHomePhone = null,
                SecondMobilePhone = null,
                SecondWorkPhone = null,
                WorkPhone = null
            });
            db.SaveChanges();
        }
    }
}
