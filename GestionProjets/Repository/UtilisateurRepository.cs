using GestionProjets.DBContext;
using GestionProjets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProjets.Repository
{
    public class UtilisateurRepository : IUtilisateurRepository
    {
        private readonly QalitasContext _dbContext;

        public UtilisateurRepository(QalitasContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteUtilisateur(Guid UtilisateurId)
        {
            var Utilisateur = _dbContext.Utilisateurs.Find(UtilisateurId);
            _dbContext.Utilisateurs.Remove(Utilisateur);
            Save();
        }

        public Utilisateur GetUtilisateurByID(Guid UtilisateurId)
        {
            return _dbContext.Utilisateurs.Find(UtilisateurId);
        }

        public IEnumerable<Utilisateur> GetUtilisateurs()
        {
            return _dbContext.Utilisateurs.ToList();
        }

        public void InsertUtilisateur(Utilisateur Utilisateur)
        {
            _dbContext.Add(Utilisateur);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateUtilisateur(Utilisateur Utilisateur)
        {
            _dbContext.Entry(Utilisateur).State = EntityState.Modified;
            Save();
        }
    }
}
