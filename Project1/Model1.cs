namespace Project1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<CableTVProblem> CableTVProblems { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Master> Masters { get; set; }
        public virtual DbSet<OrderOnCableTV> OrderOnCableTVs { get; set; }
        public virtual DbSet<OrderRepairAndRestruction> OrderRepairAndRestructions { get; set; }
        public virtual DbSet<Street> Streets { get; set; }
        public virtual DbSet<SubscriberRelationship> SubscriberRelationships { get; set; }
        public virtual DbSet<Subscriber> Subscribers { get; set; }
        public virtual DbSet<UserAction> UserActions { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasMany(e => e.Streets)
                .WithOptional(e => e.City)
                .HasForeignKey(e => e.City_Id);

            modelBuilder.Entity<City>()
                .HasMany(e => e.Masters)
                .WithMany(e => e.Cities)
                .Map(m => m.ToTable("MasterCities"));

            modelBuilder.Entity<Master>()
                .HasMany(e => e.OrderRepairAndRestructions)
                .WithOptional(e => e.Master)
                .HasForeignKey(e => e.MasterPerformerId);

            modelBuilder.Entity<Master>()
                .HasMany(e => e.OrderRepairAndRestructions1)
                .WithOptional(e => e.Master1)
                .HasForeignKey(e => e.ResponsibleMasterId);
        }
    }
}
