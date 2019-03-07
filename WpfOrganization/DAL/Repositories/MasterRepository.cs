using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WpfOrganization.DAL.EF;
using WpfOrganization.DAL.Entities;
using WpfOrganization.DAL.Interfaces;

namespace WpfOrganization.DAL.Repositories
{
    class MasterRepository : IRepository<Master>
    {
        private readonly DatabaseContext _db;

        public MasterRepository(DatabaseContext context)
        {
            _db = context;
        }

        public void Create(Master master)
        {
            _db.Masters.Add(master);
        }

        public void Delete(int id)
        {
            var master = _db.Masters.Find(id);
            if (master != null)
            {
                _db.Masters.Remove(master);
            }
        }

        public IEnumerable<Master> Find(Func<Master, bool> predicate)
        {
            return _db.Masters.Where(predicate).ToList();
        }

        public Master Get(int? id)
        {
            return _db.Masters.Find(id);
        }

        public IEnumerable<Master> GetAll()
        {
            return _db.Masters;
        }

        public void Update(Master master)
        {
            _db.Entry(master).State = EntityState.Modified;
        }
    }
}
