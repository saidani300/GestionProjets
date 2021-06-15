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
        private readonly QalitasContext _dbContext;

        public RisqueRepository(QalitasContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IEnumerable<Risque> GetRisquesByProjet(Guid ProjetId)
        {
            return _dbContext.Projets.Where(A => A.Id == ProjetId).FirstOrDefault().Risques;
        }

        public Risque GetRisqueByID(Guid RisqueId)
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


        public void UpdateRisque(Risque Risque)
        {
            _dbContext.Entry(Risque).State = EntityState.Modified;
            Save();
        }

        public void DeleteRisque(Guid RisqueId)
        {
            var Risque = _dbContext.Risques.Find(RisqueId);
            _dbContext.Risques.Remove(Risque);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
