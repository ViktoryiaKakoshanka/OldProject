using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WpfOrganization.DAL.EF;
using WpfOrganization.DAL.Entities;
using WpfOrganization.DAL.Interfaces;

namespace WpfOrganization.DAL.Repositories
{
    public class CableTVProblemRepository : IRepository<CableTVProblem>
    {
        private readonly DatabaseContext _db;

        public CableTVProblemRepository(DatabaseContext context)
        {
            _db = context;
        }

        public void Create(CableTVProblem problem)
        {
            _db.CableTvProblems.Add(problem);
        }

        public void Delete(int id)
        {
            var problem = _db.CableTvProblems.Find(id);
            if (problem != null)
            {
                _db.CableTvProblems.Remove(problem);
            }
        }

        public IEnumerable<CableTVProblem> Find(Func<CableTVProblem, bool> predicate)
        {
            return _db.CableTvProblems.Where(predicate).ToList();
        }

        public CableTVProblem Get(int? id)
        {
            return _db.CableTvProblems.Find(id);
        }
        
        public IEnumerable<CableTVProblem> GetAll()
        {
            return _db.CableTvProblems;
        }

        public void Update(CableTVProblem problem)
        {
            _db.Entry(problem).State = EntityState.Modified;
        }

    }
}
