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
        private readonly QalitasContext _dbContext;

        public ProjetRepository(QalitasContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Projet> GetProjetsByUtilisateur(Guid UserId)
        {
            return _dbContext.Projets.Where(A => A.UserId == UserId);
        }

        public Projet GetProjetByID(Guid ProjetId)
        {
            return _dbContext.Projets.Include(p => p.Responsable).Where(p => p.Id == ProjetId).Single();
        }

        public IEnumerable<Projet> GetProjets(Guid Userid)
        {
            return _dbContext.Projets.Where(A => A.UserId == Userid);
        }

        public void InsertProjet(Projet Projet)
        {
            _dbContext.Projets.Add(Projet);
            Save();
        }


        public void UpdateProjet(Projet Projet)
        {
            _dbContext.Entry(Projet).State = EntityState.Modified;
            Save();
        }

        public void DeleteProjet(Guid ProjetId)
        {
            var Projet = _dbContext.Projets.Find(ProjetId);
            _dbContext.Projets.Remove(Projet);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

    }
}
