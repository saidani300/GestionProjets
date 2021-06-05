using GestionProjets.DBContext;
using GestionProjets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProjets.Repository
{
    public class OpportuniteRepository : IOpportuniteRepository
    {
        private readonly QalitasContext _dbContext;

        public OpportuniteRepository(QalitasContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Opportunite> GetOpportunitesByProject(Guid ProjetId)
        {
            return _dbContext.Opportunites.Where(A => A.ProjetId == ProjetId);
        }
        public void DeleteOpportunite(Guid OpportuniteId)
        {
            var Opportunite = _dbContext.Opportunites.Find(OpportuniteId);
            _dbContext.Opportunites.Remove(Opportunite);
            Save();
        }

        public Opportunite GetOpportuniteByID(Guid OpportuniteId)
        {
            return _dbContext.Opportunites.Find(OpportuniteId);
        }

        public IEnumerable<Opportunite> GetOpportunites()
        {
            return _dbContext.Opportunites.ToList();
        }

        public void InsertOpportunite(Opportunite Opportunite)
        {
            _dbContext.Add(Opportunite);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateOpportunite(Opportunite Opportunite)
        {
            _dbContext.Entry(Opportunite).State = EntityState.Modified;
            Save();
        }
    }
}
