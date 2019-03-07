using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WpfOrganization.DAL.EF;
using WpfOrganization.DAL.Entities;
using WpfOrganization.DAL.Interfaces;

namespace WpfOrganization.DAL.Repositories
{
    public class OrderRepairAndRestructionRepository : IRepository<OrderRepairAndRestruction>
    {
        private readonly DatabaseContext _db;

        public OrderRepairAndRestructionRepository(DatabaseContext context)
        {
            _db = context;
        }

        public void Create(OrderRepairAndRestruction order)
        {
            _db.OrdersRepairAndRestruction.Add(order);
        }

        public void Delete(int id)
        {
            var order = _db.OrdersRepairAndRestruction.Find(id);
            if (order != null)
            {
                _db.OrdersRepairAndRestruction.Remove(order);
            }
        }

        public IEnumerable<OrderRepairAndRestruction> Find(Func<OrderRepairAndRestruction, bool> predicate)
        {
            return _db.OrdersRepairAndRestruction.Where(predicate).ToList();
        }

        public OrderRepairAndRestruction Get(int? id)
        {
            return _db.OrdersRepairAndRestruction.Find(id);
        }

        public IEnumerable<OrderRepairAndRestruction> GetAll()
        {
            return _db.OrdersRepairAndRestruction;
        }

        public void Update(OrderRepairAndRestruction order)
        {
            _db.Entry(order).State = EntityState.Modified;
        }
    }
}
