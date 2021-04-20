using GestionProjets.DBContext;
using GestionProjets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProjets.Repository
{
    public class ObjectifRepository : IObjectifRepository
    {
        private readonly QualitasContext _dbContext;

        public ObjectifRepository(QualitasContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteObjectif(string ObjectifId)
        {
            var Objectif = _dbContext.Objectifs.Find(ObjectifId);
            _dbContext.Objectifs.Remove(Objectif);
            Save();
        }

        public Objectif GetObjectifByID(string ObjectifId)
        {
            return _dbContext.Objectifs.Find(ObjectifId);
        }

        public IEnumerable<Objectif> GetObjectifs()
        {
            return _dbContext.Objectifs.ToList();
        }

        public void InsertObjectif(Objectif Objectif)
        {
            _dbContext.Add(Objectif);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateObjectif(Objectif Objectif)
        {
            _dbContext.Entry(Objectif).State = EntityState.Modified;
            Save();
        }
    }
}
