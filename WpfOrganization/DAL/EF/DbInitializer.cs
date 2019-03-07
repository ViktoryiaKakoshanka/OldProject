using System.Data.Entity;
using WpfOrganization.DAL.Entities;

namespace WpfOrganization.DAL.EF
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext db)
        {
            db.StreetTypes.Add(new StreetType { ShortStreetTypeName = "ул." , FullStreetTypeName = "улица"} );
            db.SaveChanges();
        }
    }
}
