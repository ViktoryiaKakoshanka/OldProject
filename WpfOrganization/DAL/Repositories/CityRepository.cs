using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WpfOrganization.DAL.EF;
using WpfOrganization.DAL.Entities;
using WpfOrganization.DAL.Interfaces;

namespace WpfOrganization.DAL.Repositories
{
    public class CityRepository : IRepository<City>
    {
        private readonly DatabaseContext _db;

        public CityRepository(DatabaseContext context)
        {
            _db = context;
        }

        public void Create(City city)
        {
            _db.Cities.Add(city);
        }

        public void Delete(int id)
        {
            var city = _db.Cities.Find(id);
            if ( city != null )
            {
                _db.Cities.Remove(city);
            }
        }

        public IEnumerable<City> Find(Func<City, bool> predicate)
        {
            return _db.Cities.Where(predicate);
        }

        public City Get(int? id)
        {
            return _db.Cities.Find(id);
        }

        public IEnumerable<City> GetAll()
        {
            return _db.Cities;
        }

        public void Update(City city)
        {
            _db.Entry(city).State = EntityState.Modified;
        }
    }
}
