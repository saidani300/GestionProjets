using GestionProjets.DBContext;
using GestionProjets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProjets.Repository
{
    public class TacheRepository : ITacheRepository
    {
        private readonly QualitasContext _dbContext;

        public TacheRepository(QualitasContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteTache(string TacheId)
        {
            var Tache = _dbContext.Taches.Find(TacheId);
            _dbContext.Taches.Remove(Tache);
            Save();
        }

        public Tache GetTacheByID(string TacheId)
        {
            return _dbContext.Taches.Find(TacheId);
        }

        public IEnumerable<Tache> GetTaches()
        {
            return _dbContext.Taches.ToList();
        }

        public void InsertTache(Tache Tache)
        {
            _dbContext.Add(Tache);
            
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateTache(Tache Tache)
        {
            _dbContext.Entry(Tache).State = EntityState.Modified;
            Save();
        }
    }
}
