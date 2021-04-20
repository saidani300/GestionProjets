using GestionProjets.DBContext;
using GestionProjets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProjets.Repository
{
    public class RisqueRepository : IRisqueRepository
    {
        private readonly QualitasContext _dbContext;

        public RisqueRepository(QualitasContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteRisque(string RisqueId)
        {
            var Risque = _dbContext.Risques.Find(RisqueId);
            _dbContext.Risques.Remove(Risque);
            Save();
        }

        public Risque GetRisqueByID(string RisqueId)
        {
            return _dbContext.Risques.Find(RisqueId);
        }

        public IEnumerable<Risque> GetRisques()
        {
            return _dbContext.Risques.ToList();
        }

        public void InsertRisque(Risque Risque)
        {
            _dbContext.Add(Risque);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateRisque(Risque Risque)
        {
            _dbContext.Entry(Risque).State = EntityState.Modified;
            Save();
        }
    }
}
