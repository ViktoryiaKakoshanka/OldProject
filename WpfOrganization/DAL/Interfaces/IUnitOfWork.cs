using WpfOrganization.DAL.Entities;

namespace WpfOrganization.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Master> Masters { get; }
        IRepository<CableTVProblem> CableTVProblems { get; }
        IRepository<OrderOnCableTV> OrdersOnCableTV { get; }
        IRepository<OrderRepairAndRestruction> OrdersRepairAndRestruction { get; }

        IRepository<City> Cities { get; }
        IRepository<Street> Streets { get; }
        IRepository<StreetType> StreetTypes { get; }

        IRepository<Subscriber> Subscribers { get; }
        IRepository<RelationshipType> RelationshipTypes { get; }
        IRepository<SubscriberRelationship> SubscriberRelationships { get; }

        IRepository<User> Users { get; }
        IRepository<UserAction> UserActionHistory { get; }

        void Save();
    }
}
