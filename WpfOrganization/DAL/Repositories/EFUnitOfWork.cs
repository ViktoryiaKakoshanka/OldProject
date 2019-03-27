using System;
using WpfOrganization.DAL.EF;
using WpfOrganization.DAL.Entities;
using WpfOrganization.DAL.Interfaces;

namespace WpfOrganization.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork, IDisposable
    {
        private DatabaseContext _db;
        
        private IGenericRepository<Master> _masters;
        private IGenericRepository<CableTVProblem> _cableTVProblems;
        private IGenericRepository<OrderOnCableTV> _orderOnCableTV;
        private IGenericRepository<OrderRepairAndRestruction> _orderRepairAndRestruction;
        private IGenericRepository<City> _cities;
        private IGenericRepository<Street> _streets;
        private IGenericRepository<Subscriber> _subscribers;
        private IGenericRepository<SubscriberRelationship> _subscriberrelationships;
        private IGenericRepository<User> _user;
        private IGenericRepository<UserAction> _userActionHistory;

        private bool _disposed;

        public EFUnitOfWork(string connectionString)
        {
            _db = new DatabaseContext(connectionString);
        }

        public IGenericRepository<Master> Masters
        {
            get => _masters ?? (_masters = new GenericRepository<Master>(_db, _db.Masters));
        }

        public IGenericRepository<CableTVProblem> CableTVProblems
        {
            get => _cableTVProblems ??
                   (_cableTVProblems = new GenericRepository<CableTVProblem>(_db, _db.CableTvProblems));
        }

        public IGenericRepository<OrderOnCableTV> OrdersOnCableTV
        {
            get => _orderOnCableTV ??
                   (_orderOnCableTV = new GenericRepository<OrderOnCableTV>(_db, _db.OrdersOnCableTv));
        }

        public IGenericRepository<OrderRepairAndRestruction> OrdersRepairAndRestruction
        {
            get => _orderRepairAndRestruction ?? (_orderRepairAndRestruction = new GenericRepository<OrderRepairAndRestruction>(_db, _db.OrdersRepairAndRestruction));
        }

        public IGenericRepository<City> Cities
        {
            get => _cities ?? (_cities = new GenericRepository<City>(_db, _db.Cities));
        }

        public IGenericRepository<Street> Streets
        {
            get => _streets ?? (_streets = new GenericRepository<Street>(_db, _db.Streets));
        }
        
        public IGenericRepository<Subscriber> Subscribers
        {
            get => _subscribers ?? (_subscribers = new GenericRepository<Subscriber>(_db, _db.Subscribers));
        }
        
        public IGenericRepository<SubscriberRelationship> SubscriberRelationships
        {
            get => _subscriberrelationships ?? (_subscriberrelationships =
                       new GenericRepository<SubscriberRelationship>(_db, _db.SubscriberRelationships));
        }

        public IGenericRepository<User> Users
        {
            get => _user ?? (_user = new GenericRepository<User>(_db, _db.Users));
        }

        public IGenericRepository<UserAction> UserActionHistory
        {
            get => _userActionHistory ?? (_userActionHistory = new GenericRepository<UserAction>(_db, _db.UserActions));
        }

        public ViewModel.OrderOnCableTVViewModel OrderOnCableTVViewModel
        {
            get => default(ViewModel.OrderOnCableTVViewModel);
            set
            {
            }
        }

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
