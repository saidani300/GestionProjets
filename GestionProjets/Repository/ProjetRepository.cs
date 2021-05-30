using GestionProjets.DBContext;
using GestionProjets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProjets.Repository
{
    public class ProjetRepository : IProjetRepository
    {
        private readonly QualitasContext _dbContext;

        public ProjetRepository(QualitasContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteProjet(Guid ProjetId)
        {
            var Projet = _dbContext.Projets.Find(ProjetId);
            _dbContext.Projets.Remove(Projet);
            Save();
        }

        public Projet GetProjetByID(Guid ProjetId)
        {
            return _dbContext.Projets.Find(ProjetId);
        }

        public IEnumerable<Projet> GetProjets()
        {
            return _dbContext.Projets.ToList();
        }

        public void InsertProjet(Projet Projet)
        {
            _dbContext.Add(Projet);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateProjet(Projet Projet)
        {
            _dbContext.Entry(Projet).State = EntityState.Modified;
            Save();
        }
    }
}
