using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WpfOrganization.DAL.EF;
using WpfOrganization.DAL.Entities;
using WpfOrganization.DAL.Interfaces;

namespace WpfOrganization.DAL.Repositories
{
    public class OrderOnCableTVRepository : IRepository<OrderOnCableTV>
    {
        private readonly DatabaseContext _db;

        public OrderOnCableTVRepository(DatabaseContext context)
        {
            _db = context;
        }

        public void Create(OrderOnCableTV order)
        {
            _db.OrdersOnCableTv.Add(order);
        }

        public void Delete(int id)
        {
            var order = _db.OrdersOnCableTv.Find(id);
            if (order != null)
            {
                _db.OrdersOnCableTv.Remove(order);
            }
        }

        public IEnumerable<OrderOnCableTV> Find(Func<OrderOnCableTV, bool> predicate)
        {
            return _db.OrdersOnCableTv.Where(predicate);
        }

        public OrderOnCableTV Get(int? id)
        {
            return _db.OrdersOnCableTv.Find(id);
        }

        public IEnumerable<OrderOnCableTV> GetAll()
        {
            return _db.OrdersOnCableTv;
        }

        public void Update(OrderOnCableTV order)
        {
            _db.Entry(order).State = EntityState.Modified;
        }
    }
}
