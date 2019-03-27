using System.Data.Entity;
using WpfOrganization.DAL.Entities;

namespace WpfOrganization.DAL.EF
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Master> Masters { get; set; }
        
        public DbSet<CableTVProblem> CableTvProblems { get; set; }
        public DbSet<OrderOnCableTV> OrdersOnCableTv { get; set; }
        public DbSet<OrderRepairAndRestruction> OrdersRepairAndRestruction { get; set; }

        public DbSet<City> Cities { get; set; }
        public DbSet<Street> Streets { get; set; }

        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<SubscriberRelationship> SubscriberRelationships { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<UserAction> UserActions { get; set; }

        static DatabaseContext()
        {
            Database.SetInitializer(new DbInitializer());
        }

        public DatabaseContext(string connectionString) : base(connectionString)
        {

        }
    }
}
