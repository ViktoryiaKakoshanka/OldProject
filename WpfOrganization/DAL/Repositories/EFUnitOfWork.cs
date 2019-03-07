using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfOrganization.DAL.EF;
using WpfOrganization.DAL.Entities;
using WpfOrganization.DAL.Interfaces;

namespace WpfOrganization.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private DatabaseContext _db;
        
        private IRepository<Master> _masters;
        private IRepository<CableTVProblem> _cableTVProblems;
        private IRepository<OrderOnCableTV> _orderOnCableTV;
        private IRepository<OrderRepairAndRestruction> _orderRepairAndRestruction;

        private bool _disposed;

        public EFUnitOfWork(string connectionString)
        {
            _db = new DatabaseContext(connectionString);
        }

        public IRepository<Master> Masters { get => _masters ?? (_masters = new MasterRepository(_db)); }

        public IRepository<CableTVProblem> CableTVProblems
        {
            get => _cableTVProblems ?? (_cableTVProblems = new CableTVProblemRepository(_db));
        }
        
        public IRepository<OrderOnCableTV> OrdersOnCableTV { get => _orderOnCableTV ?? (_orderOnCableTV = new OrderOnCableTVRepository(_db)); }

        public IRepository<OrderRepairAndRestruction> OrdersRepairAndRestruction
        {
            get => _orderRepairAndRestruction ?? (_orderRepairAndRestruction = new OrderRepairAndRestructionRepository(_db));
        }

        public IRepository<City> Cities => throw new NotImplementedException();

        public IRepository<Street> Streets => throw new NotImplementedException();

        public IRepository<StreetType> StreetTypes => throw new NotImplementedException();

        public IRepository<Subscriber> Subscribers => throw new NotImplementedException();

        public IRepository<RelationshipType> RelationshipTypes => throw new NotImplementedException();

        public IRepository<SubscriberRelationship> SubscriberRelationships => throw new NotImplementedException();

        public IRepository<User> Users => throw new NotImplementedException();

        public IRepository<UserAction> UserActionHistory => throw new NotImplementedException();

        public void Save()
        {
            _db.SaveChanges();
        }


        public virtual void Dispose(bool dicposing)
        {
            if ( ! _disposed )
            {
                if (dicposing)
                {
                    _db.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
