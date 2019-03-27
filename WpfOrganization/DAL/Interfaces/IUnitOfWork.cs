using System;
using WpfOrganization.DAL.Entities;

namespace WpfOrganization.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Master> Masters { get; }
        IGenericRepository<CableTVProblem> CableTVProblems { get; }
        IGenericRepository<OrderOnCableTV> OrdersOnCableTV { get; }
        IGenericRepository<OrderRepairAndRestruction> OrdersRepairAndRestruction { get; }

        IGenericRepository<City> Cities { get; }
        IGenericRepository<Street> Streets { get; }

        IGenericRepository<Subscriber> Subscribers { get; }
        IGenericRepository<SubscriberRelationship> SubscriberRelationships { get; }

        IGenericRepository<User> Users { get; }
        IGenericRepository<UserAction> UserActionHistory { get; }

        void Save();
    }
}
