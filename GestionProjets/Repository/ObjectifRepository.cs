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
            return _dbContext.Projets.Where(A => A.Id == ProjetId).FirstOrDefault().Objectifs;
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
            if (Objectif != null)
            {
                Projet p = _dbContext.Projets.Where(A => A.Id == Objectif.Id).FirstOrDefault();
                p.Objectifs.Add(Objectif);
                Save();
            }
        }



        public void UpdateObjectif(Objectif Objectif)
        {
            _dbContext.Entry(Objectif).State = EntityState.Modified;
            Save();
        }

        public void DeleteObjectif(Guid ObjectifId)
        {
            var Objectif = _dbContext.Objectifs.Find(ObjectifId);
            _dbContext.Objectifs.Remove(Objectif);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
