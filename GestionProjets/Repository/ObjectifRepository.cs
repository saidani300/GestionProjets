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
        private readonly QalitasContext _dbContext;

        public ObjectifRepository(QalitasContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Objectif> GetobjectifsByProject(Guid ProjetId)
        {
            return _dbContext.Objectifs.Where(A => A.ProjetId == ProjetId);
        }

        public void DeleteObjectif(Guid ObjectifId)
        {
            var Objectif = _dbContext.Objectifs.Find(ObjectifId);
            _dbContext.Objectifs.Remove(Objectif);
            Save();
        }


        public Objectif GetObjectifByID(Guid ObjectifId)
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
