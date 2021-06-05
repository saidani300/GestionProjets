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
        private readonly QalitasContext _dbContext;

        public TacheRepository(QalitasContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Tache> GetTachesByProject(Guid ProjetId)
        {
            return _dbContext.Taches.Where(A => A.ProjetId == ProjetId);
        }

        public IEnumerable<Tache> GetTachesByAction(Guid ActionId)
        {
            return _dbContext.Taches.Where(A => A.ActionId == ActionId);
        }
        public void DeleteTache(Guid TacheId)
        {
            var Tache = _dbContext.Taches.Find(TacheId);
            _dbContext.Taches.Remove(Tache);
            Save();
        }

        public Tache GetTacheByID(Guid TacheId)
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
